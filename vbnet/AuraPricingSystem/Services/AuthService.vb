Imports AuraPricingSystem.Models
Imports AuraPricingSystem.Repositories

Namespace Services
    ''' <summary>
    ''' Manages authentication sessions and enforces role-based access control (RBAC).
    ''' Enforces permissions in business services, not only by hiding buttons in the UI.
    ''' </summary>
    Public Class AuthService
        Private Shared _currentUser As User
        Private ReadOnly _userRepo As UserRepository

        Public Sub New()
            _userRepo = New UserRepository()
        End Sub

        Public Sub New(userRepo As UserRepository)
            _userRepo = userRepo
        End Sub

        ''' <summary>
        ''' Gets the currently authenticated user.
        ''' </summary>
        Public Shared ReadOnly Property CurrentUser As User
            Get
                Return _currentUser
            End Get
        End Property

        ''' <summary>
        ''' Indicates whether a user is currently logged in.
        ''' </summary>
        Public Shared ReadOnly Property IsAuthenticated As Boolean
            Get
                Return _currentUser IsNot Nothing AndAlso _currentUser.IsActive
            End Get
        End Property

        ''' <summary>
        ''' Authenticates credentials against the database, sets current session, and logs activity.
        ''' </summary>
        Public Function Login(username As String, password As String) As (Success As Boolean, Message As String, User As User)
            If String.IsNullOrWhiteSpace(username) Then
                Return (False, "Please enter your username.", Nothing)
            End If

            If String.IsNullOrWhiteSpace(password) Then
                Return (False, "Please enter your password.", Nothing)
            End If

            Dim user As User = _userRepo.Authenticate(username.Trim(), password)
            If user Is Nothing Then
                Return (False, "Invalid username or password. Please try again.", Nothing)
            End If

            If Not user.IsActive Then
                Return (False, "This account is currently inactive. Contact your system administrator.", Nothing)
            End If

            ' Set authenticated session
            _currentUser = user

            ' Audit log
            ActivityLogRepository.Log($"User logged in ({user.Role})", user.Username)

            Return (True, "Login successful.", user)
        End Function

        ''' <summary>
        ''' Logs out current user and clears session state.
        ''' </summary>
        Public Sub Logout()
            If _currentUser IsNot Nothing Then
                ActivityLogRepository.Log("User logged out", _currentUser.Username)
            End If
            _currentUser = Nothing
        End Sub

        ''' <summary>
        ''' Enforces role-based permissions in business logic.
        ''' Permissions:
        ''' - Staff cannot access User Management or Settings.
        ''' - Manager cannot access User Management.
        ''' - Admin has full access.
        ''' </summary>
        Public Shared Function CanAccessModule(moduleName As String) As Boolean
            If Not IsAuthenticated Then Return False

            Select Case moduleName.Trim().ToUpperInvariant()
                Case "USERS", "USERMANAGEMENT"
                    Return _currentUser.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase)

                Case "SETTINGS", "SYSTEMSETTINGS"
                    Return _currentUser.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase)

                Case "REPORTS", "FINANCIALREPORTS"
                    Return _currentUser.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase) OrElse
                           _currentUser.Role.Equals("Manager", StringComparison.OrdinalIgnoreCase)

                Case "DASHBOARD", "CLIENTS", "SERVICES", "STAFF", "CALCULATOR", "QUOTES", "JOBS", "LOGOUT"
                    Return True

                Case Else
                    Return False
            End Select
        End Function
    End Class
End Namespace
