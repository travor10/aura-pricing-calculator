Imports NUnit.Framework
Imports AuraPricingSystem.Models
Imports AuraPricingSystem.Repositories
Imports AuraPricingSystem.Data
Imports AuraPricingSystem.Helpers
Imports System.IO

Namespace Tests
    ''' <summary>
    ''' Automated unit tests for Phase 3 Core Management:
    ''' Clients, Services & Rates, Staff, Users & RBAC, Company Settings & Margin Guides.
    ''' </summary>
    <TestFixture()>
    Public Class CoreManagementTests
        Private _tempDbPath As String
        Private _origDbPath As String

        <SetUp()>
        Public Sub Setup()
            _origDbPath = DatabaseConnection.DatabaseFilePath
            _tempDbPath = Path.Combine(Path.GetTempPath(), $"AuraTest_Core_{Guid.NewGuid():N}.db")
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
        Public Sub Test_ClientAutoNumbering_And_CRUD()
            Dim repo As New ClientRepository()

            ' 1. Next client number format
            Dim nextNo = repo.GetNextClientNo()
            Assert.That(nextNo, Does.StartWith("CL"), "Client number should start with CL prefix")

            ' 2. Insert Client
            Dim c As New Client With {
                .ClientNo = nextNo,
                .FullName = "Kampala Serena Hotel",
                .Phone = "+256 414 309000",
                .Location = "Kintu Road, Kampala",
                .ClientType = "Commercial"
            }
            Dim inserted = repo.InsertClient(c)
            Assert.That(inserted, Is.True, "Client insertion should succeed")
            Assert.That(c.ClientID, Is.GreaterThan(0), "Client ID should be generated")

            ' 3. Search Client
            Dim searchResults = repo.SearchClients("Serena")
            Assert.That(searchResults.Count, Is.GreaterThanOrEqualTo(1), "Search should find Serena")
            Assert.That(searchResults(0).FullName, Is.EqualTo("Kampala Serena Hotel"))

            ' 4. Update Client
            c.Phone = "+256 700 112233"
            Dim updated = repo.UpdateClient(c)
            Assert.That(updated, Is.True, "Update should succeed")

            ' 5. Delete Client
            Dim deleted = repo.DeleteClient(c.ClientID)
            Assert.That(deleted, Is.True, "Delete should succeed")
        End Sub

        <Test()>
        Public Sub Test_ServiceRates_CRUD_And_HistoricalDecoupling()
            Dim repo As New ServiceRepository()

            ' 1. Check seeded services
            Dim services = repo.GetAllServices()
            Assert.That(services.Count, Is.GreaterThanOrEqualTo(5), "Database initializer should seed default services")

            ' 2. Insert New Service
            Dim newSvc As New ServiceItem With {
                .ServiceCode = "PC_TEST",
                .ServiceName = "Post Construction Deep Scrub",
                .LaborRate = 45000D,
                .Unit = "Per Day"
            }
            Dim inserted = repo.InsertService(newSvc)
            Assert.That(inserted, Is.True)

            ' 3. Retrieve
            Dim fetched = repo.GetServiceByCode("PC_TEST")
            Assert.That(fetched, Is.Not.Null)
            Assert.That(fetched.LaborRate, Is.EqualTo(45000D))

            ' 4. Update Rate
            fetched.LaborRate = 50000D
            Dim updated = repo.UpdateService(fetched)
            Assert.That(updated, Is.True)

            Dim refetched = repo.GetServiceByCode("PC_TEST")
            Assert.That(refetched.LaborRate, Is.EqualTo(50000D))

            ' 5. Delete
            Dim deleted = repo.DeleteService(refetched.ServiceID)
            Assert.That(deleted, Is.True)
        End Sub

        <Test()>
        Public Sub Test_StaffManagement_And_StatusFilter()
            Dim repo As New StaffRepository()

            ' 1. Next Staff number format
            Dim nextStaffNo = repo.GetNextStaffNo()
            Assert.That(nextStaffNo, Does.StartWith("ST"))

            ' 2. Insert Staff
            Dim staff As New StaffMember With {
                .StaffNo = nextStaffNo,
                .FullName = "Okello David",
                .Phone = "+256 772 456789",
                .Role = "Specialist",
                .DailyRate = 35000D,
                .Status = "Active"
            }
            Dim inserted = repo.InsertStaff(staff)
            Assert.That(inserted, Is.True)

            ' 3. Get Active Staff
            Dim activeList = repo.GetActiveStaff()
            Assert.That(activeList.Any(Function(s) s.FullName = "Okello David"), Is.True)

            ' 4. Deactivate Staff
            Dim all = repo.GetAllStaff()
            Dim createdStaff = all.First(Function(s) s.FullName = "Okello David")
            createdStaff.Status = "Inactive"
            repo.UpdateStaff(createdStaff)

            Dim activeAfter = repo.GetActiveStaff()
            Assert.That(activeAfter.Any(Function(s) s.FullName = "Okello David"), Is.False, "Inactive staff should not appear in active staff list")
        End Sub

        <Test()>
        Public Sub Test_UserManagement_PBKDF2_And_RoleSecurity()
            Dim repo As New UserRepository()

            ' 1. Create a new Manager account
            Dim created = repo.CreateUser("testmanager", "ManagerPass@2025", "Manager")
            Assert.That(created, Is.True)

            ' 2. Authenticate
            Dim authenticatedUser = repo.Authenticate("testmanager", "ManagerPass@2025")
            Assert.That(authenticatedUser, Is.Not.Null)
            Assert.That(authenticatedUser.Role, Is.EqualTo("Manager"))
            Assert.That(authenticatedUser.Status, Is.EqualTo("Active"))

            ' 3. Verify bad password rejected
            Dim badAuth = repo.Authenticate("testmanager", "WrongPassword")
            Assert.That(badAuth, Is.Null)

            ' 4. Update role & password
            Dim updated = repo.UpdateUser(authenticatedUser.UserID, "Admin", "Active", "NewAdminSecret#1")
            Assert.That(updated, Is.True)

            Dim reAuth = repo.Authenticate("testmanager", "NewAdminSecret#1")
            Assert.That(reAuth, Is.Not.Null)
            Assert.That(reAuth.Role, Is.EqualTo("Admin"))

            ' 5. Clean up
            repo.DeleteUser(authenticatedUser.UserID)
        End Sub

        <Test()>
        Public Sub Test_Settings_And_MarginGuideUpdates()
            Dim repo As New SettingsRepository()

            ' 1. Retrieve default settings
            Dim s = repo.GetSettings()
            Assert.That(s.CompanyName, Is.EqualTo("Aura Cleaning Solutions"))
            Assert.That(s.DefaultMargin, Is.EqualTo(0.35D))
            Assert.That(s.Currency, Is.EqualTo("UGX"))

            ' 2. Modify settings
            s.CompanyName = "Aura Cleaning Solutions Uganda Ltd"
            s.DefaultMargin = 0.38D
            s.CompanyPhone = "+256 700 999888"
            Dim saved = repo.SaveSettings(s)
            Assert.That(saved, Is.True)

            Dim refreshed = repo.GetSettings()
            Assert.That(refreshed.CompanyName, Is.EqualTo("Aura Cleaning Solutions Uganda Ltd"))
            Assert.That(refreshed.DefaultMargin, Is.EqualTo(0.38D))

            ' 3. Margin Guide check
            Dim guides = repo.GetAllMarginGuides()
            Assert.That(guides.Count, Is.GreaterThanOrEqualTo(5))

            Dim postConstruction = repo.GetMarginGuideForJobType("Residential - Post-Construction")
            Assert.That(postConstruction.MinMargin, Is.EqualTo(0.25D))
            Assert.That(postConstruction.MaxMargin, Is.EqualTo(0.35D))

            ' 4. Update Margin Guide band
            postConstruction.MinMargin = 0.28D
            postConstruction.MaxMargin = 0.40D
            postConstruction.DisplayRange = "28%–40%"
            Dim guideUpdated = repo.UpdateMarginGuide(postConstruction)
            Assert.That(guideUpdated, Is.True)

            Dim updatedGuide = repo.GetMarginGuideForJobType("Residential - Post-Construction")
            Assert.That(updatedGuide.MinMargin, Is.EqualTo(0.28D))
            Assert.That(updatedGuide.MaxMargin, Is.EqualTo(0.40D))
        End Sub
    End Class
End Namespace
