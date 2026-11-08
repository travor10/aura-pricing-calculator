Imports NUnit.Framework
Imports AuraPricingSystem.Models
Imports AuraPricingSystem.Repositories
Imports AuraPricingSystem.Data
Imports AuraPricingSystem.Services
Imports System.IO

Namespace Tests
    ''' <summary>
    ''' Automated unit tests for Phase 4 Business Operations:
    ''' Pricing Calculator snapshot locking, Quotations lifecycle,
    ''' Job scheduling guards (Accepted only), and JobStaff multi-assignment.
    ''' </summary>
    <TestFixture()>
    Public Class BusinessOperationsTests
        Private _tempDbPath As String
        Private _origDbPath As String

        <SetUp()>
        Public Sub Setup()
            _origDbPath = DatabaseConnection.DatabaseFilePath
            _tempDbPath = Path.Combine(Path.GetTempPath(), $"AuraTest_Ops_{Guid.NewGuid():N}.db")
            DatabaseConnection.DatabaseFilePath = _tempDbPath
            DatabaseInitializer.InitializeDatabase()
        End Sub

        <TearDown()>
        Public Sub Cleanup()
            DatabaseConnection.DatabaseFilePath = _origDbPath
            If File.Exists(_tempDbPath) Then
                Try
                    File.Delete(_tempDbPath)
                Catch
                    ' Best effort cleanup
                End Try
            End If
        End Sub

        <Test()>
        Public Sub Test_SaveQuotation_LocksImmutableCalculationSnapshot()
            Dim quoteRepo As New QuotationRepository()

            ' 1. Calculate Bukiika using PricingEngine
            Dim calc = PricingEngine.Calculate(
                teamMembers:=7,
                dayRate:=30000D,
                days:=2.0D,
                suppliesCost:=100000D,
                transportCost:=200000D,
                equipmentWear:=15000D,
                monthlyOverhead:=100000D,
                avgJobsPerMonth:=8,
                targetMargin:=0.35D,
                actualQuote:=1200000D
            )

            ' 2. Save quotation with calculation snapshot
            Dim quote As New Quotation With {
                .QuoteNo = "QUO-0001",
                .ClientID = 1,
                .ServiceID = 3, ' Post-construction
                .JobName = "Bukiika Residence Post-Construction",
                .JobType = "Residential - Post-Construction",
                .QuoteDate = DateTime.Today,
                .TotalAmount = 1200000D,
                .Status = "Draft",
                .CreatedByUserID = 1
            }

            Dim saved = quoteRepo.SaveQuotationWithCalculation(quote, calc)
            Assert.That(saved, Is.True, "Quotation and calculation should save atomically")
            Assert.That(quote.QuotationID, Is.GreaterThan(0))

            ' 3. Retrieve and verify snapshot
            Dim fetched = quoteRepo.GetQuotationWithCalculation(quote.QuotationID)
            Assert.That(fetched, Is.Not.Null)
            Assert.That(fetched.Status, Is.EqualTo("Draft"))
            Assert.That(fetched.Calculation, Is.Not.Null, "Calculation snapshot must be loaded")

            ' Verify mathematical snapshot values
            Assert.That(fetched.Calculation.LaborCost, Is.EqualTo(420000D))
            Assert.That(fetched.Calculation.OverheadAllocation, Is.EqualTo(12500D))
            Assert.That(fetched.Calculation.TotalCost, Is.EqualTo(747500D))
            Assert.That(fetched.Calculation.SuggestedPrice, Is.EqualTo(1150000D))
            Assert.That(fetched.Calculation.ProfitAtSuggested, Is.EqualTo(402500D))
            Assert.That(fetched.Calculation.ActualQuote, Is.EqualTo(1200000D))
            Assert.That(fetched.Calculation.ActualProfit, Is.EqualTo(452500D))
            Assert.That(fetched.Calculation.Verdict, Is.EqualTo("HEALTHY MARGIN"))
        End Sub

        <Test()>
        Public Sub Test_QuotationStatusWorkflow_Transitions()
            Dim quoteRepo As New QuotationRepository()

            Dim calc = PricingEngine.Calculate(2, 30000D, 1D, 50000D, 50000D, 0D, 100000D, 8, 0.35D, 300000D)
            Dim quote As New Quotation With {
                .QuoteNo = "QUO-0002",
                .ClientID = 1,
                .ServiceID = 1,
                .JobName = "Standard Cleanup",
                .JobType = "Residential - Standard",
                .QuoteDate = DateTime.Today,
                .TotalAmount = 300000D,
                .Status = "Draft",
                .CreatedByUserID = 1
            }
            quoteRepo.SaveQuotationWithCalculation(quote, calc)

            ' Draft -> Sent
            Dim sentOk = quoteRepo.UpdateStatus(quote.QuotationID, "Sent")
            Assert.That(sentOk, Is.True)
            Dim fetchedSent = quoteRepo.GetQuotationWithCalculation(quote.QuotationID)
            Assert.That(fetchedSent.Status, Is.EqualTo("Sent"))

            ' Sent -> Accepted
            Dim acceptOk = quoteRepo.UpdateStatus(quote.QuotationID, "Accepted")
            Assert.That(acceptOk, Is.True)
            Dim fetchedAccepted = quoteRepo.GetQuotationWithCalculation(quote.QuotationID)
            Assert.That(fetchedAccepted.Status, Is.EqualTo("Accepted"))
        End Sub

        <Test()>
        Public Sub Test_JobScheduling_GuardsAgainstUnacceptedQuotes()
            Dim quoteRepo As New QuotationRepository()
            Dim jobRepo As New JobRepository()

            ' 1. Create a Draft quote
            Dim calc = PricingEngine.Calculate(2, 30000D, 1D, 50000D, 50000D, 0D, 100000D, 8, 0.35D, 300000D)
            Dim quote As New Quotation With {
                .QuoteNo = "QUO-0003",
                .ClientID = 1,
                .ServiceID = 1,
                .JobName = "Office Dusting",
                .JobType = "Commercial",
                .QuoteDate = DateTime.Today,
                .TotalAmount = 300000D,
                .Status = "Draft", ' NOT ACCEPTED
                .CreatedByUserID = 1
            }
            quoteRepo.SaveQuotationWithCalculation(quote, calc)

            ' 2. Attempting to schedule a job for a Draft quote MUST throw InvalidOperationException
            Dim unacceptedJob As New JobBooking With {
                .JobNo = "JOB-0001",
                .QuotationID = quote.QuotationID,
                .JobDate = DateTime.Today.AddDays(2),
                .Status = "Scheduled",
                .Notes = "Should fail"
            }

            Assert.Throws(Of InvalidOperationException)(
                Sub()
                    jobRepo.CreateJobFromQuotation(unacceptedJob, New List(Of Integer) From {1, 2})
                End Sub,
                "Job scheduling must fail if quotation is not in Accepted status."
            )
        End Sub

        <Test()>
        Public Sub Test_JobScheduling_WithMultiStaffAssignment_SucceedsForAcceptedQuote()
            Dim quoteRepo As New QuotationRepository()
            Dim jobRepo As New JobRepository()

            ' 1. Create an Accepted quote
            Dim calc = PricingEngine.Calculate(7, 30000D, 2D, 100000D, 200000D, 15000D, 100000D, 8, 0.35D, 1200000D)
            Dim quote As New Quotation With {
                .QuoteNo = "QUO-0004",
                .ClientID = 1,
                .ServiceID = 3,
                .JobName = "Bukiika Accepted",
                .JobType = "Residential - Post-Construction",
                .QuoteDate = DateTime.Today,
                .TotalAmount = 1200000D,
                .Status = "Accepted", ' ACCEPTED!
                .CreatedByUserID = 1
            }
            quoteRepo.SaveQuotationWithCalculation(quote, calc)

            ' 2. Schedule Job with Staff 1, 2, 3 assigned
            Dim job As New JobBooking With {
                .JobNo = "JOB-0001",
                .QuotationID = quote.QuotationID,
                .JobDate = DateTime.Today.AddDays(3),
                .Status = "Scheduled",
                .Notes = "Focus on paint splatters and window frames."
            }

            Dim assignedStaff = New List(Of Integer) From {1, 2, 3}
            Dim created = jobRepo.CreateJobFromQuotation(job, assignedStaff)
            Assert.That(created, Is.True, "Job creation for Accepted quote must succeed")

            ' 3. Verify Job and assigned staff retrieval
            Dim allJobs = jobRepo.GetAllJobs()
            Dim scheduledJob = allJobs.FirstOrDefault(Function(j) j.JobNo = "JOB-0001")
            Assert.That(scheduledJob, Is.Not.Null)
            Assert.That(scheduledJob.QuoteNo, Is.EqualTo("QUO-0004"))
            Assert.That(scheduledJob.AssignedStaffList.Count, Is.EqualTo(3), "Three staff members should be assigned via JobStaff table")

            ' 4. Update status to In Progress
            scheduledJob.Status = "In Progress"
            Dim updated = jobRepo.UpdateJob(scheduledJob, New List(Of Integer) From {1, 2})
            Assert.That(updated, Is.True)

            Dim reloaded = jobRepo.GetAllJobs().First(Function(j) j.JobNo = "JOB-0001")
            Assert.That(reloaded.Status, Is.EqualTo("In Progress"))
            Assert.That(reloaded.AssignedStaffList.Count, Is.EqualTo(2), "Staff assignment updated to 2 members")
        End Sub
    End Class
End Namespace
