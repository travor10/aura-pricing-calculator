Imports System.Globalization

Namespace Helpers
    ''' <summary>
    ''' Financial formatting helper for Uganda Shillings (UGX).
    ''' Enforces standard thousand separators and currency symbol display.
    ''' </summary>
    Public NotInheritable Class CurrencyFormatter
        Private Sub New()
        End Sub

        Private Shared ReadOnly UgxCulture As CultureInfo = New CultureInfo("en-UG")

        ''' <summary>
        ''' Formats an integer or decimal amount with thousand separators: e.g. "1,150,000".
        ''' </summary>
        Public Shared Function FormatNumber(amount As Decimal) As String
            Return amount.ToString("N0", CultureInfo.InvariantCulture)
        End Function

        ''' <summary>
        ''' Formats an amount with currency prefix: e.g. "UGX 1,150,000".
        ''' </summary>
        Public Shared Function FormatUgx(amount As Decimal) As String
            Return $"UGX {FormatNumber(amount)}"
        End Function

        ''' <summary>
        ''' Formats a ratio as percentage: e.g. 0.35 -> "35.0%".
        ''' </summary>
        Public Shared Function FormatPercent(ratio As Decimal, Optional decimalPlaces As Integer = 1) As String
            Return (ratio * 100D).ToString($"F{decimalPlaces}", CultureInfo.InvariantCulture) & "%"
        End Function

        ''' <summary>
        ''' Parses a user-input currency string (handling commas and spaces) safely into Decimal.
        ''' </summary>
        Public Shared Function ParseCurrency(input As String) As Decimal
            If String.IsNullOrWhiteSpace(input) Then Return 0D

            Dim cleaned As String = input.Replace("UGX", "", StringComparison.OrdinalIgnoreCase).
                                          Replace(",", "").
                                          Replace(" ", "").
                                          Trim()

            Dim result As Decimal
            If Decimal.TryParse(cleaned, NumberStyles.Any, CultureInfo.InvariantCulture, result) Then
                Return result
            End If
            Return 0D
        End Function
    End Class
End Namespace
