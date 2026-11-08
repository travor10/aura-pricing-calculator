Imports NUnit.Framework
Imports Microsoft.Data.Sqlite
Imports AuraPricingSystem.Data
Imports AuraPricingSystem.Models
Imports AuraPricingSystem.Repositories
Imports AuraPricingSystem.Services

Namespace AuraPricingSystem.Tests
    ''' <summary>
    ''' HISTORICAL DATA INTEGRITY AND REPOSITORY TESTS
    ''' Verifies that a saved quotation retains its original pricing inputs, rates,
    ''' cost breakdown, target margin, and calculated results even if future rates change.
    ''' </summary>
    <TestFixture>
    Public Class HistoricalIntegrityTests
        Private _keepAliveConnection As SqliteConnection
        Private _quoteRepo As QuotationRepository
        Private _serviceRepo As ServiceRepository
        Private _clientRepo As ClientRepository

        <SetUp>
        Public Sub Setup()
            ' Use in-memory SQLite database shared across connection instances for test run
            Dim inMemoryString As String = "Data Source=InMemoryAuraTest;Mode=Memory;Cache=Shared"
            DatabaseConnection.SetCustomConnectionString(inMemoryString)

            ' Keep open connection so in-memory DB is not erased during test
            _keepAliveConnection = New SqliteConnection(inMemoryString)
            _keepAliveConnection.Open()

            ' Run initial migration and seeds
            DatabaseInitializer.InitializeDatabase()

            _quoteRepo = New QuotationRepository()
            _serviceRepo = New ServiceRepository()
            _clientRepo = New ClientRepository()
        End Sub

        <TearDown>
        Public Sub TearDown()
            If _keepAliveConnection IsNot Nothing Then
                _keepAliveConnection.Close()
                _keepAliveConnection.Dispose()
            End If
            DatabaseConnection.SetCustomConnectionString(String.Empty)
        End Sub

        <Test>
        Public Sub Test_Historical_Quotation_Retains_Original_Rates_When_Future_Rates_Change()
            ' 1. Create a client
            Dim client As New Client With {
                .ClientNo = "CL001",
                .FullName = "Muyenga Residence",
                .Phone = "0700 000 000",
                .Location = "Muyenga, Kampala",
                .ClientType = "Residential"
            }
            _clientRepo.InsertClient(client)

            ' 2. Retrieve initial Post-Construction service (PC01 rate = 30,000)
            Dim service As ServiceItem = _serviceRepo.GetServiceByCode("PC01")
            Assert.That(service, [Is].Not.Null)
            Assert.That(service.LaborRate, [Is].EqualTo(30000D))

            ' 3. Calculate Bukiika sample
            Dim calc As PricingCalculation = PricingEngine.ExecuteCalculation(
                teamMembers:=7,
                dayRate:=service.LaborRate,
                days:=2D,
                suppliesCost:=100000D,
                transportCost:=200000D,
                equipmentWear:=15000D,
                monthlyOverhead:=100000D,
                avgJobsPerMonth:=8,
                targetMargin:=0.35D,
                actualQuote:=1200000D
            )

            Dim quote As New Quotation With {
                .QuoteNo = "Q-0001",
                .ClientID = client.ClientID,
                .ServiceID = service.ServiceID,
                .JobName = "Bukiika Residence",
                .JobType = "Residential - Post-Construction",
                .QuoteDate = DateTime.Today,
                .TotalAmount = 1200000D,
                .Status = "Pending",
                .CreatedByUserID = 1
            }

            ' Save quotation and its calculation snapshot
            Dim saved As Boolean = _quoteRepo.SaveQuotationWithCalculation(quote, calc)
            Assert.That(saved, [Is].True, "Quotation and calculation should save successfully")

            ' 4. SIMULATE FUTURE SYSTEM CHANGE: Admin raises PC01 service rate from 30,000 to 75,000!
            service.LaborRate = 75000D
            Dim updatedSvc As Boolean = _serviceRepo.UpdateService(service)
            Assert.That(updatedSvc, [Is].True)

            ' Verify in database that service rate has indeed changed
            Dim modifiedSvc As ServiceItem = _serviceRepo.GetServiceByCode("PC01")
            Assert.That(modifiedSvc.LaborRate, [Is].EqualTo(75000D))

            ' 5. RELOAD HISTORICAL QUOTATION Q-0001
            Dim reloadedQuote As Quotation = _quoteRepo.GetQuotationWithCalculation(quote.QuotationID)
            Assert.That(reloadedQuote, [Is].Not.Null)
            Assert.That(reloadedQuote.Calculation, [Is].Not.Null)

            ' CRITICAL ASSERTION: The historical snapshot MUST still reflect the original 30,000 rate,
            ' 420,000 labor cost, 747,500 total cost, and 1,150,000 suggested price!
            Assert.That(reloadedQuote.Calculation.DayRate, [Is].EqualTo(30000D), "Historical snapshot day rate must remain 30,000")
            Assert.That(reloadedQuote.Calculation.LaborCost, [Is].EqualTo(420000D), "Historical labor cost must remain 420,000")
            Assert.That(reloadedQuote.Calculation.TotalCost, [Is].EqualTo(747500D), "Historical total cost must remain 747,500")
            Assert.That(reloadedQuote.Calculation.SuggestedPrice, [Is].EqualTo(1150000D), "Historical suggested price must remain 1,150,000")
            Assert.That(reloadedQuote.Calculation.ProfitAtSuggested, [Is].EqualTo(402500D), "Historical profit must remain 402,500")
            Assert.That(reloadedQuote.Calculation.ActualMargin, [Is].EqualTo(0.3771D), "Historical margin must remain 37.7%")
            Assert.That(reloadedQuote.Calculation.Verdict, [Is].EqualTo("HEALTHY MARGIN"), "Historical verdict must remain HEALTHY MARGIN")
        End Sub
    End Class
End Namespace
