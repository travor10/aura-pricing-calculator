Namespace Models
    ''' <summary>
    ''' Represents a cleaning service and standard labour unit rate.
    ''' </summary>
    Public Class ServiceItem
        Public Property ServiceID As Integer
        Public Property ServiceCode As String = String.Empty ' e.g., PC01, RS01, CP01, UP01, FM01
        Public Property ServiceName As String = String.Empty
        Public Property LaborRate As Decimal = 0D ' In UGX
        Public Property Unit As String = "Per day" ' Per day, Per room, Per sqm, Per item, Per site
        Public Property CreatedAt As DateTime = DateTime.Now

        Public Overrides Function ToString() As String
            Return $"{ServiceCode} - {ServiceName} ({LaborRate:N0} UGX {Unit})"
        End Function
    End Class
End Namespace
