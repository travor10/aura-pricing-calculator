Imports NUnit.Framework
Imports AuraPricingSystem.Services
Imports AuraPricingSystem.Models
Imports AuraPricingSystem.Helpers

Namespace AuraPricingSystem.Tests
    ''' <summary>
    ''' AUTOMATED UNIT TESTS FOR PRICING ENGINE
    ''' Tests the authoritative Bukiika sample, boundary conditions, edge cases, and verdict rules.
    ''' </summary>
    <TestFixture>
    Public Class PricingEngineTests

        <Test>
        Public Sub Test_Bukiika_Standard_Sample_Calculation()
            ' Arrange
            Dim teamMembers As Integer = 7
            Dim dayRate As Decimal = 30000D
            Dim days As Decimal = 2D
            Dim supplies As Decimal = 100000D
            Dim transport As Decimal = 200000D
            Dim equipWear As Decimal = 15000D
            Dim monthlyOverhead As Decimal = 100000D
            Dim avgJobs As Integer = 8
            Dim targetMargin As Decimal = 0.35D
            Dim actualQuote As Decimal = 1200000D

            ' Act
            Dim calc As PricingCalculation = PricingEngine.ExecuteCalculation(
                teamMembers, dayRate, days, supplies, transport, equipWear,
                monthlyOverhead, avgJobs, targetMargin, actualQuote
            )

            ' Assert: Direct workbook values
            Assert.That(calc.LaborCost, [Is].EqualTo(420000D), "Labor cost must equal 420,000")
            Assert.That(calc.OverheadAllocation, [Is].EqualTo(12500D), "Overhead allocation must equal 12,500")
            Assert.That(calc.TotalCost, [Is].EqualTo(747500D), "Total cost must equal 747,500")
            Assert.That(calc.SuggestedPrice, [Is].EqualTo(1150000D), "Suggested price must equal 1,150,000")
            Assert.That(calc.ProfitAtSuggested, [Is].EqualTo(402500D), "Profit at suggested price must equal 402,500")

            ' Labor percentage = 420,000 / 1,150,000 = 0.365217... ≈ 36.5%
            Assert.That(Math.Round(calc.LaborPercent * 100D, 1), [Is].EqualTo(36.5D), "Labor % should be approx 36.5%")
            Assert.That(PricingEngine.IsLaborPercentOutsideReferenceBand(calc.LaborPercent), [Is].True, "Labor % (36.5%) should trigger reference warning (< 45%)")

            ' Actual quote checks
            Assert.That(calc.ActualProfit, [Is].EqualTo(452500D), "Actual profit must equal 452,500")
            Assert.That(Math.Round(calc.ActualMargin * 100D, 1), [Is].EqualTo(37.7D), "Actual margin should be approx 37.7%")
            Assert.That(calc.Verdict, [Is].EqualTo("HEALTHY MARGIN"), "Verdict must be HEALTHY MARGIN")
        End Sub

        <Test>
        Public Sub Test_Zero_TeamMembers_Yields_Zero_LaborCost()
            Dim laborCost As Decimal = PricingEngine.CalculateLaborCost(0, 30000D, 2D)
            Assert.That(laborCost, [Is].EqualTo(0D))
        End Sub

        <Test>
        Public Sub Test_Zero_AvgJobsPerMonth_DoesNotThrowDivideByZero()
            Dim overhead As Decimal = PricingEngine.CalculateOverheadAllocation(100000D, 0)
            Assert.That(overhead, [Is].EqualTo(0D))
        End Sub

        <Test>
        Public Sub Test_Zero_TargetMargin_SuggestedPrice_Equals_TotalCost()
            Dim totalCost As Decimal = 500000D
            Dim suggestedPrice As Decimal = PricingEngine.CalculateSuggestedPrice(totalCost, 0D)
            Dim profit As Decimal = PricingEngine.CalculateProfitAtSuggested(suggestedPrice, totalCost)

            Assert.That(suggestedPrice, [Is].EqualTo(500000D))
            Assert.That(profit, [Is].EqualTo(0D))
        End Sub

        <Test>
        Public Sub Test_TargetMargin_At_Or_Above_100Percent_Throws_Exception()
            Assert.Throws(Of ArgumentOutOfRangeException)(
                Sub()
                    PricingEngine.CalculateSuggestedPrice(500000D, 1.0D)
                End Sub
            )

            Assert.Throws(Of ArgumentOutOfRangeException)(
                Sub()
                    PricingEngine.CalculateSuggestedPrice(500000D, 1.25D)
                End Sub
            )
        End Sub

        <Test>
        Public Sub Test_Negative_Inputs_Throw_Exception()
            Assert.Throws(Of ArgumentOutOfRangeException)(
                Sub()
                    PricingEngine.CalculateLaborCost(-1, 30000D, 1D)
                End Sub
            )

            Assert.Throws(Of ArgumentOutOfRangeException)(
                Sub()
                    PricingEngine.CalculateTotalCost(-500D, 0D, 0D, 0D, 0D)
                End Sub
            )
        End Sub

        <Test>
        Public Sub Test_Actual_Quote_Below_Cost_Generates_Negative_Profit_And_Survival_Verdict()
            Dim totalCost As Decimal = 747500D
            Dim actualQuote As Decimal = 600000D ' Loss of 147,500

            Dim profit As Decimal = PricingEngine.CalculateActualProfit(actualQuote, totalCost)
            Dim margin As Decimal = PricingEngine.CalculateActualMargin(actualQuote, totalCost)
            Dim verdict As String = PricingEngine.DetermineVerdict(margin)

            Assert.That(profit, [Is].EqualTo(-147500D))
            Assert.That(margin, [Is].LessThan(0D))
            Assert.That(verdict, [Is].EqualTo("BELOW SURVIVAL FLOOR - reprice"))
        End Sub

        <Test>
        Public Sub Test_Actual_Quote_Equal_To_Cost_Generates_Zero_Profit_And_Survival_Verdict()
            Dim totalCost As Decimal = 747500D
            Dim actualQuote As Decimal = 747500D

            Dim profit As Decimal = PricingEngine.CalculateActualProfit(actualQuote, totalCost)
            Dim margin As Decimal = PricingEngine.CalculateActualMargin(actualQuote, totalCost)
            Dim verdict As String = PricingEngine.DetermineVerdict(margin)

            Assert.That(profit, [Is].EqualTo(0D))
            Assert.That(margin, [Is].EqualTo(0D))
            Assert.That(verdict, [Is].EqualTo("BELOW SURVIVAL FLOOR - reprice"))
        End Sub

        <Test>
        Public Sub Test_Thin_Margin_Verdict_Between_10_And_20_Percent()
            Dim verdict15 As String = PricingEngine.DetermineVerdict(0.15D)
            Assert.That(verdict15, [Is].EqualTo("OK, BUT THIN - push toward target"))
        End Sub

        <Test>
        Public Sub Test_High_Margin_Verdict_Above_45_Percent()
            Dim verdict50 As String = PricingEngine.DetermineVerdict(0.50D)
            Assert.That(verdict50, [Is].EqualTo("CHECK - unusually high, verify costs"))
        End Sub

        <Test>
        Public Sub Test_Currency_Formatting_UGX()
            Dim formatted As String = CurrencyFormatter.FormatUgx(1150000D)
            Assert.That(formatted, [Is].EqualTo("UGX 1,150,000"))

            Dim parsed As Decimal = CurrencyFormatter.ParseCurrency("UGX 1,150,000")
            Assert.That(parsed, [Is].EqualTo(1150000D))
        End Sub
    End Class
End Namespace
