Imports Microsoft.Data.Sqlite
Imports AuraPricingSystem.Data
Imports AuraPricingSystem.Models
Imports System.Data

Namespace Services
    ''' <summary>
    ''' Financial summary metrics model for business reporting.
    ''' </summary>
    Public Class FinancialReportSummary
        Public Property TotalQuotesCount As Integer
        Public Property AcceptedQuotesCount As Integer
        Public Property TotalQuotedAmount As Decimal
        Public Property TotalAcceptedRevenue As Decimal
        Public Property AverageGrossMargin As Decimal
        Public Property TotalJobsCount As Integer
        Public Property CompletedJobsCount As Integer
        Public Property CategoryBreakdown As List(Of CategorySummaryItem)

        Public Sub New()
            CategoryBreakdown = New List(Of CategorySummaryItem)()
        End Sub
    End Class

    Public Class CategorySummaryItem
        Public Property JobType As String
        Public Property QuotesCount As Integer
        Public Property TotalRevenue As Decimal
        Public Property AverageMargin As Decimal
    End Class

    ''' <summary>
    ''' Service layer for Module 10 (Reports & Analytics).
    ''' Computes scalar database aggregations for executive decision-making.
    ''' </summary>
    Public Class ReportService
        Public Function GetFinancialSummary(startDate As DateTime, endDate As DateTime) As FinancialReportSummary
            Dim summary As New FinancialReportSummary()

            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                ' 1. Quotations Aggregation
                Dim sqlQuotes As String = "
                    SELECT 
                        COUNT(*),
                        TOTAL(CASE WHEN Status = 'Accepted' THEN TotalAmount ELSE 0 END),
                        TOTAL(TotalAmount),
                        COUNT(CASE WHEN Status = 'Accepted' THEN 1 END)
                    FROM Quotations
                    WHERE date(QuoteDate) >= date(@start) AND date(QuoteDate) <= date(@end);"

                Using cmd As New SqliteCommand(sqlQuotes, conn)
                    cmd.Parameters.AddWithValue("@start", startDate.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@end", endDate.ToString("yyyy-MM-dd"))
                    Using reader As SqliteDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            summary.TotalQuotesCount = reader.GetInt32(0)
                            summary.TotalAcceptedRevenue = Convert.ToDecimal(reader.GetDouble(1))
                            summary.TotalQuotedAmount = Convert.ToDecimal(reader.GetDouble(2))
                            summary.AcceptedQuotesCount = reader.GetInt32(3)
                        End If
                    End Using
                End Using

                ' 2. Average Realized Margin from PricingCalculations
                Dim sqlMargin As String = "
                    SELECT AVG(pc.ActualMargin)
                    FROM PricingCalculations pc
                    INNER JOIN Quotations q ON pc.QuotationID = q.QuotationID
                    WHERE q.Status = 'Accepted' AND date(q.QuoteDate) >= date(@start) AND date(q.QuoteDate) <= date(@end);"

                Using cmdMargin As New SqliteCommand(sqlMargin, conn)
                    cmdMargin.Parameters.AddWithValue("@start", startDate.ToString("yyyy-MM-dd"))
                    cmdMargin.Parameters.AddWithValue("@end", endDate.ToString("yyyy-MM-dd"))
                    Dim result = cmdMargin.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        summary.AverageGrossMargin = Convert.ToDecimal(Convert.ToDouble(result))
                    Else
                        summary.AverageGrossMargin = 0.35D ' Default baseline
                    End If
                End Using

                ' 3. Jobs Aggregation
                Dim sqlJobs As String = "
                    SELECT 
                        COUNT(*),
                        COUNT(CASE WHEN Status = 'Completed' THEN 1 END)
                    FROM Jobs
                    WHERE date(JobDate) >= date(@start) AND date(JobDate) <= date(@end);"

                Using cmdJobs As New SqliteCommand(sqlJobs, conn)
                    cmdJobs.Parameters.AddWithValue("@start", startDate.ToString("yyyy-MM-dd"))
                    cmdJobs.Parameters.AddWithValue("@end", endDate.ToString("yyyy-MM-dd"))
                    Using reader As SqliteDataReader = cmdJobs.ExecuteReader()
                        If reader.Read() Then
                            summary.TotalJobsCount = reader.GetInt32(0)
                            summary.CompletedJobsCount = reader.GetInt32(1)
                        End If
                    End Using
                End Using

                ' 4. Breakdown by Job Type
                Dim sqlCategory As String = "
                    SELECT 
                        q.JobType,
                        COUNT(q.QuotationID),
                        TOTAL(CASE WHEN q.Status = 'Accepted' THEN q.TotalAmount ELSE 0 END),
                        AVG(pc.ActualMargin)
                    FROM Quotations q
                    LEFT JOIN PricingCalculations pc ON q.QuotationID = pc.QuotationID
                    WHERE date(q.QuoteDate) >= date(@start) AND date(q.QuoteDate) <= date(@end)
                    GROUP BY q.JobType
                    ORDER BY TOTAL(q.TotalAmount) DESC;"

                Using cmdCat As New SqliteCommand(sqlCategory, conn)
                    cmdCat.Parameters.AddWithValue("@start", startDate.ToString("yyyy-MM-dd"))
                    cmdCat.Parameters.AddWithValue("@end", endDate.ToString("yyyy-MM-dd"))
                    Using reader As SqliteDataReader = cmdCat.ExecuteReader()
                        While reader.Read()
                            Dim item As New CategorySummaryItem With {
                                .JobType = reader.GetString(0),
                                .QuotesCount = reader.GetInt32(1),
                                .TotalRevenue = Convert.ToDecimal(reader.GetDouble(2)),
                                .AverageMargin = If(reader.IsDBNull(3), 0.30D, Convert.ToDecimal(reader.GetDouble(3)))
                            }
                            summary.CategoryBreakdown.Add(item)
                        End While
                    End Using
                End Using
            End Using

            Return summary
        End Function
    End Class
End Namespace
