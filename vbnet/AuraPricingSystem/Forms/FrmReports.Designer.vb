Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmReports
        Inherits System.Windows.Forms.Form

        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        Private components As System.ComponentModel.IContainer

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubtitle As System.Windows.Forms.Label

        Friend WithEvents pnlFilters As System.Windows.Forms.Panel
        Friend WithEvents lblDateFrom As System.Windows.Forms.Label
        Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDateTo As System.Windows.Forms.Label
        Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblJobType As System.Windows.Forms.Label
        Friend WithEvents cmbJobType As System.Windows.Forms.ComboBox
        Friend WithEvents btnApplyFilter As System.Windows.Forms.Button
        Friend WithEvents btnExportExcel As System.Windows.Forms.Button
        Friend WithEvents btnExportPdf As System.Windows.Forms.Button

        Friend WithEvents pnlKpiContainer As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents pnlKpiQuotes As System.Windows.Forms.Panel
        Friend WithEvents lblKpiQuotesTitle As System.Windows.Forms.Label
        Friend WithEvents lblKpiQuotesVal As System.Windows.Forms.Label
        Friend WithEvents pnlKpiRevenue As System.Windows.Forms.Panel
        Friend WithEvents lblKpiRevenueTitle As System.Windows.Forms.Label
        Friend WithEvents lblKpiRevenueVal As System.Windows.Forms.Label
        Friend WithEvents pnlKpiMargin As System.Windows.Forms.Panel
        Friend WithEvents lblKpiMarginTitle As System.Windows.Forms.Label
        Friend WithEvents lblKpiMarginVal As System.Windows.Forms.Label
        Friend WithEvents pnlKpiJobs As System.Windows.Forms.Panel
        Friend WithEvents lblKpiJobsTitle As System.Windows.Forms.Label
        Friend WithEvents lblKpiJobsVal As System.Windows.Forms.Label

        Friend WithEvents tabReports As System.Windows.Forms.TabControl
        Friend WithEvents tabCategoryBreakdown As System.Windows.Forms.TabPage
        Friend WithEvents dgvCategories As System.Windows.Forms.DataGridView
        Friend WithEvents tabQuotesBreakdown As System.Windows.Forms.TabPage
        Friend WithEvents dgvQuotesReport As System.Windows.Forms.DataGridView

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.pnlHeader = New System.Windows.Forms.Panel()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.lblSubtitle = New System.Windows.Forms.Label()

            Me.pnlFilters = New System.Windows.Forms.Panel()
            Me.lblDateFrom = New System.Windows.Forms.Label()
            Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
            Me.lblDateTo = New System.Windows.Forms.Label()
            Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
            Me.lblJobType = New System.Windows.Forms.Label()
            Me.cmbJobType = New System.Windows.Forms.ComboBox()
            Me.btnApplyFilter = New System.Windows.Forms.Button()
            Me.btnExportExcel = New System.Windows.Forms.Button()
            Me.btnExportPdf = New System.Windows.Forms.Button()

            Me.pnlKpiContainer = New System.Windows.Forms.TableLayoutPanel()
            Me.pnlKpiQuotes = New System.Windows.Forms.Panel()
            Me.lblKpiQuotesTitle = New System.Windows.Forms.Label()
            Me.lblKpiQuotesVal = New System.Windows.Forms.Label()
            Me.pnlKpiRevenue = New System.Windows.Forms.Panel()
            Me.lblKpiRevenueTitle = New System.Windows.Forms.Label()
            Me.lblKpiRevenueVal = New System.Windows.Forms.Label()
            Me.pnlKpiMargin = New System.Windows.Forms.Panel()
            Me.lblKpiMarginTitle = New System.Windows.Forms.Label()
            Me.lblKpiMarginVal = New System.Windows.Forms.Label()
            Me.pnlKpiJobs = New System.Windows.Forms.Panel()
            Me.lblKpiJobsTitle = New System.Windows.Forms.Label()
            Me.lblKpiJobsVal = New System.Windows.Forms.Label()

            Me.tabReports = New System.Windows.Forms.TabControl()
            Me.tabCategoryBreakdown = New System.Windows.Forms.TabPage()
            Me.dgvCategories = New System.Windows.Forms.DataGridView()
            Me.tabQuotesBreakdown = New System.Windows.Forms.TabPage()
            Me.dgvQuotesReport = New System.Windows.Forms.DataGridView()

            Me.SuspendLayout()

            ' pnlHeader
            Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(12, 75, 136)
            Me.pnlHeader.Controls.Add(Me.lblSubtitle)
            Me.pnlHeader.Controls.Add(Me.lblTitle)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
            Me.pnlHeader.Size = New System.Drawing.Size(1080, 65)

            ' lblTitle
            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.White
            Me.lblTitle.Location = New System.Drawing.Point(15, 10)
            Me.lblTitle.Text = "FINANCIAL REPORTS & EXCEL/PDF EXPORTS (MODULE 10)"

            ' lblSubtitle
            Me.lblSubtitle.AutoSize = True
            Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(223, 229, 232)
            Me.lblSubtitle.Location = New System.Drawing.Point(16, 38)
            Me.lblSubtitle.Text = "Aggregate quotation profitability, export 4-sheet ClosedXML analytical workbooks and QuestPDF formal client quotes"

            ' pnlFilters
            Me.pnlFilters.BackColor = System.Drawing.Color.White
            Me.pnlFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlFilters.Controls.Add(Me.btnExportPdf)
            Me.pnlFilters.Controls.Add(Me.btnExportExcel)
            Me.pnlFilters.Controls.Add(Me.btnApplyFilter)
            Me.pnlFilters.Controls.Add(Me.cmbJobType)
            Me.pnlFilters.Controls.Add(Me.lblJobType)
            Me.pnlFilters.Controls.Add(Me.dtpEndDate)
            Me.pnlFilters.Controls.Add(Me.lblDateTo)
            Me.pnlFilters.Controls.Add(Me.dtpStartDate)
            Me.pnlFilters.Controls.Add(Me.lblDateFrom)
            Me.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlFilters.Location = New System.Drawing.Point(0, 65)
            Me.pnlFilters.Size = New System.Drawing.Size(1080, 55)

            ' Filters controls
            Me.lblDateFrom.AutoSize = True
            Me.lblDateFrom.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblDateFrom.Location = New System.Drawing.Point(15, 18)
            Me.lblDateFrom.Text = "From:"

            Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpStartDate.Location = New System.Drawing.Point(58, 15)
            Me.dtpStartDate.Size = New System.Drawing.Size(105, 23)

            Me.lblDateTo.AutoSize = True
            Me.lblDateTo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblDateTo.Location = New System.Drawing.Point(175, 18)
            Me.lblDateTo.Text = "To:"

            Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpEndDate.Location = New System.Drawing.Point(202, 15)
            Me.dtpEndDate.Size = New System.Drawing.Size(105, 23)

            Me.lblJobType.AutoSize = True
            Me.lblJobType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblJobType.Location = New System.Drawing.Point(325, 18)
            Me.lblJobType.Text = "Service:"

            Me.cmbJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbJobType.Location = New System.Drawing.Point(380, 15)
            Me.cmbJobType.Size = New System.Drawing.Size(160, 23)

            Me.btnApplyFilter.BackColor = System.Drawing.Color.FromArgb(12, 75, 136)
            Me.btnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnApplyFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnApplyFilter.ForeColor = System.Drawing.Color.White
            Me.btnApplyFilter.Location = New System.Drawing.Point(555, 12)
            Me.btnApplyFilter.Size = New System.Drawing.Size(100, 28)
            Me.btnApplyFilter.Text = "Filter Report"

            Me.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(36, 122, 61)
            Me.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnExportExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnExportExcel.ForeColor = System.Drawing.Color.White
            Me.btnExportExcel.Location = New System.Drawing.Point(670, 12)
            Me.btnExportExcel.Size = New System.Drawing.Size(170, 28)
            Me.btnExportExcel.Text = "Export ClosedXML Excel"

            Me.btnExportPdf.BackColor = System.Drawing.Color.FromArgb(249, 160, 31)
            Me.btnExportPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnExportPdf.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnExportPdf.ForeColor = System.Drawing.Color.Black
            Me.btnExportPdf.Location = New System.Drawing.Point(850, 12)
            Me.btnExportPdf.Size = New System.Drawing.Size(180, 28)
            Me.btnExportPdf.Text = "Export QuestPDF Quote"

            ' pnlKpiContainer
            Me.pnlKpiContainer.ColumnCount = 4
            Me.pnlKpiContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.pnlKpiContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.pnlKpiContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.pnlKpiContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.pnlKpiContainer.Controls.Add(Me.pnlKpiQuotes, 0, 0)
            Me.pnlKpiContainer.Controls.Add(Me.pnlKpiRevenue, 1, 0)
            Me.pnlKpiContainer.Controls.Add(Me.pnlKpiMargin, 2, 0)
            Me.pnlKpiContainer.Controls.Add(Me.pnlKpiJobs, 3, 0)
            Me.pnlKpiContainer.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlKpiContainer.Location = New System.Drawing.Point(0, 120)
            Me.pnlKpiContainer.Padding = New System.Windows.Forms.Padding(10)
            Me.pnlKpiContainer.Size = New System.Drawing.Size(1080, 90)

            ' KPI 1: Quotes
            Me.pnlKpiQuotes.BackColor = System.Drawing.Color.FromArgb(12, 75, 136)
            Me.pnlKpiQuotes.Controls.Add(Me.lblKpiQuotesVal)
            Me.pnlKpiQuotes.Controls.Add(Me.lblKpiQuotesTitle)
            Me.pnlKpiQuotes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlKpiQuotes.Margin = New System.Windows.Forms.Padding(5)

            Me.lblKpiQuotesTitle.AutoSize = True
            Me.lblKpiQuotesTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblKpiQuotesTitle.ForeColor = System.Drawing.Color.White
            Me.lblKpiQuotesTitle.Location = New System.Drawing.Point(10, 8)
            Me.lblKpiQuotesTitle.Text = "TOTAL QUOTATIONS"

            Me.lblKpiQuotesVal.AutoSize = True
            Me.lblKpiQuotesVal.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
            Me.lblKpiQuotesVal.ForeColor = System.Drawing.Color.White
            Me.lblKpiQuotesVal.Location = New System.Drawing.Point(10, 28)
            Me.lblKpiQuotesVal.Text = "0"

            ' KPI 2: Revenue
            Me.pnlKpiRevenue.BackColor = System.Drawing.Color.FromArgb(36, 122, 61)
            Me.pnlKpiRevenue.Controls.Add(Me.lblKpiRevenueVal)
            Me.pnlKpiRevenue.Controls.Add(Me.lblKpiRevenueTitle)
            Me.pnlKpiRevenue.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlKpiRevenue.Margin = New System.Windows.Forms.Padding(5)

            Me.lblKpiRevenueTitle.AutoSize = True
            Me.lblKpiRevenueTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblKpiRevenueTitle.ForeColor = System.Drawing.Color.White
            Me.lblKpiRevenueTitle.Location = New System.Drawing.Point(10, 8)
            Me.lblKpiRevenueTitle.Text = "ACCEPTED REVENUE"

            Me.lblKpiRevenueVal.AutoSize = True
            Me.lblKpiRevenueVal.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
            Me.lblKpiRevenueVal.ForeColor = System.Drawing.Color.White
            Me.lblKpiRevenueVal.Location = New System.Drawing.Point(10, 28)
            Me.lblKpiRevenueVal.Text = "UGX 0"

            ' KPI 3: Margin
            Me.pnlKpiMargin.BackColor = System.Drawing.Color.FromArgb(249, 160, 31)
            Me.pnlKpiMargin.Controls.Add(Me.lblKpiMarginVal)
            Me.pnlKpiMargin.Controls.Add(Me.lblKpiMarginTitle)
            Me.pnlKpiMargin.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlKpiMargin.Margin = New System.Windows.Forms.Padding(5)

            Me.lblKpiMarginTitle.AutoSize = True
            Me.lblKpiMarginTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblKpiMarginTitle.ForeColor = System.Drawing.Color.Black
            Me.lblKpiMarginTitle.Location = New System.Drawing.Point(10, 8)
            Me.lblKpiMarginTitle.Text = "AVG REALIZED MARGIN"

            Me.lblKpiMarginVal.AutoSize = True
            Me.lblKpiMarginVal.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
            Me.lblKpiMarginVal.ForeColor = System.Drawing.Color.Black
            Me.lblKpiMarginVal.Location = New System.Drawing.Point(10, 28)
            Me.lblKpiMarginVal.Text = "0.0%"

            ' KPI 4: Jobs
            Me.pnlKpiJobs.BackColor = System.Drawing.Color.FromArgb(107, 63, 160)
            Me.pnlKpiJobs.Controls.Add(Me.lblKpiJobsVal)
            Me.pnlKpiJobs.Controls.Add(Me.lblKpiJobsTitle)
            Me.pnlKpiJobs.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlKpiJobs.Margin = New System.Windows.Forms.Padding(5)

            Me.lblKpiJobsTitle.AutoSize = True
            Me.lblKpiJobsTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblKpiJobsTitle.ForeColor = System.Drawing.Color.White
            Me.lblKpiJobsTitle.Location = New System.Drawing.Point(10, 8)
            Me.lblKpiJobsTitle.Text = "OPERATIONAL JOBS"

            Me.lblKpiJobsVal.AutoSize = True
            Me.lblKpiJobsVal.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
            Me.lblKpiJobsVal.ForeColor = System.Drawing.Color.White
            Me.lblKpiJobsVal.Location = New System.Drawing.Point(10, 28)
            Me.lblKpiJobsVal.Text = "0"

            ' tabReports
            Me.tabReports.Controls.Add(Me.tabCategoryBreakdown)
            Me.tabReports.Controls.Add(Me.tabQuotesBreakdown)
            Me.tabReports.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tabReports.Location = New System.Drawing.Point(0, 210)
            Me.tabReports.Padding = New System.Drawing.Point(8, 6)
            Me.tabReports.Size = New System.Drawing.Size(1080, 470)

            ' tabCategoryBreakdown
            Me.tabCategoryBreakdown.Controls.Add(Me.dgvCategories)
            Me.tabCategoryBreakdown.Text = "Service Category Profitability Breakdown"
            Me.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvCategories.ReadOnly = True
            Me.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvCategories.BackgroundColor = System.Drawing.Color.White

            ' tabQuotesBreakdown
            Me.tabQuotesBreakdown.Controls.Add(Me.dgvQuotesReport)
            Me.tabQuotesBreakdown.Text = "Quotation Ledger & Profit Margins"
            Me.dgvQuotesReport.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvQuotesReport.ReadOnly = True
            Me.dgvQuotesReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvQuotesReport.BackgroundColor = System.Drawing.Color.White

            ' FrmReports
            Me.ClientSize = New System.Drawing.Size(1080, 680)
            Me.Controls.Add(Me.tabReports)
            Me.Controls.Add(Me.pnlKpiContainer)
            Me.Controls.Add(Me.pnlFilters)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.Name = "FrmReports"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Aura Pricing System – Financial Reports & Analytical Exports"
            Me.ResumeLayout(False)
        End Sub
    End Class
End Namespace
