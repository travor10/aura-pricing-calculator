Imports AuraPricingSystem.Models

Namespace Services
    ''' <summary>
    ''' CENTRAL BUSINESS LOGIC ENGINE
    ''' Implements exact formulas from the Aura_Job_Costing_Calculator workbook.
    ''' Crucial Rule: No pricing formulas exist outside this class.
    ''' Uses Decimal arithmetic for all financial calculations.
    ''' </summary>
    Public NotInheritable Class PricingEngine
        Private Sub New()
            ' Static utility class
        End Sub

        ' Verdict Constants
        Public Const VERDICT_BELOW_FLOOR As String = "BELOW SURVIVAL FLOOR - reprice"
        Public Const VERDICT_THIN As String = "OK, BUT THIN - push toward target"
        Public Const VERDICT_HEALTHY As String = "HEALTHY MARGIN"
        Public Const VERDICT_UNUSUALLY_HIGH As String = "CHECK - unusually high, verify costs"

        ' Labor Percentage Reference Band (45% to 60%)
        Public Const LABOR_MIN_REFERENCE As Decimal = 0.45D
        Public Const LABOR_MAX_REFERENCE As Decimal = 0.60D

        ''' <summary>
        ''' Calculates Total Direct Labour Cost = TeamMembers * DayRate * Days.
        ''' </summary>
        Public Shared Function CalculateLaborCost(teamMembers As Integer, dayRate As Decimal, days As Decimal) As Decimal
            If teamMembers < 0 Then Throw New ArgumentOutOfRangeException(NameOf(teamMembers), "Team members cannot be negative.")
            If dayRate < 0D Then Throw New ArgumentOutOfRangeException(NameOf(dayRate), "Daily rate cannot be negative.")
            If days < 0D Then Throw New ArgumentOutOfRangeException(NameOf(days), "Days on job cannot be negative.")

            Return Math.Round(CDec(teamMembers) * dayRate * days, 0, MidpointRounding.AwayFromZero)
        End Function

        ''' <summary>
        ''' Allocates monthly business overhead to this job = MonthlyOverhead / AvgJobsPerMonth.
        ''' Returns 0 if average jobs is 0 to safely prevent division by zero.
        ''' </summary>
        Public Shared Function CalculateOverheadAllocation(monthlyOverhead As Decimal, avgJobsPerMonth As Integer) As Decimal
            If monthlyOverhead < 0D Then Throw New ArgumentOutOfRangeException(NameOf(monthlyOverhead), "Monthly overhead cannot be negative.")
            If avgJobsPerMonth <= 0 Then Return 0D

            Return Math.Round(monthlyOverhead / CDec(avgJobsPerMonth), 0, MidpointRounding.AwayFromZero)
        End Function

        ''' <summary>
        ''' Calculates Total Job Cost = LaborCost + Supplies + Transport + EquipmentWear + OverheadAllocation.
        ''' </summary>
        Public Shared Function CalculateTotalCost(laborCost As Decimal,
                                                 supplies As Decimal,
                                                 transport As Decimal,
                                                 equipmentWear As Decimal,
                                                 overheadAllocation As Decimal) As Decimal
            If laborCost < 0D Then Throw New ArgumentOutOfRangeException(NameOf(laborCost), "Labor cost cannot be negative.")
            If supplies < 0D Then Throw New ArgumentOutOfRangeException(NameOf(supplies), "Supplies cost cannot be negative.")
            If transport < 0D Then Throw New ArgumentOutOfRangeException(NameOf(transport), "Transport cost cannot be negative.")
            If equipmentWear < 0D Then Throw New ArgumentOutOfRangeException(NameOf(equipmentWear), "Equipment wear cannot be negative.")
            If overheadAllocation < 0D Then Throw New ArgumentOutOfRangeException(NameOf(overheadAllocation), "Overhead allocation cannot be negative.")

            Return laborCost + supplies + transport + equipmentWear + overheadAllocation
        End Function

        ''' <summary>
        ''' Calculates Suggested Selling Price based on Target Profit Margin:
        ''' Price = TotalCost / (1 - TargetMargin).
        ''' Note: TargetMargin is expressed as a decimal between 0.0 and 0.999 (e.g. 0.35 for 35%).
        ''' </summary>
        Public Shared Function CalculateSuggestedPrice(totalCost As Decimal, targetMargin As Decimal) As Decimal
            If totalCost < 0D Then Throw New ArgumentOutOfRangeException(NameOf(totalCost), "Total cost cannot be negative.")
            If targetMargin >= 1.0D Then
                Throw New ArgumentOutOfRangeException(NameOf(targetMargin), "Target profit margin must be less than 100% (1.0).")
            End If
            If targetMargin < 0D Then
                Throw New ArgumentOutOfRangeException(NameOf(targetMargin), "Target profit margin cannot be negative.")
            End If

            Dim divisor As Decimal = 1.0D - targetMargin
            If divisor = 0D Then Throw New InvalidOperationException("Target margin cannot equal 100%.")

            Return Math.Round(totalCost / divisor, 0, MidpointRounding.AwayFromZero)
        End Function

        ''' <summary>
        ''' Calculates Profit at the Suggested Price = SuggestedPrice - TotalCost.
        ''' </summary>
        Public Shared Function CalculateProfitAtSuggested(suggestedPrice As Decimal, totalCost As Decimal) As Decimal
            Return suggestedPrice - totalCost
        End Function

        ''' <summary>
        ''' Calculates Labour Cost as a percentage of Suggested Price = LaborCost / SuggestedPrice.
        ''' </summary>
        Public Shared Function CalculateLaborPercent(laborCost As Decimal, suggestedPrice As Decimal) As Decimal
            If suggestedPrice <= 0D Then Return 0D
            Return Math.Round(laborCost / suggestedPrice, 4, MidpointRounding.AwayFromZero)
        End Function

        ''' <summary>
        ''' Calculates Actual Profit based on the client-facing quote = ActualQuote - TotalCost.
        ''' </summary>
        Public Shared Function CalculateActualProfit(actualQuote As Decimal, totalCost As Decimal) As Decimal
            Return actualQuote - totalCost
        End Function

        ''' <summary>
        ''' Calculates Actual Profit Margin = (ActualQuote - TotalCost) / ActualQuote.
        ''' </summary>
        Public Shared Function CalculateActualMargin(actualQuote As Decimal, totalCost As Decimal) As Decimal
            If actualQuote <= 0D Then Return 0D
            Return Math.Round((actualQuote - totalCost) / actualQuote, 4, MidpointRounding.AwayFromZero)
        End Function

        ''' <summary>
        ''' Evaluates the actual margin against Aura business verdict thresholds.
        ''' Thresholds:
        ''' - Below 10%: BELOW SURVIVAL FLOOR - reprice
        ''' - Below 20%: OK, BUT THIN - push toward target
        ''' - Up to and including 45%: HEALTHY MARGIN
        ''' - Above 45%: CHECK - unusually high, verify costs
        ''' </summary>
        Public Shared Function DetermineVerdict(actualMargin As Decimal) As String
            If actualMargin < 0.10D Then
                Return VERDICT_BELOW_FLOOR
            ElseIf actualMargin < 0.20D Then
                Return VERDICT_THIN
            ElseIf actualMargin <= 0.45D Then
                Return VERDICT_HEALTHY
            Else
                Return VERDICT_UNUSUALLY_HIGH
            End If
        End Function

        ''' <summary>
        ''' Checks whether the labour percentage falls outside the standard 45%–60% benchmark.
        ''' Does not reject the quotation, but raises an informative operational warning.
        ''' </summary>
        Public Shared Function IsLaborPercentOutsideReferenceBand(laborPercent As Decimal) As Boolean
            Return (laborPercent < LABOR_MIN_REFERENCE OrElse laborPercent > LABOR_MAX_REFERENCE)
        End Function

        ''' <summary>
        ''' Complete execution pipeline: Calculates and populates a full PricingCalculation entity.
        ''' </summary>
        Public Shared Function ExecuteCalculation(teamMembers As Integer,
                                                 dayRate As Decimal,
                                                 days As Decimal,
                                                 suppliesCost As Decimal,
                                                 transportCost As Decimal,
                                                 equipmentWear As Decimal,
                                                 monthlyOverhead As Decimal,
                                                 avgJobsPerMonth As Integer,
                                                 targetMargin As Decimal,
                                                 actualQuote As Decimal) As PricingCalculation
            Dim calc As New PricingCalculation With {
                .TeamMembers = teamMembers,
                .DayRate = dayRate,
                .Days = days,
                .SuppliesCost = suppliesCost,
                .TransportCost = transportCost,
                .EquipmentWear = equipmentWear,
                .MonthlyOverhead = monthlyOverhead,
                .AvgJobsPerMonth = avgJobsPerMonth,
                .TargetMargin = targetMargin,
                .ActualQuote = actualQuote
            }

            ' 1. Cost Breakdown
            calc.LaborCost = CalculateLaborCost(teamMembers, dayRate, days)
            calc.OverheadAllocation = CalculateOverheadAllocation(monthlyOverhead, avgJobsPerMonth)
            calc.TotalCost = CalculateTotalCost(calc.LaborCost, suppliesCost, transportCost, equipmentWear, calc.OverheadAllocation)

            ' 2. Suggested Price & Profit
            calc.SuggestedPrice = CalculateSuggestedPrice(calc.TotalCost, targetMargin)
            calc.ProfitAtSuggested = CalculateProfitAtSuggested(calc.SuggestedPrice, calc.TotalCost)
            calc.LaborPercent = CalculateLaborPercent(calc.LaborCost, calc.SuggestedPrice)

            ' 3. Actual Quote Check
            calc.ActualProfit = CalculateActualProfit(actualQuote, calc.TotalCost)
            calc.ActualMargin = CalculateActualMargin(actualQuote, calc.TotalCost)
            calc.Verdict = DetermineVerdict(calc.ActualMargin)

            Return calc
        End Function
    End Class
End Namespace
