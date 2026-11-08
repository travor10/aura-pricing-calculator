Namespace Models
    ''' <summary>
    ''' Represents a system user account for authentication and role-based authorization.
    ''' </summary>
    Public Class User
        Public Property UserID As Integer
        Public Property Username As String = String.Empty
        Public Property PasswordHash As String = String.Empty
        Public Property Salt As String = String.Empty
        Public Property Role As String = "Staff" ' Admin, Manager, Staff
        Public Property Status As String = "Active" ' Active, Inactive
        Public Property CreatedAt As DateTime = DateTime.Now

        Public ReadOnly Property IsAdmin As Boolean
            Get
                Return Role.Equals("Admin", StringComparison.OrdinalIgnoreCase)
            End Get
        End Property

        Public ReadOnly Property IsManager As Boolean
            Get
                Return Role.Equals("Manager", StringComparison.OrdinalIgnoreCase) OrElse IsAdmin
            End Get
        End Property

        Public ReadOnly Property IsActive As Boolean
            Get
                Return Status.Equals("Active", StringComparison.OrdinalIgnoreCase)
            End Get
        End Property
    End Class
End Namespace
