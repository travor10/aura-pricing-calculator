Namespace Models
    ''' <summary>
    ''' Represents a generated quotation header.
    ''' </summary>
    Public Class Quotation
        Public Property QuotationID As Integer
        Public Property QuoteNo As String = String.Empty ' e.g., Q-0001
        Public Property ClientID As Integer
        Public Property ServiceID As Integer
        Public Property JobName As String = String.Empty
        Public Property JobType As String = "Residential - Standard"
        Public Property QuoteDate As DateTime = DateTime.Today
        Public Property TotalAmount As Decimal = 0D ' Client-facing price in UGX
        Public Property Status As String = "Pending" ' Pending, Accepted, Rejected
        Public Property CreatedByUserID As Integer
        Public Property CreatedAt As DateTime = DateTime.Now

        ' Navigation / Joined Properties for DataGridView display
        Public Property ClientName As String = String.Empty
        Public Property ServiceName As String = String.Empty
        Public Property CreatedByUsername As String = String.Empty

        ' Associated historical cost/margin calculation snapshot
        Public Property Calculation As PricingCalculation
    End Class
End Namespace
