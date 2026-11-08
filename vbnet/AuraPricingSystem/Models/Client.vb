Namespace Models
    ''' <summary>
    ''' Represents a commercial or residential cleaning client.
    ''' </summary>
    Public Class Client
        Public Property ClientID As Integer
        Public Property ClientNo As String = String.Empty ' e.g., CL001
        Public Property FullName As String = String.Empty
        Public Property Phone As String = String.Empty
        Public Property Location As String = String.Empty
        Public Property ClientType As String = "Residential" ' Residential or Commercial
        Public Property CreatedAt As DateTime = DateTime.Now

        Public Overrides Function ToString() As String
            Return $"{ClientNo} - {FullName} ({ClientType})"
        End Function
    End Class
End Namespace
