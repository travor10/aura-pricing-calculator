Namespace Models
    ''' <summary>
    ''' Stores the immutable calculation snapshot for a quotation.
    ''' Historical Rule: Altering future rates, overhead, or settings does not alter this saved snapshot.
    ''' </summary>
    Public Class PricingCalculation
        Public Property CalculationID As Integer
        Public Property QuotationID As Integer

        ' Inputs recorded at time of calculation
        Public Property TeamMembers As Integer
        Public Property DayRate As Decimal
        Public Property Days As Decimal
        Public Property SuppliesCost As Decimal
        Public Property TransportCost As Decimal
        Public Property EquipmentWear As Decimal
        Public Property MonthlyOverhead As Decimal
        Public Property AvgJobsPerMonth As Integer
        Public Property TargetMargin As Decimal ' Decimal between 0.0 and 0.999 (e.g. 0.35)

        ' Computed outputs
        Public Property LaborCost As Decimal
        Public Property OverheadAllocation As Decimal
        Public Property TotalCost As Decimal
        Public Property SuggestedPrice As Decimal
        Public Property ProfitAtSuggested As Decimal
        Public Property LaborPercent As Decimal ' Percentage e.g. 0.365 (36.5%)
        Public Property ActualQuote As Decimal
        Public Property ActualProfit As Decimal
        Public Property ActualMargin As Decimal ' Percentage e.g. 0.377 (37.7%)
        Public Property Verdict As String = String.Empty ' e.g., "HEALTHY MARGIN"
    End Class
End Namespace
