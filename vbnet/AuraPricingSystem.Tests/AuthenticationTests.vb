Imports NUnit.Framework
Imports Microsoft.Data.Sqlite
Imports AuraPricingSystem.Data
Imports AuraPricingSystem.Services
Imports AuraPricingSystem.Repositories
Imports AuraPricingSystem.Models

Namespace AuraPricingSystem.Tests
    ''' <summary>
    ''' AUTOMATED AUTHENTICATION & ROLE-BASED ACCESS CONTROL (RBAC) TESTS
    ''' Verifies PBKDF2 credential validation, role retrieval, and permission enforcement.
    ''' </summary>
    <TestFixture>
    Public Class AuthenticationTests
        Private _keepAliveConnection As SqliteConnection
        Private _authService As AuthService
        Private _dashboardService As DashboardService

        <SetUp>
        Public Sub Setup()
            ' Use shared in-memory SQLite database
            Dim inMemoryString As String = "Data Source=InMemoryAuthTest;Mode=Memory;Cache=Shared"
            DatabaseConnection.SetCustomConnectionString(inMemoryString)

            _keepAliveConnection = New SqliteConnection(inMemoryString)
            _keepAliveConnection.Open()

            ' Initialize schema and seed users: admin (admin123), staff1 (staff123)
            DatabaseInitializer.InitializeDatabase()

            _authService = New AuthService()
            _dashboardService = New DashboardService()
        End Sub

        <TearDown>
        Public Sub TearDown()
            _authService.Logout()
            If _keepAliveConnection IsNot Nothing Then
                _keepAliveConnection.Close()
                _keepAliveConnection.Dispose()
            End If
            DatabaseConnection.SetCustomConnectionString(String.Empty)
        End Sub

        <Test>
        Public Sub Test_Admin_Login_Succeeds_And_Sets_Role()
            Dim result = _authService.Login("admin", "admin123")

            Assert.That(result.Success, [Is].True, "Admin login must succeed with correct password")
            Assert.That(result.User, [Is].Not.Null)
            Assert.That(result.User.Role, [Is].EqualTo("Admin"), "User role retrieved from database must be Admin")
            Assert.That(AuthService.IsAuthenticated, [Is].True)
            Assert.That(AuthService.CurrentUser.Username, [Is].EqualTo("admin"))
        End Sub

        <Test>
        Public Sub Test_Staff_Login_Succeeds_And_Sets_Role()
            Dim result = _authService.Login("staff1", "staff123")

            Assert.That(result.Success, [Is].True, "Staff login must succeed")
            Assert.That(result.User.Role, [Is].EqualTo("Staff"), "User role retrieved from database must be Staff")
        End Sub

        <Test>
        Public Sub Test_Wrong_Password_Is_Rejected()
            Dim result = _authService.Login("admin", "wrong_password_999")

            Assert.That(result.Success, [Is].False, "Login with wrong password must fail")
            Assert.That(result.User, [Is].Null)
            Assert.That(AuthService.IsAuthenticated, [Is].False)
        End Sub

        <Test>
        Public Sub Test_Inactive_Account_Is_Rejected()
            ' Create an inactive user in the database
            Dim userRepo As New UserRepository()
            userRepo.CreateUser("blocked_user", "pass123", "Staff")
            Dim users = userRepo.GetAllUsers()
            Dim blocked = users.First(Function(u) u.Username = "blocked_user")
            userRepo.UpdateUser(blocked.UserID, "Staff", "Inactive")

            Dim result = _authService.Login("blocked_user", "pass123")
            Assert.That(result.Success, [Is].False)
            Assert.That(result.Message, Does.Contain("inactive"))
        End Sub

        <Test>
        Public Sub Test_Role_Permissions_Enforcement()
            ' 1. Log in as Staff
            _authService.Login("staff1", "staff123")
            Assert.That(AuthService.CanAccessModule("DASHBOARD"), [Is].True, "Staff can access Dashboard")
            Assert.That(AuthService.CanAccessModule("CALCULATOR"), [Is].True, "Staff can access Calculator")
            Assert.That(AuthService.CanAccessModule("USERS"), [Is].False, "Staff CANNOT access User Management")
            Assert.That(AuthService.CanAccessModule("SETTINGS"), [Is].False, "Staff CANNOT access Settings")
            Assert.That(AuthService.CanAccessModule("REPORTS"), [Is].False, "Staff CANNOT access Financial Reports")

            ' 2. Log in as Admin
            _authService.Login("admin", "admin123")
            Assert.That(AuthService.CanAccessModule("USERS"), [Is].True, "Admin can access User Management")
            Assert.That(AuthService.CanAccessModule("SETTINGS"), [Is].True, "Admin can access Settings")
            Assert.That(AuthService.CanAccessModule("REPORTS"), [Is].True, "Admin can access Reports")
        End Sub

        <Test>
        Public Sub Test_Dashboard_Live_Statistics()
            ' Retrieve initial database stats
            Dim stats = _dashboardService.GetDashboardStatistics()

            Assert.That(stats, [Is].Not.Null)
            Assert.That(stats.ClientsCount, [Is].GreaterThanOrEqualTo(0))
            Assert.That(stats.QuotesThisMonthCount, [Is].GreaterThanOrEqualTo(0))
            Assert.That(stats.ActiveJobsCount, [Is].GreaterThanOrEqualTo(0))
            Assert.That(stats.RecentActivities, [Is].Not.Null)
            ' Login activities from Setup should be recorded in ActivityLogs
            Assert.That(stats.RecentActivities.Count, [Is].GreaterThan(0))
        End Sub
    End Class
End Namespace
