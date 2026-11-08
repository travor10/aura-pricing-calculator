Imports System.IO
Imports System.Windows.Forms
Imports AuraPricingSystem.Services
Imports AuraPricingSystem.Repositories
Imports AuraPricingSystem.Models
Imports AuraPricingSystem.Helpers

Namespace Forms
    Public Class FrmReports
        Private ReadOnly _reportService As New ReportService()
        Private ReadOnly _excelService As New ExcelExportService()
        Private ReadOnly _pdfService As New PdfReportService()
        Private ReadOnly _quoteRepo As New QuotationRepository()
        Private ReadOnly _serviceRepo As New ServiceRepository()

        Private Sub FrmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' Initialize date range to current month
            Dim today = DateTime.Today
            dtpStartDate.Value = New DateTime(today.Year, today.Month, 1)
            dtpEndDate.Value = dtpStartDate.Value.AddMonths(1).AddDays(-1)

            LoadServiceFilter()
            RefreshReportData()
        End Sub

        Private Sub LoadServiceFilter()
            cmbJobType.Items.Clear()
            cmbJobType.Items.Add("All Services")
            For Each s In _serviceRepo.GetAllServices(True)
                cmbJobType.Items.Add(s.ServiceName)
            Next
            cmbJobType.SelectedIndex = 0
        End Sub

        Private Sub btnApplyFilter_Click(sender As Object, e As EventArgs) Handles btnApplyFilter.Click
            RefreshReportData()
        End Sub

        Public Sub RefreshReportData()
            Dim startDate = dtpStartDate.Value.Date
            Dim endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1)
            Dim selectedService = If(cmbJobType.SelectedIndex > 0, cmbJobType.SelectedItem.ToString(), "All")

            Dim summary = _reportService.GetFinancialSummary(startDate, endDate)

            ' Update KPI cards
            lblKpiQuotesVal.Text = summary.TotalQuotesCount.ToString()
            lblKpiRevenueVal.Text = CurrencyFormatter.FormatUgx(summary.TotalAcceptedRevenue)
            lblKpiMarginVal.Text = CurrencyFormatter.FormatPercentage(summary.AverageGrossMargin)
            lblKpiJobsVal.Text = $"{summary.CompletedJobsCount} / {summary.TotalJobsCount}"

            ' Populate Category Table
            Dim catList = summary.CategoryBreakdown
            If selectedService <> "All" Then
                catList = catList.Where(Function(c) c.JobType = selectedService).ToList()
            End If

            dgvCategories.DataSource = Nothing
            dgvCategories.DataSource = catList.Select(Function(c) New With {
                .Category = c.JobType,
                .QuotesGenerated = c.QuotesCount,
                .AcceptedRevenueUGX = c.TotalRevenue.ToString("#,##0"),
                .AvgMarginPercent = $"{(c.AverageMargin * 100D):0.0}%"
            }).ToList()

            ' Populate Quotations Ledger
            Dim quotes = _quoteRepo.GetAllQuotations("All", "").
                Where(Function(q) q.QuoteDate >= startDate AndAlso q.QuoteDate <= endDate).ToList()

            If selectedService <> "All" Then
                quotes = quotes.Where(Function(q) q.JobType = selectedService).ToList()
            End If

            dgvQuotesReport.DataSource = Nothing
            dgvQuotesReport.DataSource = quotes.Select(Function(q) New With {
                .QuoteNo = q.QuoteNo,
                .Client = q.ClientName,
                .Service = q.JobType,
                .Date = q.QuoteDate.ToString("yyyy-MM-dd"),
                .QuotedPriceUGX = q.TotalAmount.ToString("#,##0"),
                .Status = q.Status
            }).ToList()
        End Sub

        Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
            Using sfd As New SaveFileDialog()
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
                sfd.FileName = $"Aura_Executive_Financial_Report_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
                If sfd.ShowDialog() = DialogResult.OK Then
                    Try
                        Cursor = Cursors.WaitCursor
                        _excelService.ExportFinancialReportToExcel(sfd.FileName, dtpStartDate.Value.Date, dtpEndDate.Value.Date)
                        Cursor = Cursors.Default
                        MessageBox.Show("Analytical ClosedXML 4-sheet workbook generated successfully!" & vbCrLf &
                                        $"File: {sfd.FileName}", "Excel Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        Cursor = Cursors.Default
                        MessageBox.Show($"Failed to export Excel report: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End Using
        End Sub

        Private Sub btnExportPdf_Click(sender As Object, e As EventArgs) Handles btnExportPdf.Click
            Dim quotes = _quoteRepo.GetAllQuotations("All", "")
            If quotes.Count = 0 Then
                MessageBox.Show("No quotations found to export.", "PDF Export", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Default export latest quotation
            Dim latestQuote = quotes.First()
            Using sfd As New SaveFileDialog()
                sfd.Filter = "PDF Document (*.pdf)|*.pdf"
                sfd.FileName = $"Aura_Quotation_{latestQuote.QuoteNo}_{DateTime.Now:yyyyMMdd}.pdf"
                If sfd.ShowDialog() = DialogResult.OK Then
                    Try
                        Cursor = Cursors.WaitCursor
                        _pdfService.GenerateQuotationPdf(latestQuote.QuotationID, sfd.FileName)
                        Cursor = Cursors.Default
                        MessageBox.Show($"QuestPDF document for {latestQuote.QuoteNo} generated successfully!" & vbCrLf &
                                        $"Destination: {sfd.FileName}", "Quotation PDF Exported", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        Cursor = Cursors.Default
                        MessageBox.Show($"Failed to export PDF: {ex.Message}", "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End Using
        End Sub
    End Class
End Namespace
