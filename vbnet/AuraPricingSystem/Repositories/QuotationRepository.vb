Imports Microsoft.Data.Sqlite
Imports AuraPricingSystem.Data
Imports AuraPricingSystem.Models

Namespace Repositories
    ''' <summary>
    ''' Data repository for Quotes (Module 7) and Pricing Snapshots (Module 6).
    ''' Enforces atomic transactions and ensures historical quotation immutability.
    ''' </summary>
    Public Class QuotationRepository
        ''' <summary>
        ''' Saves a quotation and its immutable calculation snapshot within an atomic transaction.
        ''' </summary>
        Public Function SaveQuotationWithCalculation(quote As Quotation, calc As PricingCalculation) As Boolean
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Using trans As SqliteTransaction = conn.BeginTransaction()
                    Try
                        ' 1. Insert Quotation Header
                        Dim quoteSql As String = "
                            INSERT INTO Quotations (QuoteNo, ClientID, ServiceID, JobName, JobType, QuoteDate, TotalAmount, Status, CreatedByUserID)
                            VALUES (@no, @cid, @sid, @jname, @jtype, @qdate, @total, @status, @uid);"

                        Dim quoteId As Integer
                        Using cmdQuote As New SqliteCommand(quoteSql, conn, trans)
                            cmdQuote.Parameters.AddWithValue("@no", quote.QuoteNo)
                            cmdQuote.Parameters.AddWithValue("@cid", quote.ClientID)
                            cmdQuote.Parameters.AddWithValue("@sid", quote.ServiceID)
                            cmdQuote.Parameters.AddWithValue("@jname", quote.JobName)
                            cmdQuote.Parameters.AddWithValue("@jtype", quote.JobType)
                            cmdQuote.Parameters.AddWithValue("@qdate", quote.QuoteDate.ToString("yyyy-MM-dd"))
                            cmdQuote.Parameters.AddWithValue("@total", Convert.ToInt64(quote.TotalAmount))
                            cmdQuote.Parameters.AddWithValue("@status", quote.Status)
                            cmdQuote.Parameters.AddWithValue("@uid", quote.CreatedByUserID)
                            cmdQuote.ExecuteNonQuery()
                        End Using

                        Using cmdId As New SqliteCommand("SELECT last_insert_rowid();", conn, trans)
                            quoteId = Convert.ToInt32(cmdId.ExecuteScalar())
                            quote.QuotationID = quoteId
                        End Using

                        ' 2. Insert Immutable Pricing Calculation Snapshot
                        Dim calcSql As String = "
                            INSERT INTO PricingCalculations (
                                QuotationID, TeamMembers, DayRate, Days, SuppliesCost, TransportCost,
                                EquipmentWear, MonthlyOverhead, AvgJobsPerMonth, TargetMargin,
                                LaborCost, OverheadAllocation, TotalCost, SuggestedPrice, ProfitAtSuggested,
                                LaborPercent, ActualQuote, ActualProfit, ActualMargin, Verdict
                            ) VALUES (
                                @qid, @tm, @dr, @days, @sup, @trans,
                                @wear, @ovh, @avgj, @tmargin,
                                @lcost, @ovhalloc, @tcost, @sugprice, @profitsug,
                                @lpercent, @actquote, @actprofit, @actmargin, @verdict
                            );"

                        Using cmdCalc As New SqliteCommand(calcSql, conn, trans)
                            cmdCalc.Parameters.AddWithValue("@qid", quoteId)
                            cmdCalc.Parameters.AddWithValue("@tm", calc.TeamMembers)
                            cmdCalc.Parameters.AddWithValue("@dr", Convert.ToInt64(calc.DayRate))
                            cmdCalc.Parameters.AddWithValue("@days", Convert.ToDouble(calc.Days))
                            cmdCalc.Parameters.AddWithValue("@sup", Convert.ToInt64(calc.SuppliesCost))
                            cmdCalc.Parameters.AddWithValue("@trans", Convert.ToInt64(calc.TransportCost))
                            cmdCalc.Parameters.AddWithValue("@wear", Convert.ToInt64(calc.EquipmentWear))
                            cmdCalc.Parameters.AddWithValue("@ovh", Convert.ToInt64(calc.MonthlyOverhead))
                            cmdCalc.Parameters.AddWithValue("@avgj", calc.AvgJobsPerMonth)
                            cmdCalc.Parameters.AddWithValue("@tmargin", Convert.ToDouble(calc.TargetMargin))
                            cmdCalc.Parameters.AddWithValue("@lcost", Convert.ToInt64(calc.LaborCost))
                            cmdCalc.Parameters.AddWithValue("@ovhalloc", Convert.ToInt64(calc.OverheadAllocation))
                            cmdCalc.Parameters.AddWithValue("@tcost", Convert.ToInt64(calc.TotalCost))
                            cmdCalc.Parameters.AddWithValue("@sugprice", Convert.ToInt64(calc.SuggestedPrice))
                            cmdCalc.Parameters.AddWithValue("@profitsug", Convert.ToInt64(calc.ProfitAtSuggested))
                            cmdCalc.Parameters.AddWithValue("@lpercent", Convert.ToDouble(calc.LaborPercent))
                            cmdCalc.Parameters.AddWithValue("@actquote", Convert.ToInt64(calc.ActualQuote))
                            cmdCalc.Parameters.AddWithValue("@actprofit", Convert.ToInt64(calc.ActualProfit))
                            cmdCalc.Parameters.AddWithValue("@actmargin", Convert.ToDouble(calc.ActualMargin))
                            cmdCalc.Parameters.AddWithValue("@verdict", calc.Verdict)
                            cmdCalc.ExecuteNonQuery()
                        End Using

                        trans.Commit()
                        Return True
                    Catch ex As Exception
                        trans.Rollback()
                        Throw New InvalidOperationException($"Failed to save quotation and calculation: {ex.Message}", ex)
                    End Try
                End Using
            End Using
        End Function

        Public Function GetNextQuoteNo(prefix As String) As String
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "SELECT MAX(QuotationID) FROM Quotations;"
                Using cmd As New SqliteCommand(sql, conn)
                    Dim result As Object = cmd.ExecuteScalar()
                    Dim nextId As Integer = 1
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        nextId = Convert.ToInt32(result) + 1
                    End If
                    Return $"{prefix}{nextId:D4}"
                End Using
            End Using
        End Function

        Public Function GetAllQuotations(Optional statusFilter As String = "All", Optional search As String = "") As List(Of Quotation)
            Dim list As New List(Of Quotation)
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "
                    SELECT q.QuotationID, q.QuoteNo, q.ClientID, q.ServiceID, q.JobName, q.JobType,
                           q.QuoteDate, q.TotalAmount, q.Status, q.CreatedByUserID, q.CreatedAt,
                           c.FullName AS ClientName, s.ServiceName, u.Username
                    FROM Quotations q
                    INNER JOIN Clients c ON q.ClientID = c.ClientID
                    INNER JOIN Services s ON q.ServiceID = s.ServiceID
                    INNER JOIN Users u ON q.CreatedByUserID = u.UserID
                    WHERE 1=1 "

                If Not String.IsNullOrEmpty(statusFilter) AndAlso Not statusFilter.Equals("All", StringComparison.OrdinalIgnoreCase) Then
                    sql &= " AND q.Status = @status "
                End If

                If Not String.IsNullOrWhiteSpace(search) Then
                    sql &= " AND (q.QuoteNo LIKE @search OR c.FullName LIKE @search OR s.ServiceName LIKE @search OR q.JobName LIKE @search) "
                End If

                sql &= " ORDER BY q.QuotationID DESC;"

                Using cmd As New SqliteCommand(sql, conn)
                    If Not String.IsNullOrEmpty(statusFilter) AndAlso Not statusFilter.Equals("All", StringComparison.OrdinalIgnoreCase) Then
                        cmd.Parameters.AddWithValue("@status", statusFilter)
                    End If
                    If Not String.IsNullOrWhiteSpace(search) Then
                        cmd.Parameters.AddWithValue("@search", $"%{search}%")
                    End If

                    Using reader As SqliteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            list.Add(MapQuotation(reader))
                        End While
                    End Using
                End Using
            End Using
            Return list
        End Function

        Public Function GetQuotationWithCalculation(quotationId As Integer) As Quotation
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "
                    SELECT q.QuotationID, q.QuoteNo, q.ClientID, q.ServiceID, q.JobName, q.JobType,
                           q.QuoteDate, q.TotalAmount, q.Status, q.CreatedByUserID, q.CreatedAt,
                           c.FullName AS ClientName, s.ServiceName, u.Username
                    FROM Quotations q
                    INNER JOIN Clients c ON q.ClientID = c.ClientID
                    INNER JOIN Services s ON q.ServiceID = s.ServiceID
                    INNER JOIN Users u ON q.CreatedByUserID = u.UserID
                    WHERE q.QuotationID = @id LIMIT 1;"

                Dim quote As Quotation = Nothing
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", quotationId)
                    Using reader As SqliteDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            quote = MapQuotation(reader)
                        End If
                    End Using
                End Using

                If quote IsNot Nothing Then
                    quote.Calculation = GetCalculationForQuotation(quotationId, conn)
                End If

                Return quote
            End Using
        End Function

        Public Function UpdateStatus(quotationId As Integer, newStatus As String) As Boolean
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "UPDATE Quotations SET Status = @status WHERE QuotationID = @id;"
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@status", newStatus)
                    cmd.Parameters.AddWithValue("@id", quotationId)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function

        Private Function GetCalculationForQuotation(quotationId As Integer, conn As SqliteConnection) As PricingCalculation
            Dim sql As String = "
                SELECT CalculationID, QuotationID, TeamMembers, DayRate, Days, SuppliesCost, TransportCost,
                       EquipmentWear, MonthlyOverhead, AvgJobsPerMonth, TargetMargin, LaborCost, OverheadAllocation,
                       TotalCost, SuggestedPrice, ProfitAtSuggested, LaborPercent, ActualQuote, ActualProfit,
                       ActualMargin, Verdict
                FROM PricingCalculations WHERE QuotationID = @qid LIMIT 1;"

            Using cmd As New SqliteCommand(sql, conn)
                cmd.Parameters.AddWithValue("@qid", quotationId)
                Using reader As SqliteDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Return New PricingCalculation With {
                            .CalculationID = reader.GetInt32(0),
                            .QuotationID = reader.GetInt32(1),
                            .TeamMembers = reader.GetInt32(2),
                            .DayRate = Convert.ToDecimal(reader.GetInt64(3)),
                            .Days = Convert.ToDecimal(reader.GetDouble(4)),
                            .SuppliesCost = Convert.ToDecimal(reader.GetInt64(5)),
                            .TransportCost = Convert.ToDecimal(reader.GetInt64(6)),
                            .EquipmentWear = Convert.ToDecimal(reader.GetInt64(7)),
                            .MonthlyOverhead = Convert.ToDecimal(reader.GetInt64(8)),
                            .AvgJobsPerMonth = reader.GetInt32(9),
                            .TargetMargin = Convert.ToDecimal(reader.GetDouble(10)),
                            .LaborCost = Convert.ToDecimal(reader.GetInt64(11)),
                            .OverheadAllocation = Convert.ToDecimal(reader.GetInt64(12)),
                            .TotalCost = Convert.ToDecimal(reader.GetInt64(13)),
                            .SuggestedPrice = Convert.ToDecimal(reader.GetInt64(14)),
                            .ProfitAtSuggested = Convert.ToDecimal(reader.GetInt64(15)),
                            .LaborPercent = Convert.ToDecimal(reader.GetDouble(16)),
                            .ActualQuote = Convert.ToDecimal(reader.GetInt64(17)),
                            .ActualProfit = Convert.ToDecimal(reader.GetInt64(18)),
                            .ActualMargin = Convert.ToDecimal(reader.GetDouble(19)),
                            .Verdict = reader.GetString(20)
                        }
                    End If
                End Using
            End Using
            Return Nothing
        End Function

        Private Function MapQuotation(reader As SqliteDataReader) As Quotation
            Return New Quotation With {
                .QuotationID = reader.GetInt32(0),
                .QuoteNo = reader.GetString(1),
                .ClientID = reader.GetInt32(2),
                .ServiceID = reader.GetInt32(3),
                .JobName = reader.GetString(4),
                .JobType = reader.GetString(5),
                .QuoteDate = DateTime.Parse(reader.GetString(6)),
                .TotalAmount = Convert.ToDecimal(reader.GetInt64(7)),
                .Status = reader.GetString(8),
                .CreatedByUserID = reader.GetInt32(9),
                .CreatedAt = DateTime.Parse(reader.GetString(10)),
                .ClientName = reader.GetString(11),
                .ServiceName = reader.GetString(12),
                .CreatedByUsername = reader.GetString(13)
            }
        End Function
    End Class
End Namespace
