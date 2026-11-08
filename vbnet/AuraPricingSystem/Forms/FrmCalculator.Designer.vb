Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmCalculator
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
        Friend WithEvents pnlActionsTop As System.Windows.Forms.Panel
        Friend WithEvents btnResetBukiika As System.Windows.Forms.Button
        Friend WithEvents btnSaveQuote As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents tableLayout As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents grpInputs As System.Windows.Forms.GroupBox
        Friend WithEvents lblClient As System.Windows.Forms.Label
        Friend WithEvents cboClient As System.Windows.Forms.ComboBox
        Friend WithEvents lblJobName As System.Windows.Forms.Label
        Friend WithEvents txtJobName As System.Windows.Forms.TextBox
        Friend WithEvents lblJobType As System.Windows.Forms.Label
        Friend WithEvents cboJobType As System.Windows.Forms.ComboBox
        Friend WithEvents lblGuideBenchmark As System.Windows.Forms.Label
        Friend WithEvents lblService As System.Windows.Forms.Label
        Friend WithEvents cboService As System.Windows.Forms.ComboBox
        Friend WithEvents lblTeamMembers As System.Windows.Forms.Label
        Friend WithEvents numTeamMembers As System.Windows.Forms.NumericUpDown
        Friend WithEvents lblDayRate As System.Windows.Forms.Label
        Friend WithEvents numDayRate As System.Windows.Forms.NumericUpDown
        Friend WithEvents lblDays As System.Windows.Forms.Label
        Friend WithEvents numDays As System.Windows.Forms.NumericUpDown
        Friend WithEvents lblSupplies As System.Windows.Forms.Label
        Friend WithEvents numSupplies As System.Windows.Forms.NumericUpDown
        Friend WithEvents lblTransport As System.Windows.Forms.Label
        Friend WithEvents numTransport As System.Windows.Forms.NumericUpDown
        Friend WithEvents lblEquipmentWear As System.Windows.Forms.Label
        Friend WithEvents numEquipmentWear As System.Windows.Forms.NumericUpDown
        Friend WithEvents lblMonthlyOverhead As System.Windows.Forms.Label
        Friend WithEvents numMonthlyOverhead As System.Windows.Forms.NumericUpDown
        Friend WithEvents lblAvgJobs As System.Windows.Forms.Label
        Friend WithEvents numAvgJobs As System.Windows.Forms.NumericUpDown
        Friend WithEvents lblTargetMargin As System.Windows.Forms.Label
        Friend WithEvents numTargetMargin As System.Windows.Forms.NumericUpDown
        Friend WithEvents grpCostBreakdown As System.Windows.Forms.GroupBox
        Friend WithEvents lblLaborCostText As System.Windows.Forms.Label
        Friend WithEvents lblLaborCostVal As System.Windows.Forms.Label
        Friend WithEvents lblSuppliesText As System.Windows.Forms.Label
        Friend WithEvents lblSuppliesVal As System.Windows.Forms.Label
        Friend WithEvents lblTransportText As System.Windows.Forms.Label
        Friend WithEvents lblTransportVal As System.Windows.Forms.Label
        Friend WithEvents lblEquipmentText As System.Windows.Forms.Label
        Friend WithEvents lblEquipmentVal As System.Windows.Forms.Label
        Friend WithEvents lblOverheadText As System.Windows.Forms.Label
        Friend WithEvents lblOverheadVal As System.Windows.Forms.Label
        Friend WithEvents lblTotalCostText As System.Windows.Forms.Label
        Friend WithEvents lblTotalCostVal As System.Windows.Forms.Label
        Friend WithEvents pnlSuggestedPrice As System.Windows.Forms.Panel
        Friend WithEvents lblSuggestedPriceTitle As System.Windows.Forms.Label
        Friend WithEvents lblSuggestedPriceVal As System.Windows.Forms.Label
        Friend WithEvents lblProfitAtSuggested As System.Windows.Forms.Label
        Friend WithEvents lblLaborPercent As System.Windows.Forms.Label
        Friend WithEvents lblLaborWarning As System.Windows.Forms.Label
        Friend WithEvents grpActualQuote As System.Windows.Forms.GroupBox
        Friend WithEvents lblActualQuoteInput As System.Windows.Forms.Label
        Friend WithEvents numActualQuote As System.Windows.Forms.NumericUpDown
        Friend WithEvents lblActualProfit As System.Windows.Forms.Label
        Friend WithEvents lblActualMargin As System.Windows.Forms.Label
        Friend WithEvents pnlVerdict As System.Windows.Forms.Panel
        Friend WithEvents lblVerdictTitle As System.Windows.Forms.Label
        Friend WithEvents lblVerdictValue As System.Windows.Forms.Label

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.pnlHeader = New System.Windows.Forms.Panel()
            Me.pnlActionsTop = New System.Windows.Forms.Panel()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnResetBukiika = New System.Windows.Forms.Button()
            Me.btnSaveQuote = New System.Windows.Forms.Button()
            Me.lblSubtitle = New System.Windows.Forms.Label()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.tableLayout = New System.Windows.Forms.TableLayoutPanel()
            Me.grpInputs = New System.Windows.Forms.GroupBox()
            Me.numTargetMargin = New System.Windows.Forms.NumericUpDown()
            Me.lblTargetMargin = New System.Windows.Forms.Label()
            Me.numAvgJobs = New System.Windows.Forms.NumericUpDown()
            Me.lblAvgJobs = New System.Windows.Forms.Label()
            Me.numMonthlyOverhead = New System.Windows.Forms.NumericUpDown()
            Me.lblMonthlyOverhead = New System.Windows.Forms.Label()
            Me.numEquipmentWear = New System.Windows.Forms.NumericUpDown()
            Me.lblEquipmentWear = New System.Windows.Forms.Label()
            Me.numTransport = New System.Windows.Forms.NumericUpDown()
            Me.lblTransport = New System.Windows.Forms.Label()
            Me.numSupplies = New System.Windows.Forms.NumericUpDown()
            Me.lblSupplies = New System.Windows.Forms.Label()
            Me.numDays = New System.Windows.Forms.NumericUpDown()
            Me.lblDays = New System.Windows.Forms.Label()
            Me.numDayRate = New System.Windows.Forms.NumericUpDown()
            Me.lblDayRate = New System.Windows.Forms.Label()
            Me.numTeamMembers = New System.Windows.Forms.NumericUpDown()
            Me.lblTeamMembers = New System.Windows.Forms.Label()
            Me.cboService = New System.Windows.Forms.ComboBox()
            Me.lblService = New System.Windows.Forms.Label()
            Me.lblGuideBenchmark = New System.Windows.Forms.Label()
            Me.cboJobType = New System.Windows.Forms.ComboBox()
            Me.lblJobType = New System.Windows.Forms.Label()
            Me.txtJobName = New System.Windows.Forms.TextBox()
            Me.lblJobName = New System.Windows.Forms.Label()
            Me.cboClient = New System.Windows.Forms.ComboBox()
            Me.lblClient = New System.Windows.Forms.Label()
            Me.grpCostBreakdown = New System.Windows.Forms.GroupBox()
            Me.lblLaborWarning = New System.Windows.Forms.Label()
            Me.lblLaborPercent = New System.Windows.Forms.Label()
            Me.lblProfitAtSuggested = New System.Windows.Forms.Label()
            Me.pnlSuggestedPrice = New System.Windows.Forms.Panel()
            Me.lblSuggestedPriceVal = New System.Windows.Forms.Label()
            Me.lblSuggestedPriceTitle = New System.Windows.Forms.Label()
            Me.lblTotalCostVal = New System.Windows.Forms.Label()
            Me.lblTotalCostText = New System.Windows.Forms.Label()
            Me.lblOverheadVal = New System.Windows.Forms.Label()
            Me.lblOverheadText = New System.Windows.Forms.Label()
            Me.lblEquipmentVal = New System.Windows.Forms.Label()
            Me.lblEquipmentText = New System.Windows.Forms.Label()
            Me.lblTransportVal = New System.Windows.Forms.Label()
            Me.lblTransportText = New System.Windows.Forms.Label()
            Me.lblSuppliesVal = New System.Windows.Forms.Label()
            Me.lblSuppliesText = New System.Windows.Forms.Label()
            Me.lblLaborCostVal = New System.Windows.Forms.Label()
            Me.lblLaborCostText = New System.Windows.Forms.Label()
            Me.grpActualQuote = New System.Windows.Forms.GroupBox()
            Me.pnlVerdict = New System.Windows.Forms.Panel()
            Me.lblVerdictValue = New System.Windows.Forms.Label()
            Me.lblVerdictTitle = New System.Windows.Forms.Label()
            Me.lblActualMargin = New System.Windows.Forms.Label()
            Me.lblActualProfit = New System.Windows.Forms.Label()
            Me.numActualQuote = New System.Windows.Forms.NumericUpDown()
            Me.lblActualQuoteInput = New System.Windows.Forms.Label()
            Me.pnlHeader.SuspendLayout()
            Me.pnlActionsTop.SuspendLayout()
            Me.tableLayout.SuspendLayout()
            Me.grpInputs.SuspendLayout()
            CType(Me.numTargetMargin, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numAvgJobs, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numMonthlyOverhead, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numEquipmentWear, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numTransport, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numSupplies, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numDays, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numDayRate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numTeamMembers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpCostBreakdown.SuspendLayout()
            Me.pnlSuggestedPrice.SuspendLayout()
            Me.grpActualQuote.SuspendLayout()
            Me.pnlVerdict.SuspendLayout()
            CType(Me.numActualQuote, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlHeader
            '
            Me.pnlHeader.Controls.Add(Me.pnlActionsTop)
            Me.pnlHeader.Controls.Add(Me.lblSubtitle)
            Me.pnlHeader.Controls.Add(Me.lblTitle)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(20, 20)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(1060, 55)
            Me.pnlHeader.TabIndex = 0
            '
            'pnlActionsTop
            '
            Me.pnlActionsTop.Controls.Add(Me.btnClear)
            Me.pnlActionsTop.Controls.Add(Me.btnResetBukiika)
            Me.pnlActionsTop.Controls.Add(Me.btnSaveQuote)
            Me.pnlActionsTop.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnlActionsTop.Location = New System.Drawing.Point(620, 0)
            Me.pnlActionsTop.Name = "pnlActionsTop"
            Me.pnlActionsTop.Size = New System.Drawing.Size(440, 55)
            Me.pnlActionsTop.TabIndex = 2
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(232, Byte), Integer))
            Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnClear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            Me.btnClear.Location = New System.Drawing.Point(345, 10)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(90, 34)
            Me.btnClear.TabIndex = 2
            Me.btnClear.Text = "Clear"
            Me.btnClear.UseVisualStyleBackColor = False
            '
            'btnResetBukiika
            '
            Me.btnResetBukiika.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(31, Byte), Integer))
            Me.btnResetBukiika.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnResetBukiika.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnResetBukiika.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnResetBukiika.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            Me.btnResetBukiika.Location = New System.Drawing.Point(205, 10)
            Me.btnResetBukiika.Name = "btnResetBukiika"
            Me.btnResetBukiika.Size = New System.Drawing.Size(130, 34)
            Me.btnResetBukiika.TabIndex = 1
            Me.btnResetBukiika.Text = "Load Bukiika"
            Me.btnResetBukiika.UseVisualStyleBackColor = False
            '
            'btnSaveQuote
            '
            Me.btnSaveQuote.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.btnSaveQuote.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSaveQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSaveQuote.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnSaveQuote.ForeColor = System.Drawing.Color.White
            Me.btnSaveQuote.Location = New System.Drawing.Point(25, 10)
            Me.btnSaveQuote.Name = "btnSaveQuote"
            Me.btnSaveQuote.Size = New System.Drawing.Size(170, 34)
            Me.btnSaveQuote.TabIndex = 0
            Me.btnSaveQuote.Text = "Save as Quotation"
            Me.btnSaveQuote.UseVisualStyleBackColor = False
            '
            'lblSubtitle
            '
            Me.lblSubtitle.AutoSize = True
            Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(130, Byte), Integer))
            Me.lblSubtitle.Location = New System.Drawing.Point(2, 30)
            Me.lblSubtitle.Name = "lblSubtitle"
            Me.lblSubtitle.Size = New System.Drawing.Size(465, 15)
            Me.lblSubtitle.TabIndex = 1
            Me.lblSubtitle.Text = "Excel-authoritative pricing engine with dynamic margin guides, cost breakdown & verdicts"
            '
            'lblTitle
            '
            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.lblTitle.Location = New System.Drawing.Point(0, 0)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(268, 30)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "Pricing Calculator Engine"
            '
            'tableLayout
            '
            Me.tableLayout.ColumnCount = 2
            Me.tableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.tableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.tableLayout.Controls.Add(Me.grpInputs, 0, 0)
            Me.tableLayout.Controls.Add(Me.grpCostBreakdown, 1, 0)
            Me.tableLayout.Controls.Add(Me.grpActualQuote, 1, 1)
            Me.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tableLayout.Location = New System.Drawing.Point(20, 75)
            Me.tableLayout.Name = "tableLayout"
            Me.tableLayout.RowCount = 2
            Me.tableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
            Me.tableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
            Me.tableLayout.Size = New System.Drawing.Size(1060, 570)
            Me.tableLayout.TabIndex = 1
            '
            'grpInputs
            '
            Me.grpInputs.BackColor = System.Drawing.Color.White
            Me.grpInputs.Controls.Add(Me.numTargetMargin)
            Me.grpInputs.Controls.Add(Me.lblTargetMargin)
            Me.grpInputs.Controls.Add(Me.numAvgJobs)
            Me.grpInputs.Controls.Add(Me.lblAvgJobs)
            Me.grpInputs.Controls.Add(Me.numMonthlyOverhead)
            Me.grpInputs.Controls.Add(Me.lblMonthlyOverhead)
            Me.grpInputs.Controls.Add(Me.numEquipmentWear)
            Me.grpInputs.Controls.Add(Me.lblEquipmentWear)
            Me.grpInputs.Controls.Add(Me.numTransport)
            Me.grpInputs.Controls.Add(Me.lblTransport)
            Me.grpInputs.Controls.Add(Me.numSupplies)
            Me.grpInputs.Controls.Add(Me.lblSupplies)
            Me.grpInputs.Controls.Add(Me.numDays)
            Me.grpInputs.Controls.Add(Me.lblDays)
            Me.grpInputs.Controls.Add(Me.numDayRate)
            Me.grpInputs.Controls.Add(Me.lblDayRate)
            Me.grpInputs.Controls.Add(Me.numTeamMembers)
            Me.grpInputs.Controls.Add(Me.lblTeamMembers)
            Me.grpInputs.Controls.Add(Me.cboService)
            Me.grpInputs.Controls.Add(Me.lblService)
            Me.grpInputs.Controls.Add(Me.lblGuideBenchmark)
            Me.grpInputs.Controls.Add(Me.cboJobType)
            Me.grpInputs.Controls.Add(Me.lblJobType)
            Me.grpInputs.Controls.Add(Me.txtJobName)
            Me.grpInputs.Controls.Add(Me.lblJobName)
            Me.grpInputs.Controls.Add(Me.cboClient)
            Me.grpInputs.Controls.Add(Me.lblClient)
            Me.grpInputs.Dock = System.Windows.Forms.DockStyle.Fill
            Me.grpInputs.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.grpInputs.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.grpInputs.Location = New System.Drawing.Point(3, 3)
            Me.grpInputs.Name = "grpInputs"
            Me.tableLayout.SetRowSpan(Me.grpInputs, 2)
            Me.grpInputs.Size = New System.Drawing.Size(524, 564)
            Me.grpInputs.TabIndex = 0
            Me.grpInputs.TabStop = False
            Me.grpInputs.Text = "1. Job Costing Inputs"
            '
            'numTargetMargin
            '
            Me.numTargetMargin.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.numTargetMargin.Location = New System.Drawing.Point(210, 485)
            Me.numTargetMargin.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
            Me.numTargetMargin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.numTargetMargin.Name = "numTargetMargin"
            Me.numTargetMargin.Size = New System.Drawing.Size(295, 23)
            Me.numTargetMargin.TabIndex = 26
            Me.numTargetMargin.Value = New Decimal(New Integer() {35, 0, 0, 0})
            '
            'lblTargetMargin
            '
            Me.lblTargetMargin.AutoSize = True
            Me.lblTargetMargin.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblTargetMargin.ForeColor = System.Drawing.Color.Black
            Me.lblTargetMargin.Location = New System.Drawing.Point(15, 488)
            Me.lblTargetMargin.Name = "lblTargetMargin"
            Me.lblTargetMargin.Size = New System.Drawing.Size(127, 15)
            Me.lblTargetMargin.TabIndex = 25
            Me.lblTargetMargin.Text = "Target Net Margin (%):"
            '
            'numAvgJobs
            '
            Me.numAvgJobs.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.numAvgJobs.Location = New System.Drawing.Point(210, 450)
            Me.numAvgJobs.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
            Me.numAvgJobs.Name = "numAvgJobs"
            Me.numAvgJobs.Size = New System.Drawing.Size(295, 23)
            Me.numAvgJobs.TabIndex = 24
            Me.numAvgJobs.Value = New Decimal(New Integer() {8, 0, 0, 0})
            '
            'lblAvgJobs
            '
            Me.lblAvgJobs.AutoSize = True
            Me.lblAvgJobs.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblAvgJobs.ForeColor = System.Drawing.Color.Black
            Me.lblAvgJobs.Location = New System.Drawing.Point(15, 453)
            Me.lblAvgJobs.Name = "lblAvgJobs"
            Me.lblAvgJobs.Size = New System.Drawing.Size(124, 15)
            Me.lblAvgJobs.TabIndex = 23
            Me.lblAvgJobs.Text = "Avg. Jobs per Month:"
            '
            'numMonthlyOverhead
            '
            Me.numMonthlyOverhead.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.numMonthlyOverhead.Increment = New Decimal(New Integer() {10000, 0, 0, 0})
            Me.numMonthlyOverhead.Location = New System.Drawing.Point(210, 415)
            Me.numMonthlyOverhead.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
            Me.numMonthlyOverhead.Name = "numMonthlyOverhead"
            Me.numMonthlyOverhead.Size = New System.Drawing.Size(295, 23)
            Me.numMonthlyOverhead.TabIndex = 22
            Me.numMonthlyOverhead.ThousandsSeparator = True
            Me.numMonthlyOverhead.Value = New Decimal(New Integer() {100000, 0, 0, 0})
            '
            'lblMonthlyOverhead
            '
            Me.lblMonthlyOverhead.AutoSize = True
            Me.lblMonthlyOverhead.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblMonthlyOverhead.ForeColor = System.Drawing.Color.Black
            Me.lblMonthlyOverhead.Location = New System.Drawing.Point(15, 418)
            Me.lblMonthlyOverhead.Name = "lblMonthlyOverhead"
            Me.lblMonthlyOverhead.Size = New System.Drawing.Size(139, 15)
            Me.lblMonthlyOverhead.TabIndex = 21
            Me.lblMonthlyOverhead.Text = "Monthly Overhead (UGX):"
            '
            'numEquipmentWear
            '
            Me.numEquipmentWear.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.numEquipmentWear.Increment = New Decimal(New Integer() {5000, 0, 0, 0})
            Me.numEquipmentWear.Location = New System.Drawing.Point(210, 380)
            Me.numEquipmentWear.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
            Me.numEquipmentWear.Name = "numEquipmentWear"
            Me.numEquipmentWear.Size = New System.Drawing.Size(295, 23)
            Me.numEquipmentWear.TabIndex = 20
            Me.numEquipmentWear.ThousandsSeparator = True
            Me.numEquipmentWear.Value = New Decimal(New Integer() {15000, 0, 0, 0})
            '
            'lblEquipmentWear
            '
            Me.lblEquipmentWear.AutoSize = True
            Me.lblEquipmentWear.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblEquipmentWear.ForeColor = System.Drawing.Color.Black
            Me.lblEquipmentWear.Location = New System.Drawing.Point(15, 383)
            Me.lblEquipmentWear.Name = "lblEquipmentWear"
            Me.lblEquipmentWear.Size = New System.Drawing.Size(127, 15)
            Me.lblEquipmentWear.TabIndex = 19
            Me.lblEquipmentWear.Text = "Equipment Wear (UGX):"
            '
            'numTransport
            '
            Me.numTransport.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.numTransport.Increment = New Decimal(New Integer() {10000, 0, 0, 0})
            Me.numTransport.Location = New System.Drawing.Point(210, 345)
            Me.numTransport.Maximum = New Decimal(New Integer() {50000000, 0, 0, 0})
            Me.numTransport.Name = "numTransport"
            Me.numTransport.Size = New System.Drawing.Size(295, 23)
            Me.numTransport.TabIndex = 18
            Me.numTransport.ThousandsSeparator = True
            Me.numTransport.Value = New Decimal(New Integer() {200000, 0, 0, 0})
            '
            'lblTransport
            '
            Me.lblTransport.AutoSize = True
            Me.lblTransport.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblTransport.ForeColor = System.Drawing.Color.Black
            Me.lblTransport.Location = New System.Drawing.Point(15, 348)
            Me.lblTransport.Name = "lblTransport"
            Me.lblTransport.Size = New System.Drawing.Size(91, 15)
            Me.lblTransport.TabIndex = 17
            Me.lblTransport.Text = "Transport (UGX):"
            '
            'numSupplies
            '
            Me.numSupplies.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.numSupplies.Increment = New Decimal(New Integer() {10000, 0, 0, 0})
            Me.numSupplies.Location = New System.Drawing.Point(210, 310)
            Me.numSupplies.Maximum = New Decimal(New Integer() {50000000, 0, 0, 0})
            Me.numSupplies.Name = "numSupplies"
            Me.numSupplies.Size = New System.Drawing.Size(295, 23)
            Me.numSupplies.TabIndex = 16
            Me.numSupplies.ThousandsSeparator = True
            Me.numSupplies.Value = New Decimal(New Integer() {100000, 0, 0, 0})
            '
            'lblSupplies
            '
            Me.lblSupplies.AutoSize = True
            Me.lblSupplies.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSupplies.ForeColor = System.Drawing.Color.Black
            Me.lblSupplies.Location = New System.Drawing.Point(15, 313)
            Me.lblSupplies.Name = "lblSupplies"
            Me.lblSupplies.Size = New System.Drawing.Size(149, 15)
            Me.lblSupplies.TabIndex = 15
            Me.lblSupplies.Text = "Supplies/Chemicals (UGX):"
            '
            'numDays
            '
            Me.numDays.DecimalPlaces = 1
            Me.numDays.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.numDays.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
            Me.numDays.Location = New System.Drawing.Point(210, 275)
            Me.numDays.Maximum = New Decimal(New Integer() {365, 0, 0, 0})
            Me.numDays.Minimum = New Decimal(New Integer() {5, 0, 0, 65536})
            Me.numDays.Name = "numDays"
            Me.numDays.Size = New System.Drawing.Size(295, 23)
            Me.numDays.TabIndex = 14
            Me.numDays.Value = New Decimal(New Integer() {2, 0, 0, 0})
            '
            'lblDays
            '
            Me.lblDays.AutoSize = True
            Me.lblDays.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblDays.ForeColor = System.Drawing.Color.Black
            Me.lblDays.Location = New System.Drawing.Point(15, 278)
            Me.lblDays.Name = "lblDays"
            Me.lblDays.Size = New System.Drawing.Size(76, 15)
            Me.lblDays.TabIndex = 13
            Me.lblDays.Text = "Days on Job:"
            '
            'numDayRate
            '
            Me.numDayRate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.numDayRate.Increment = New Decimal(New Integer() {5000, 0, 0, 0})
            Me.numDayRate.Location = New System.Drawing.Point(210, 240)
            Me.numDayRate.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
            Me.numDayRate.Name = "numDayRate"
            Me.numDayRate.Size = New System.Drawing.Size(295, 23)
            Me.numDayRate.TabIndex = 12
            Me.numDayRate.ThousandsSeparator = True
            Me.numDayRate.Value = New Decimal(New Integer() {30000, 0, 0, 0})
            '
            'lblDayRate
            '
            Me.lblDayRate.AutoSize = True
            Me.lblDayRate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblDayRate.ForeColor = System.Drawing.Color.Black
            Me.lblDayRate.Location = New System.Drawing.Point(15, 243)
            Me.lblDayRate.Name = "lblDayRate"
            Me.lblDayRate.Size = New System.Drawing.Size(117, 15)
            Me.lblDayRate.TabIndex = 11
            Me.lblDayRate.Text = "Day Rate/Staff (UGX):"
            '
            'numTeamMembers
            '
            Me.numTeamMembers.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.numTeamMembers.Location = New System.Drawing.Point(210, 205)
            Me.numTeamMembers.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
            Me.numTeamMembers.Name = "numTeamMembers"
            Me.numTeamMembers.Size = New System.Drawing.Size(295, 23)
            Me.numTeamMembers.TabIndex = 10
            Me.numTeamMembers.Value = New Decimal(New Integer() {7, 0, 0, 0})
            '
            'lblTeamMembers
            '
            Me.lblTeamMembers.AutoSize = True
            Me.lblTeamMembers.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblTeamMembers.ForeColor = System.Drawing.Color.Black
            Me.lblTeamMembers.Location = New System.Drawing.Point(15, 208)
            Me.lblTeamMembers.Name = "lblTeamMembers"
            Me.lblTeamMembers.Size = New System.Drawing.Size(126, 15)
            Me.lblTeamMembers.TabIndex = 9
            Me.lblTeamMembers.Text = "Team Members (Staff):"
            '
            'cboService
            '
            Me.cboService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboService.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.cboService.FormattingEnabled = True
            Me.cboService.Location = New System.Drawing.Point(210, 168)
            Me.cboService.Name = "cboService"
            Me.cboService.Size = New System.Drawing.Size(295, 23)
            Me.cboService.TabIndex = 8
            '
            'lblService
            '
            Me.lblService.AutoSize = True
            Me.lblService.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblService.ForeColor = System.Drawing.Color.Black
            Me.lblService.Location = New System.Drawing.Point(15, 171)
            Me.lblService.Name = "lblService"
            Me.lblService.Size = New System.Drawing.Size(95, 15)
            Me.lblService.TabIndex = 7
            Me.lblService.Text = "Primary Service:"
            '
            'lblGuideBenchmark
            '
            Me.lblGuideBenchmark.AutoSize = True
            Me.lblGuideBenchmark.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
            Me.lblGuideBenchmark.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.lblGuideBenchmark.Location = New System.Drawing.Point(210, 137)
            Me.lblGuideBenchmark.Name = "lblGuideBenchmark"
            Me.lblGuideBenchmark.Size = New System.Drawing.Size(217, 15)
            Me.lblGuideBenchmark.TabIndex = 6
            Me.lblGuideBenchmark.Text = "Recommended Margin Benchmark: 25%–35%"
            '
            'cboJobType
            '
            Me.cboJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboJobType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.cboJobType.FormattingEnabled = True
            Me.cboJobType.Location = New System.Drawing.Point(210, 105)
            Me.cboJobType.Name = "cboJobType"
            Me.cboJobType.Size = New System.Drawing.Size(295, 23)
            Me.cboJobType.TabIndex = 5
            '
            'lblJobType
            '
            Me.lblJobType.AutoSize = True
            Me.lblJobType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblJobType.ForeColor = System.Drawing.Color.Black
            Me.lblJobType.Location = New System.Drawing.Point(15, 108)
            Me.lblJobType.Name = "lblJobType"
            Me.lblJobType.Size = New System.Drawing.Size(107, 15)
            Me.lblJobType.TabIndex = 4
            Me.lblJobType.Text = "Job Classification:"
            '
            'txtJobName
            '
            Me.txtJobName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtJobName.Location = New System.Drawing.Point(210, 68)
            Me.txtJobName.Name = "txtJobName"
            Me.txtJobName.Size = New System.Drawing.Size(295, 23)
            Me.txtJobName.TabIndex = 3
            Me.txtJobName.Text = "Bukiika"
            '
            'lblJobName
            '
            Me.lblJobName.AutoSize = True
            Me.lblJobName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblJobName.ForeColor = System.Drawing.Color.Black
            Me.lblJobName.Location = New System.Drawing.Point(15, 71)
            Me.lblJobName.Name = "lblJobName"
            Me.lblJobName.Size = New System.Drawing.Size(130, 15)
            Me.lblJobName.TabIndex = 2
            Me.lblJobName.Text = "Job / Site Description:"
            '
            'cboClient
            '
            Me.cboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboClient.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.cboClient.FormattingEnabled = True
            Me.cboClient.Location = New System.Drawing.Point(210, 31)
            Me.cboClient.Name = "cboClient"
            Me.cboClient.Size = New System.Drawing.Size(295, 23)
            Me.cboClient.TabIndex = 1
            '
            'lblClient
            '
            Me.lblClient.AutoSize = True
            Me.lblClient.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblClient.ForeColor = System.Drawing.Color.Black
            Me.lblClient.Location = New System.Drawing.Point(15, 34)
            Me.lblClient.Name = "lblClient"
            Me.lblClient.Size = New System.Drawing.Size(83, 15)
            Me.lblClient.TabIndex = 0
            Me.lblClient.Text = "Select Client:"
            '
            'grpCostBreakdown
            '
            Me.grpCostBreakdown.BackColor = System.Drawing.Color.White
            Me.grpCostBreakdown.Controls.Add(Me.lblLaborWarning)
            Me.grpCostBreakdown.Controls.Add(Me.lblLaborPercent)
            Me.grpCostBreakdown.Controls.Add(Me.lblProfitAtSuggested)
            Me.grpCostBreakdown.Controls.Add(Me.pnlSuggestedPrice)
            Me.grpCostBreakdown.Controls.Add(Me.lblTotalCostVal)
            Me.grpCostBreakdown.Controls.Add(Me.lblTotalCostText)
            Me.grpCostBreakdown.Controls.Add(Me.lblOverheadVal)
            Me.grpCostBreakdown.Controls.Add(Me.lblOverheadText)
            Me.grpCostBreakdown.Controls.Add(Me.lblEquipmentVal)
            Me.grpCostBreakdown.Controls.Add(Me.lblEquipmentText)
            Me.grpCostBreakdown.Controls.Add(Me.lblTransportVal)
            Me.grpCostBreakdown.Controls.Add(Me.lblTransportText)
            Me.grpCostBreakdown.Controls.Add(Me.lblSuppliesVal)
            Me.grpCostBreakdown.Controls.Add(Me.lblSuppliesText)
            Me.grpCostBreakdown.Controls.Add(Me.lblLaborCostVal)
            Me.grpCostBreakdown.Controls.Add(Me.lblLaborCostText)
            Me.grpCostBreakdown.Dock = System.Windows.Forms.DockStyle.Fill
            Me.grpCostBreakdown.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.grpCostBreakdown.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.grpCostBreakdown.Location = New System.Drawing.Point(533, 3)
            Me.grpCostBreakdown.Name = "grpCostBreakdown"
            Me.grpCostBreakdown.Size = New System.Drawing.Size(524, 364)
            Me.grpCostBreakdown.TabIndex = 1
            Me.grpCostBreakdown.TabStop = False
            Me.grpCostBreakdown.Text = "2. Cost Breakdown & Suggested Price"
            '
            'lblLaborWarning
            '
            Me.lblLaborWarning.AutoSize = True
            Me.lblLaborWarning.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblLaborWarning.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(47, Byte), Integer))
            Me.lblLaborWarning.Location = New System.Drawing.Point(15, 335)
            Me.lblLaborWarning.Name = "lblLaborWarning"
            Me.lblLaborWarning.Size = New System.Drawing.Size(359, 15)
            Me.lblLaborWarning.TabIndex = 15
            Me.lblLaborWarning.Text = "⚠️ Reference Warning: Labor % is outside 45–60% benchmark band"
            Me.lblLaborWarning.Visible = False
            '
            'lblLaborPercent
            '
            Me.lblLaborPercent.AutoSize = True
            Me.lblLaborPercent.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblLaborPercent.ForeColor = System.Drawing.Color.Black
            Me.lblLaborPercent.Location = New System.Drawing.Point(15, 310)
            Me.lblLaborPercent.Name = "lblLaborPercent"
            Me.lblLaborPercent.Size = New System.Drawing.Size(258, 15)
            Me.lblLaborPercent.TabIndex = 14
            Me.lblLaborPercent.Text = "Labor % of Suggested Price: 36.5% (Ref: 45–60%)"
            '
            'lblProfitAtSuggested
            '
            Me.lblProfitAtSuggested.AutoSize = True
            Me.lblProfitAtSuggested.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblProfitAtSuggested.ForeColor = System.Drawing.Color.Black
            Me.lblProfitAtSuggested.Location = New System.Drawing.Point(15, 285)
            Me.lblProfitAtSuggested.Name = "lblProfitAtSuggested"
            Me.lblProfitAtSuggested.Size = New System.Drawing.Size(222, 15)
            Me.lblProfitAtSuggested.TabIndex = 13
            Me.lblProfitAtSuggested.Text = "Profit at Suggested Price: UGX 402,500"
            '
            'pnlSuggestedPrice
            '
            Me.pnlSuggestedPrice.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.pnlSuggestedPrice.Controls.Add(Me.lblSuggestedPriceVal)
            Me.pnlSuggestedPrice.Controls.Add(Me.lblSuggestedPriceTitle)
            Me.pnlSuggestedPrice.Location = New System.Drawing.Point(15, 225)
            Me.pnlSuggestedPrice.Name = "pnlSuggestedPrice"
            Me.pnlSuggestedPrice.Padding = New System.Windows.Forms.Padding(10)
            Me.pnlSuggestedPrice.Size = New System.Drawing.Size(490, 48)
            Me.pnlSuggestedPrice.TabIndex = 12
            '
            'lblSuggestedPriceVal
            '
            Me.lblSuggestedPriceVal.Dock = System.Windows.Forms.DockStyle.Right
            Me.lblSuggestedPriceVal.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblSuggestedPriceVal.ForeColor = System.Drawing.Color.White
            Me.lblSuggestedPriceVal.Location = New System.Drawing.Point(230, 10)
            Me.lblSuggestedPriceVal.Name = "lblSuggestedPriceVal"
            Me.lblSuggestedPriceVal.Size = New System.Drawing.Size(250, 28)
            Me.lblSuggestedPriceVal.TabIndex = 1
            Me.lblSuggestedPriceVal.Text = "UGX 1,150,000"
            Me.lblSuggestedPriceVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSuggestedPriceTitle
            '
            Me.lblSuggestedPriceTitle.AutoSize = True
            Me.lblSuggestedPriceTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblSuggestedPriceTitle.ForeColor = System.Drawing.Color.White
            Me.lblSuggestedPriceTitle.Location = New System.Drawing.Point(10, 14)
            Me.lblSuggestedPriceTitle.Name = "lblSuggestedPriceTitle"
            Me.lblSuggestedPriceTitle.Size = New System.Drawing.Size(184, 19)
            Me.lblSuggestedPriceTitle.TabIndex = 0
            Me.lblSuggestedPriceTitle.Text = "SUGGESTED PRICE (35%):"
            '
            'lblTotalCostVal
            '
            Me.lblTotalCostVal.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblTotalCostVal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.lblTotalCostVal.Location = New System.Drawing.Point(340, 185)
            Me.lblTotalCostVal.Name = "lblTotalCostVal"
            Me.lblTotalCostVal.Size = New System.Drawing.Size(165, 20)
            Me.lblTotalCostVal.TabIndex = 11
            Me.lblTotalCostVal.Text = "UGX 747,500"
            Me.lblTotalCostVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTotalCostText
            '
            Me.lblTotalCostText.AutoSize = True
            Me.lblTotalCostText.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblTotalCostText.ForeColor = System.Drawing.Color.Black
            Me.lblTotalCostText.Location = New System.Drawing.Point(15, 185)
            Me.lblTotalCostText.Name = "lblTotalCostText"
            Me.lblTotalCostText.Size = New System.Drawing.Size(95, 19)
            Me.lblTotalCostText.TabIndex = 10
            Me.lblTotalCostText.Text = "TOTAL COST:"
            '
            'lblOverheadVal
            '
            Me.lblOverheadVal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblOverheadVal.ForeColor = System.Drawing.Color.Black
            Me.lblOverheadVal.Location = New System.Drawing.Point(340, 155)
            Me.lblOverheadVal.Name = "lblOverheadVal"
            Me.lblOverheadVal.Size = New System.Drawing.Size(165, 18)
            Me.lblOverheadVal.TabIndex = 9
            Me.lblOverheadVal.Text = "UGX 12,500"
            Me.lblOverheadVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblOverheadText
            '
            Me.lblOverheadText.AutoSize = True
            Me.lblOverheadText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblOverheadText.ForeColor = System.Drawing.Color.Black
            Me.lblOverheadText.Location = New System.Drawing.Point(15, 155)
            Me.lblOverheadText.Name = "lblOverheadText"
            Me.lblOverheadText.Size = New System.Drawing.Size(120, 15)
            Me.lblOverheadText.TabIndex = 8
            Me.lblOverheadText.Text = "Overhead Allocation:"
            '
            'lblEquipmentVal
            '
            Me.lblEquipmentVal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblEquipmentVal.ForeColor = System.Drawing.Color.Black
            Me.lblEquipmentVal.Location = New System.Drawing.Point(340, 125)
            Me.lblEquipmentVal.Name = "lblEquipmentVal"
            Me.lblEquipmentVal.Size = New System.Drawing.Size(165, 18)
            Me.lblEquipmentVal.TabIndex = 7
            Me.lblEquipmentVal.Text = "UGX 15,000"
            Me.lblEquipmentVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblEquipmentText
            '
            Me.lblEquipmentText.AutoSize = True
            Me.lblEquipmentText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblEquipmentText.ForeColor = System.Drawing.Color.Black
            Me.lblEquipmentText.Location = New System.Drawing.Point(15, 125)
            Me.lblEquipmentText.Name = "lblEquipmentText"
            Me.lblEquipmentText.Size = New System.Drawing.Size(95, 15)
            Me.lblEquipmentText.TabIndex = 6
            Me.lblEquipmentText.Text = "Equipment Wear:"
            '
            'lblTransportVal
            '
            Me.lblTransportVal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblTransportVal.ForeColor = System.Drawing.Color.Black
            Me.lblTransportVal.Location = New System.Drawing.Point(340, 95)
            Me.lblTransportVal.Name = "lblTransportVal"
            Me.lblTransportVal.Size = New System.Drawing.Size(165, 18)
            Me.lblTransportVal.TabIndex = 5
            Me.lblTransportVal.Text = "UGX 200,000"
            Me.lblTransportVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTransportText
            '
            Me.lblTransportText.AutoSize = True
            Me.lblTransportText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblTransportText.ForeColor = System.Drawing.Color.Black
            Me.lblTransportText.Location = New System.Drawing.Point(15, 95)
            Me.lblTransportText.Name = "lblTransportText"
            Me.lblTransportText.Size = New System.Drawing.Size(89, 15)
            Me.lblTransportText.TabIndex = 4
            Me.lblTransportText.Text = "Transport Cost:"
            '
            'lblSuppliesVal
            '
            Me.lblSuppliesVal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSuppliesVal.ForeColor = System.Drawing.Color.Black
            Me.lblSuppliesVal.Location = New System.Drawing.Point(340, 65)
            Me.lblSuppliesVal.Name = "lblSuppliesVal"
            Me.lblSuppliesVal.Size = New System.Drawing.Size(165, 18)
            Me.lblSuppliesVal.TabIndex = 3
            Me.lblSuppliesVal.Text = "UGX 100,000"
            Me.lblSuppliesVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSuppliesText
            '
            Me.lblSuppliesText.AutoSize = True
            Me.lblSuppliesText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSuppliesText.ForeColor = System.Drawing.Color.Black
            Me.lblSuppliesText.Location = New System.Drawing.Point(15, 65)
            Me.lblSuppliesText.Name = "lblSuppliesText"
            Me.lblSuppliesText.Size = New System.Drawing.Size(120, 15)
            Me.lblSuppliesText.TabIndex = 2
            Me.lblSuppliesText.Text = "Supplies && Chemicals:"
            '
            'lblLaborCostVal
            '
            Me.lblLaborCostVal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblLaborCostVal.ForeColor = System.Drawing.Color.Black
            Me.lblLaborCostVal.Location = New System.Drawing.Point(340, 35)
            Me.lblLaborCostVal.Name = "lblLaborCostVal"
            Me.lblLaborCostVal.Size = New System.Drawing.Size(165, 18)
            Me.lblLaborCostVal.TabIndex = 1
            Me.lblLaborCostVal.Text = "UGX 420,000"
            Me.lblLaborCostVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLaborCostText
            '
            Me.lblLaborCostText.AutoSize = True
            Me.lblLaborCostText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblLaborCostText.ForeColor = System.Drawing.Color.Black
            Me.lblLaborCostText.Location = New System.Drawing.Point(15, 35)
            Me.lblLaborCostText.Name = "lblLaborCostText"
            Me.lblLaborCostText.Size = New System.Drawing.Size(107, 15)
            Me.lblLaborCostText.TabIndex = 0
            Me.lblLaborCostText.Text = "Direct Labor Cost:"
            '
            'grpActualQuote
            '
            Me.grpActualQuote.BackColor = System.Drawing.Color.White
            Me.grpActualQuote.Controls.Add(Me.pnlVerdict)
            Me.grpActualQuote.Controls.Add(Me.lblActualMargin)
            Me.grpActualQuote.Controls.Add(Me.lblActualProfit)
            Me.grpActualQuote.Controls.Add(Me.numActualQuote)
            Me.grpActualQuote.Controls.Add(Me.lblActualQuoteInput)
            Me.grpActualQuote.Dock = System.Windows.Forms.DockStyle.Fill
            Me.grpActualQuote.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.grpActualQuote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.grpActualQuote.Location = New System.Drawing.Point(533, 373)
            Me.grpActualQuote.Name = "grpActualQuote"
            Me.grpActualQuote.Size = New System.Drawing.Size(524, 194)
            Me.grpActualQuote.TabIndex = 2
            Me.grpActualQuote.TabStop = False
            Me.grpActualQuote.Text = "3. Check an Actual Quote Price"
            '
            'pnlVerdict
            '
            Me.pnlVerdict.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(229, Byte), Integer))
            Me.pnlVerdict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlVerdict.Controls.Add(Me.lblVerdictValue)
            Me.pnlVerdict.Controls.Add(Me.lblVerdictTitle)
            Me.pnlVerdict.Location = New System.Drawing.Point(15, 125)
            Me.pnlVerdict.Name = "pnlVerdict"
            Me.pnlVerdict.Padding = New System.Windows.Forms.Padding(10)
            Me.pnlVerdict.Size = New System.Drawing.Size(490, 48)
            Me.pnlVerdict.TabIndex = 4
            '
            'lblVerdictValue
            '
            Me.lblVerdictValue.Dock = System.Windows.Forms.DockStyle.Right
            Me.lblVerdictValue.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblVerdictValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(70, Byte), Integer))
            Me.lblVerdictValue.Location = New System.Drawing.Point(150, 10)
            Me.lblVerdictValue.Name = "lblVerdictValue"
            Me.lblVerdictValue.Size = New System.Drawing.Size(328, 26)
            Me.lblVerdictValue.TabIndex = 1
            Me.lblVerdictValue.Text = "✓ HEALTHY MARGIN"
            Me.lblVerdictValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblVerdictTitle
            '
            Me.lblVerdictTitle.AutoSize = True
            Me.lblVerdictTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblVerdictTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(70, Byte), Integer))
            Me.lblVerdictTitle.Location = New System.Drawing.Point(10, 14)
            Me.lblVerdictTitle.Name = "lblVerdictTitle"
            Me.lblVerdictTitle.Size = New System.Drawing.Size(117, 17)
            Me.lblVerdictTitle.TabIndex = 0
            Me.lblVerdictTitle.Text = "MARGIN VERDICT:"
            '
            'lblActualMargin
            '
            Me.lblActualMargin.AutoSize = True
            Me.lblActualMargin.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblActualMargin.ForeColor = System.Drawing.Color.Black
            Me.lblActualMargin.Location = New System.Drawing.Point(15, 95)
            Me.lblActualMargin.Name = "lblActualMargin"
            Me.lblActualMargin.Size = New System.Drawing.Size(183, 15)
            Me.lblActualMargin.TabIndex = 3
            Me.lblActualMargin.Text = "Actual Gross Margin %: 37.7%"
            '
            'lblActualProfit
            '
            Me.lblActualProfit.AutoSize = True
            Me.lblActualProfit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblActualProfit.ForeColor = System.Drawing.Color.Black
            Me.lblActualProfit.Location = New System.Drawing.Point(15, 68)
            Me.lblActualProfit.Name = "lblActualProfit"
            Me.lblActualProfit.Size = New System.Drawing.Size(186, 15)
            Me.lblActualProfit.TabIndex = 2
            Me.lblActualProfit.Text = "Actual Profit: UGX 452,500"
            '
            'numActualQuote
            '
            Me.numActualQuote.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.numActualQuote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.numActualQuote.Increment = New Decimal(New Integer() {50000, 0, 0, 0})
            Me.numActualQuote.Location = New System.Drawing.Point(210, 30)
            Me.numActualQuote.Maximum = New Decimal(New Integer() {500000000, 0, 0, 0})
            Me.numActualQuote.Name = "numActualQuote"
            Me.numActualQuote.Size = New System.Drawing.Size(295, 24)
            Me.numActualQuote.TabIndex = 1
            Me.numActualQuote.ThousandsSeparator = True
            Me.numActualQuote.Value = New Decimal(New Integer() {1200000, 0, 0, 0})
            '
            'lblActualQuoteInput
            '
            Me.lblActualQuoteInput.AutoSize = True
            Me.lblActualQuoteInput.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblActualQuoteInput.ForeColor = System.Drawing.Color.Black
            Me.lblActualQuoteInput.Location = New System.Drawing.Point(15, 33)
            Me.lblActualQuoteInput.Name = "lblActualQuoteInput"
            Me.lblActualQuoteInput.Size = New System.Drawing.Size(148, 15)
            Me.lblActualQuoteInput.TabIndex = 0
            Me.lblActualQuoteInput.Text = "Actual Quote Price (UGX):"
            '
            'FrmCalculator
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(249, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1100, 665)
            Me.Controls.Add(Me.tableLayout)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "FrmCalculator"
            Me.Padding = New System.Windows.Forms.Padding(20)
            Me.Text = "Pricing Calculator"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.pnlActionsTop.ResumeLayout(False)
            Me.tableLayout.ResumeLayout(False)
            Me.grpInputs.ResumeLayout(False)
            Me.grpInputs.PerformLayout()
            CType(Me.numTargetMargin, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numAvgJobs, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numMonthlyOverhead, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numEquipmentWear, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numTransport, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numSupplies, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numDays, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numDayRate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numTeamMembers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpCostBreakdown.ResumeLayout(False)
            Me.grpCostBreakdown.PerformLayout()
            Me.pnlSuggestedPrice.ResumeLayout(False)
            Me.pnlSuggestedPrice.PerformLayout()
            Me.grpActualQuote.ResumeLayout(False)
            Me.grpActualQuote.PerformLayout()
            Me.pnlVerdict.ResumeLayout(False)
            Me.pnlVerdict.PerformLayout()
            CType(Me.numActualQuote, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace
