Namespace Models
    ''' <summary>
    ''' Represents a member of the cleaning crew, supervisor, or fumigator.
    ''' </summary>
    Public Class StaffMember
        Public Property StaffID As Integer
        Public Property StaffNo As String = String.Empty ' e.g., ST001
        Public Property FullName As String = String.Empty
        Public Property Phone As String = String.Empty
        Public Property Role As String = "Cleaner" ' Cleaner, Supervisor, Fumigator
        Public Property DailyRate As Decimal = 30000D ' Standard in UGX
        Public Property Status As String = "Active" ' Active, Inactive
        Public Property CreatedAt As DateTime = DateTime.Now

        Public Overrides Function ToString() As String
            Return $"{StaffNo} - {FullName} ({Role})"
        End Function
    End Class
End Namespace
