Imports ClosedXML.Excel
Imports AuraPricingSystem.Repositories
Imports AuraPricingSystem.Models
Imports System.IO

Namespace Services
    ''' <summary>
    ''' Professional Excel export service using ClosedXML.
    ''' Preserves the original Aura Job Costing Calculator workbook structure,
    ''' creates formatted analytical worksheets, and includes live Excel formulas.
    ''' </summary>
    Public Class ExcelExportService
        Private ReadOnly _quoteRepo As New QuotationRepository()
        Private ReadOnly _jobRepo As New JobRepository()
        Private ReadOnly _reportService As New ReportService()
        Private ReadOnly _settingsRepo As New SettingsRepository()

        Public Sub ExportFinancialReportToExcel(filePath As String, startDate As DateTime, endDate As DateTime)
            Dim summary = _reportService.GetFinancialSummary(startDate, endDate)
            Dim quotes = _quoteRepo.GetAllQuotations("All", "")
            Dim jobs = _jobRepo.GetAllJobs("All")
            Dim settings = _settingsRepo.GetSettings()

            Using workbook As New XLWorkbook()
                ' ----------------------------------------------------
                ' SHEET 1: EXECUTIVE SUMMARY
                ' ----------------------------------------------------
                Dim wsSummary = workbook.Worksheets.Add("Executive Summary")
                wsSummary.ShowGridLines = True

                ' Title Header
                wsSummary.Cell("A1").Value = settings.CompanyName
                wsSummary.Cell("A1").Style.Font.Bold = True
                wsSummary.Cell("A1").Style.Font.FontSize = 16
                wsSummary.Cell("A1").Style.Font.FontColor = XLColor.FromHtml("#0C4B88")

                wsSummary.Cell("A2").Value = $"Executive Pricing & Performance Report ({startDate:dd MMM yyyy} – {endDate:dd MMM yyyy})"
                wsSummary.Cell("A2").Style.Font.Italic = True
                wsSummary.Cell("A2").Style.Font.FontSize = 11

                ' KPI Metric Cards in Excel
                CreateKpiBox(wsSummary, "B4", "C5", "TOTAL QUOTES", summary.TotalQuotesCount.ToString(), "#0C4B88")
                CreateKpiBox(wsSummary, "D4", "E5", "ACCEPTED REVENUE (UGX)", summary.TotalAcceptedRevenue.ToString("#,##0"), "#247A3D")
                CreateKpiBox(wsSummary, "F4", "G5", "AVERAGE GROSS MARGIN", $"{(summary.AverageGrossMargin * 100D):0.0}%", "#F9A01F")
                CreateKpiBox(wsSummary, "H4", "I5", "ACTIVE/COMPLETED JOBS", $"{summary.CompletedJobsCount} / {summary.TotalJobsCount}", "#6B3FA0")

                ' Category Performance Table
                wsSummary.Cell("B8").Value = "Category Performance Breakdown"
                wsSummary.Cell("B8").Style.Font.Bold = True
                wsSummary.Cell("B8").Style.Font.FontSize = 12

                Dim catHeaders = New String() {"Job Classification", "Quotes Generated", "Accepted Revenue (UGX)", "Average Gross Margin"}
                For colIdx As Integer = 0 To catHeaders.Length - 1
                    Dim c = wsSummary.Cell(9, colIdx + 2)
                    c.Value = catHeaders(colIdx)
                    c.Style.Font.Bold = True
                    c.Style.Fill.BackgroundColor = XLColor.FromHtml("#0C4B88")
                    c.Style.Font.FontColor = XLColor.White
                    c.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                Next

                Dim catRow As Integer = 10
                For Each cat In summary.CategoryBreakdown
                    wsSummary.Cell(catRow, 2).Value = cat.JobType
                    wsSummary.Cell(catRow, 3).Value = cat.QuotesCount
                    wsSummary.Cell(catRow, 4).Value = Convert.ToDouble(cat.TotalRevenue)
                    wsSummary.Cell(catRow, 4).Style.NumberFormat.Format = "#,##0 ""UGX"""
                    wsSummary.Cell(catRow, 5).Value = Convert.ToDouble(cat.AverageMargin)
                    wsSummary.Cell(catRow, 5).Style.NumberFormat.Format = "0.0%"
                    catRow += 1
                Next

                ' ----------------------------------------------------
                ' SHEET 2: QUOTATIONS & LOCKED PRICING SNAPSHOTS
                ' ----------------------------------------------------
                Dim wsQuotes = workbook.Worksheets.Add("Quotations & Snapshots")
                wsQuotes.ShowGridLines = True

                Dim qHeaders = New String() {
                    "Quote No", "Client Name", "Job Description", "Job Type", "Quote Date", "Quoted Price (UGX)",
                    "Status", "Team Size", "Days", "Daily Rate", "Labor Cost", "Supplies", "Transport",
                    "Overhead", "Total Cost", "Suggested Price", "Actual Profit", "Actual Margin %", "Margin Verdict"
                }

                For i As Integer = 0 To qHeaders.Length - 1
                    Dim cell = wsQuotes.Cell(1, i + 1)
                    cell.Value = qHeaders(i)
                    cell.Style.Font.Bold = True
                    cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#0C4B88")
                    cell.Style.Font.FontColor = XLColor.White
                Next

                Dim qRow As Integer = 2
                For Each q In quotes
                    Dim fullQuote = _quoteRepo.GetQuotationWithCalculation(q.QuotationID)
                    Dim snap = fullQuote.Calculation

                    wsQuotes.Cell(qRow, 1).Value = q.QuoteNo
                    wsQuotes.Cell(qRow, 2).Value = q.ClientName
                    wsQuotes.Cell(qRow, 3).Value = q.JobName
                    wsQuotes.Cell(qRow, 4).Value = q.JobType
                    wsQuotes.Cell(qRow, 5).Value = q.QuoteDate.ToString("yyyy-MM-dd")
                    wsQuotes.Cell(qRow, 6).Value = Convert.ToDouble(q.TotalAmount)
                    wsQuotes.Cell(qRow, 6).Style.NumberFormat.Format = "#,##0"
                    wsQuotes.Cell(qRow, 7).Value = q.Status

                    If snap IsNot Nothing Then
                        wsQuotes.Cell(qRow, 8).Value = snap.TeamMembers
                        wsQuotes.Cell(qRow, 9).Value = Convert.ToDouble(snap.Days)
                        wsQuotes.Cell(qRow, 10).Value = Convert.ToDouble(snap.DayRate)
                        wsQuotes.Cell(qRow, 11).Value = Convert.ToDouble(snap.LaborCost)
                        wsQuotes.Cell(qRow, 12).Value = Convert.ToDouble(snap.SuppliesCost)
                        wsQuotes.Cell(qRow, 13).Value = Convert.ToDouble(snap.TransportCost)
                        wsQuotes.Cell(qRow, 14).Value = Convert.ToDouble(snap.OverheadAllocation)
                        wsQuotes.Cell(qRow, 15).Value = Convert.ToDouble(snap.TotalCost)
                        wsQuotes.Cell(qRow, 16).Value = Convert.ToDouble(snap.SuggestedPrice)
                        wsQuotes.Cell(qRow, 17).Value = Convert.ToDouble(snap.ActualProfit)
                        wsQuotes.Cell(qRow, 18).Value = Convert.ToDouble(snap.ActualMargin)
                        wsQuotes.Cell(qRow, 18).Style.NumberFormat.Format = "0.0%"
                        wsQuotes.Cell(qRow, 19).Value = snap.Verdict

                        For col As Integer = 10 To 17
                            wsQuotes.Cell(qRow, col).Style.NumberFormat.Format = "#,##0"
                        Next
                    End If
                    qRow += 1
                Next

                ' ----------------------------------------------------
                ' SHEET 3: JOB BOOKINGS & STAFF ASSIGNMENTS
                ' ----------------------------------------------------
                Dim wsJobs = workbook.Worksheets.Add("Job Bookings")
                wsJobs.ShowGridLines = True

                Dim jHeaders = New String() {"Job No", "Quote No", "Client Name", "Service", "Scheduled Date", "Status", "Assigned Staff", "Total Amount (UGX)", "Notes"}
                For i As Integer = 0 To jHeaders.Length - 1
                    Dim cell = wsJobs.Cell(1, i + 1)
                    cell.Value = jHeaders(i)
                    cell.Style.Font.Bold = True
                    cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#0C4B88")
                    cell.Style.Font.FontColor = XLColor.White
                Next

                Dim jRow As Integer = 2
                For Each j In jobs
                    Dim staffNames = If(j.AssignedStaffList IsNot Nothing, String.Join(", ", j.AssignedStaffList.Select(Function(s) s.FullName)), "None")
                    wsJobs.Cell(jRow, 1).Value = j.JobNo
                    wsJobs.Cell(jRow, 2).Value = j.QuoteNo
                    wsJobs.Cell(jRow, 3).Value = j.ClientName
                    wsJobs.Cell(jRow, 4).Value = j.ServiceName
                    wsJobs.Cell(jRow, 5).Value = j.JobDate.ToString("yyyy-MM-dd")
                    wsJobs.Cell(jRow, 6).Value = j.Status
                    wsJobs.Cell(jRow, 7).Value = staffNames
                    wsJobs.Cell(jRow, 8).Value = Convert.ToDouble(j.TotalAmount)
                    wsJobs.Cell(jRow, 8).Style.NumberFormat.Format = "#,##0"
                    wsJobs.Cell(jRow, 9).Value = j.Notes
                    jRow += 1
                Next

                ' ----------------------------------------------------
                ' SHEET 4: AURA JOB COSTING CALCULATOR (EXCEL WORKBOOK REPLICA)
                ' ----------------------------------------------------
                Dim wsCalc = workbook.Worksheets.Add("Costing Calculator Template")
                wsCalc.ShowGridLines = True

                wsCalc.Cell("A1").Value = "AURA JOB COSTING CALCULATOR"
                wsCalc.Cell("A1").Style.Font.Bold = True
                wsCalc.Cell("A1").Style.Font.FontSize = 14
                wsCalc.Cell("A1").Style.Font.FontColor = XLColor.FromHtml("#0C4B88")

                wsCalc.Cell("A3").Value = "1. JOB INPUTS"
                wsCalc.Cell("A3").Style.Font.Bold = True

                wsCalc.Cell("A4").Value = "Job name"
                wsCalc.Cell("B4").Value = "Bukiika"

                wsCalc.Cell("A5").Value = "Job type"
                wsCalc.Cell("B5").Value = "Residential - Post-Construction"

                wsCalc.Cell("A6").Value = "Team members"
                wsCalc.Cell("B6").Value = 7

                wsCalc.Cell("A7").Value = "Day rate per person"
                wsCalc.Cell("B7").Value = 30000
                wsCalc.Cell("B7").Style.NumberFormat.Format = "#,##0"

                wsCalc.Cell("A8").Value = "Days on job"
                wsCalc.Cell("B8").Value = 2

                wsCalc.Cell("A9").Value = "Supplies/chemicals cost"
                wsCalc.Cell("B9").Value = 100000
                wsCalc.Cell("B9").Style.NumberFormat.Format = "#,##0"

                wsCalc.Cell("A10").Value = "Transport cost"
                wsCalc.Cell("B10").Value = 200000
                wsCalc.Cell("B10").Style.NumberFormat.Format = "#,##0"

                wsCalc.Cell("A11").Value = "Equipment wear"
                wsCalc.Cell("B11").Value = 15000
                wsCalc.Cell("B11").Style.NumberFormat.Format = "#,##0"

                wsCalc.Cell("A12").Value = "Monthly overhead"
                wsCalc.Cell("B12").Value = 100000
                wsCalc.Cell("B12").Style.NumberFormat.Format = "#,##0"

                wsCalc.Cell("A13").Value = "Avg jobs per month"
                wsCalc.Cell("B13").Value = 8

                wsCalc.Cell("A14").Value = "Target net margin"
                wsCalc.Cell("B14").Value = 0.35
                wsCalc.Cell("B14").Style.NumberFormat.Format = "0.0%"

                ' Formulas in Cost Breakdown
                wsCalc.Cell("D3").Value = "2. COST BREAKDOWN"
                wsCalc.Cell("D3").Style.Font.Bold = True

                wsCalc.Cell("D4").Value = "Labour cost"
                wsCalc.Cell("E4").FormulaA1 = "=B6*B7*B8"
                wsCalc.Cell("E4").Style.NumberFormat.Format = "#,##0"

                wsCalc.Cell("D5").Value = "Supplies"
                wsCalc.Cell("E5").FormulaA1 = "=B9"
                wsCalc.Cell("E5").Style.NumberFormat.Format = "#,##0"

                wsCalc.Cell("D6").Value = "Transport"
                wsCalc.Cell("E6").FormulaA1 = "=B10"
                wsCalc.Cell("E6").Style.NumberFormat.Format = "#,##0"

                wsCalc.Cell("D7").Value = "Equipment wear"
                wsCalc.Cell("E7").FormulaA1 = "=B11"
                wsCalc.Cell("E7").Style.NumberFormat.Format = "#,##0"

                wsCalc.Cell("D8").Value = "Overhead allocation"
                wsCalc.Cell("E8").FormulaA1 = "=IF(B13=0, 0, B12/B13)"
                wsCalc.Cell("E8").Style.NumberFormat.Format = "#,##0"

                wsCalc.Cell("D9").Value = "TOTAL COST"
                wsCalc.Cell("D9").Style.Font.Bold = True
                wsCalc.Cell("E9").FormulaA1 = "=SUM(E4:E8)"
                wsCalc.Cell("E9").Style.Font.Bold = True
                wsCalc.Cell("E9").Style.NumberFormat.Format = "#,##0"

                wsCalc.Cell("D11").Value = "3. SUGGESTED PRICE"
                wsCalc.Cell("D11").Style.Font.Bold = True
                wsCalc.Cell("E11").FormulaA1 = "=E9/(1-B14)"
                wsCalc.Cell("E11").Style.Font.Bold = True
                wsCalc.Cell("E11").Style.NumberFormat.Format = "#,##0"

                wsCalc.Cell("D12").Value = "Profit at suggested price"
                wsCalc.Cell("E12").FormulaA1 = "=E11-E9"
                wsCalc.Cell("E12").Style.NumberFormat.Format = "#,##0"

                wsCalc.Cell("D13").Value = "Labour % of price"
                wsCalc.Cell("E13").FormulaA1 = "=E4/E11"
                wsCalc.Cell("E13").Style.NumberFormat.Format = "0.0%"

                wsCalc.Cell("D15").Value = "4. CHECK AN ACTUAL QUOTE"
                wsCalc.Cell("D15").Style.Font.Bold = True

                wsCalc.Cell("D16").Value = "Actual quote price"
                wsCalc.Cell("E16").Value = 1200000
                wsCalc.Cell("E16").Style.NumberFormat.Format = "#,##0"
                wsCalc.Cell("E16").Style.Font.Bold = True

                wsCalc.Cell("D17").Value = "Actual profit"
                wsCalc.Cell("E17").FormulaA1 = "=E16-E9"
                wsCalc.Cell("E17").Style.NumberFormat.Format = "#,##0"

                wsCalc.Cell("D18").Value = "Actual margin %"
                wsCalc.Cell("E18").FormulaA1 = "=IF(E16=0, 0, (E16-E9)/E16)"
                wsCalc.Cell("E18").Style.NumberFormat.Format = "0.0%"
                wsCalc.Cell("E18").Style.Font.Bold = True

                ' Auto-fit columns across all sheets
                For Each ws In workbook.Worksheets
                    ws.Columns().AdjustToContents()
                Next

                workbook.SaveAs(filePath)
            End Using
        End Sub

        Private Sub CreateKpiBox(ws As IXLWorksheet, topLeft As String, bottomRight As String, title As String, value As String, hexColor As String)
            Dim range = ws.Range(topLeft & ":" & bottomRight)
            range.Merge()
            range.Value = title & vbCrLf & value
            range.Style.Alignment.WrapText = True
            range.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            range.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
            range.Style.Fill.BackgroundColor = XLColor.FromHtml(hexColor)
            range.Style.Font.FontColor = XLColor.White
            range.Style.Font.Bold = True
        End Sub
    End Class
End Namespace
