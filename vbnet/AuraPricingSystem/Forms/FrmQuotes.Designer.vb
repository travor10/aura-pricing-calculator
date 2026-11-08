Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmQuotes
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
        Friend WithEvents pnlFilterBar As System.Windows.Forms.Panel
        Friend WithEvents lblFilterStatus As System.Windows.Forms.Label
        Friend WithEvents cboStatusFilter As System.Windows.Forms.ComboBox
        Friend WithEvents lblSearch As System.Windows.Forms.Label
        Friend WithEvents txtSearch As System.Windows.Forms.TextBox
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        Friend WithEvents splitContainer As System.Windows.Forms.SplitContainer
        Friend WithEvents dgvQuotes As System.Windows.Forms.DataGridView
        Friend WithEvents colQuoteNo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colClient As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colJobName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colJobType As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colDate As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colCreatedBy As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents pnlDetails As System.Windows.Forms.Panel
        Friend WithEvents grpWorkflow As System.Windows.Forms.GroupBox
        Friend WithEvents btnCreateJob As System.Windows.Forms.Button
        Friend WithEvents btnMarkRejected As System.Windows.Forms.Button
        Friend WithEvents btnMarkAccepted As System.Windows.Forms.Button
        Friend WithEvents btnMarkSent As System.Windows.Forms.Button
        Friend WithEvents grpSnapshot As System.Windows.Forms.GroupBox
        Friend WithEvents lblSnapVerdict As System.Windows.Forms.Label
        Friend WithEvents lblSnapMargin As System.Windows.Forms.Label
        Friend WithEvents lblSnapProfit As System.Windows.Forms.Label
        Friend WithEvents lblSnapSuggested As System.Windows.Forms.Label
        Friend WithEvents lblSnapTotalCost As System.Windows.Forms.Label
        Friend WithEvents lblSnapTeamDays As System.Windows.Forms.Label
        Friend WithEvents grpQuoteInfo As System.Windows.Forms.GroupBox
        Friend WithEvents lblSelectedStatus As System.Windows.Forms.Label
        Friend WithEvents lblSelectedAmount As System.Windows.Forms.Label
        Friend WithEvents lblSelectedClient As System.Windows.Forms.Label
        Friend WithEvents lblSelectedQuoteNo As System.Windows.Forms.Label

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.pnlHeader = New System.Windows.Forms.Panel()
            Me.lblSubtitle = New System.Windows.Forms.Label()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.pnlFilterBar = New System.Windows.Forms.Panel()
            Me.btnRefresh = New System.Windows.Forms.Button()
            Me.txtSearch = New System.Windows.Forms.TextBox()
            Me.lblSearch = New System.Windows.Forms.Label()
            Me.cboStatusFilter = New System.Windows.Forms.ComboBox()
            Me.lblFilterStatus = New System.Windows.Forms.Label()
            Me.splitContainer = New System.Windows.Forms.SplitContainer()
            Me.dgvQuotes = New System.Windows.Forms.DataGridView()
            Me.colQuoteNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colClient = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colJobName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colJobType = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colCreatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlDetails = New System.Windows.Forms.Panel()
            Me.grpWorkflow = New System.Windows.Forms.GroupBox()
            Me.btnCreateJob = New System.Windows.Forms.Button()
            Me.btnMarkRejected = New System.Windows.Forms.Button()
            Me.btnMarkAccepted = New System.Windows.Forms.Button()
            Me.btnMarkSent = New System.Windows.Forms.Button()
            Me.grpSnapshot = New System.Windows.Forms.GroupBox()
            Me.lblSnapVerdict = New System.Windows.Forms.Label()
            Me.lblSnapMargin = New System.Windows.Forms.Label()
            Me.lblSnapProfit = New System.Windows.Forms.Label()
            Me.lblSnapSuggested = New System.Windows.Forms.Label()
            Me.lblSnapTotalCost = New System.Windows.Forms.Label()
            Me.lblSnapTeamDays = New System.Windows.Forms.Label()
            Me.grpQuoteInfo = New System.Windows.Forms.GroupBox()
            Me.lblSelectedStatus = New System.Windows.Forms.Label()
            Me.lblSelectedAmount = New System.Windows.Forms.Label()
            Me.lblSelectedClient = New System.Windows.Forms.Label()
            Me.lblSelectedQuoteNo = New System.Windows.Forms.Label()
            Me.pnlHeader.SuspendLayout()
            Me.pnlFilterBar.SuspendLayout()
            CType(Me.splitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.splitContainer.Panel1.SuspendLayout()
            Me.splitContainer.Panel2.SuspendLayout()
            Me.splitContainer.SuspendLayout()
            CType(Me.dgvQuotes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlDetails.SuspendLayout()
            Me.grpWorkflow.SuspendLayout()
            Me.grpSnapshot.SuspendLayout()
            Me.grpQuoteInfo.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlHeader
            '
            Me.pnlHeader.Controls.Add(Me.lblSubtitle)
            Me.pnlHeader.Controls.Add(Me.lblTitle)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(20, 20)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(1060, 50)
            Me.pnlHeader.TabIndex = 0
            '
            'lblSubtitle
            '
            Me.lblSubtitle.AutoSize = True
            Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(130, Byte), Integer))
            Me.lblSubtitle.Location = New System.Drawing.Point(2, 30)
            Me.lblSubtitle.Name = "lblSubtitle"
            Me.lblSubtitle.Size = New System.Drawing.Size(433, 15)
            Me.lblSubtitle.TabIndex = 1
            Me.lblSubtitle.Text = "Manage quotation lifecycle (Draft ➔ Sent ➔ Accepted / Rejected) and linked jobs"
            '
            'lblTitle
            '
            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.lblTitle.Location = New System.Drawing.Point(0, 0)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(239, 30)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "Quotations Workflow"
            '
            'pnlFilterBar
            '
            Me.pnlFilterBar.BackColor = System.Drawing.Color.White
            Me.pnlFilterBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlFilterBar.Controls.Add(Me.btnRefresh)
            Me.pnlFilterBar.Controls.Add(Me.txtSearch)
            Me.pnlFilterBar.Controls.Add(Me.lblSearch)
            Me.pnlFilterBar.Controls.Add(Me.cboStatusFilter)
            Me.pnlFilterBar.Controls.Add(Me.lblFilterStatus)
            Me.pnlFilterBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlFilterBar.Location = New System.Drawing.Point(20, 70)
            Me.pnlFilterBar.Name = "pnlFilterBar"
            Me.pnlFilterBar.Padding = New System.Windows.Forms.Padding(10)
            Me.pnlFilterBar.Size = New System.Drawing.Size(1060, 48)
            Me.pnlFilterBar.TabIndex = 1
            '
            'btnRefresh
            '
            Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnRefresh.ForeColor = System.Drawing.Color.White
            Me.btnRefresh.Location = New System.Drawing.Point(960, 8)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(85, 30)
            Me.btnRefresh.TabIndex = 4
            Me.btnRefresh.Text = "Refresh"
            Me.btnRefresh.UseVisualStyleBackColor = False
            '
            'txtSearch
            '
            Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtSearch.Location = New System.Drawing.Point(380, 11)
            Me.txtSearch.Name = "txtSearch"
            Me.txtSearch.PlaceholderText = "Search by quote number, client name, or job..."
            Me.txtSearch.Size = New System.Drawing.Size(565, 24)
            Me.txtSearch.TabIndex = 3
            '
            'lblSearch
            '
            Me.lblSearch.AutoSize = True
            Me.lblSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblSearch.Location = New System.Drawing.Point(325, 15)
            Me.lblSearch.Name = "lblSearch"
            Me.lblSearch.Size = New System.Drawing.Size(48, 15)
            Me.lblSearch.TabIndex = 2
            Me.lblSearch.Text = "Search:"
            '
            'cboStatusFilter
            '
            Me.cboStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboStatusFilter.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.cboStatusFilter.FormattingEnabled = True
            Me.cboStatusFilter.Items.AddRange(New Object() {"All", "Draft", "Sent", "Accepted", "Rejected"})
            Me.cboStatusFilter.Location = New System.Drawing.Point(90, 11)
            Me.cboStatusFilter.Name = "cboStatusFilter"
            Me.cboStatusFilter.Size = New System.Drawing.Size(180, 24)
            Me.cboStatusFilter.TabIndex = 1
            '
            'lblFilterStatus
            '
            Me.lblFilterStatus.AutoSize = True
            Me.lblFilterStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblFilterStatus.Location = New System.Drawing.Point(10, 15)
            Me.lblFilterStatus.Name = "lblFilterStatus"
            Me.lblFilterStatus.Size = New System.Drawing.Size(75, 15)
            Me.lblFilterStatus.TabIndex = 0
            Me.lblFilterStatus.Text = "Status Filter:"
            '
            'splitContainer
            '
            Me.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
            Me.splitContainer.Location = New System.Drawing.Point(20, 118)
            Me.splitContainer.Name = "splitContainer"
            '
            'splitContainer.Panel1
            '
            Me.splitContainer.Panel1.Controls.Add(Me.dgvQuotes)
            '
            'splitContainer.Panel2
            '
            Me.splitContainer.Panel2.Controls.Add(Me.pnlDetails)
            Me.splitContainer.Size = New System.Drawing.Size(1060, 527)
            Me.splitContainer.SplitterDistance = 680
            Me.splitContainer.TabIndex = 2
            '
            'dgvQuotes
            '
            Me.dgvQuotes.AllowUserToAddRows = False
            Me.dgvQuotes.AllowUserToDeleteRows = False
            Me.dgvQuotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvQuotes.BackgroundColor = System.Drawing.Color.White
            Me.dgvQuotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(244, Byte), Integer))
            dataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            dataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(4)
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvQuotes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
            Me.dgvQuotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvQuotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colQuoteNo, Me.colClient, Me.colJobName, Me.colJobType, Me.colDate, Me.colAmount, Me.colStatus, Me.colCreatedBy})
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            dataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(244, Byte), Integer))
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvQuotes.DefaultCellStyle = dataGridViewCellStyle2
            Me.dgvQuotes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvQuotes.EnableHeadersVisualStyles = False
            Me.dgvQuotes.Location = New System.Drawing.Point(0, 0)
            Me.dgvQuotes.MultiSelect = False
            Me.dgvQuotes.Name = "dgvQuotes"
            Me.dgvQuotes.ReadOnly = True
            Me.dgvQuotes.RowHeadersVisible = False
            Me.dgvQuotes.RowTemplate.Height = 28
            Me.dgvQuotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvQuotes.Size = New System.Drawing.Size(680, 527)
            Me.dgvQuotes.TabIndex = 0
            '
            'colQuoteNo
            '
            Me.colQuoteNo.FillWeight = 22.0!
            Me.colQuoteNo.HeaderText = "Quote No"
            Me.colQuoteNo.Name = "colQuoteNo"
            Me.colQuoteNo.ReadOnly = True
            '
            'colClient
            '
            Me.colClient.FillWeight = 30.0!
            Me.colClient.HeaderText = "Client"
            Me.colClient.Name = "colClient"
            Me.colClient.ReadOnly = True
            '
            'colJobName
            '
            Me.colJobName.FillWeight = 22.0!
            Me.colJobName.HeaderText = "Job / Site"
            Me.colJobName.Name = "colJobName"
            Me.colJobName.ReadOnly = True
            '
            'colJobType
            '
            Me.colJobType.FillWeight = 25.0!
            Me.colJobType.HeaderText = "Type"
            Me.colJobType.Name = "colJobType"
            Me.colJobType.ReadOnly = True
            '
            'colDate
            '
            Me.colDate.FillWeight = 18.0!
            Me.colDate.HeaderText = "Date"
            Me.colDate.Name = "colDate"
            Me.colDate.ReadOnly = True
            '
            'colAmount
            '
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.colAmount.DefaultCellStyle = dataGridViewCellStyle3
            Me.colAmount.FillWeight = 24.0!
            Me.colAmount.HeaderText = "Amount (UGX)"
            Me.colAmount.Name = "colAmount"
            Me.colAmount.ReadOnly = True
            '
            'colStatus
            '
            Me.colStatus.FillWeight = 18.0!
            Me.colStatus.HeaderText = "Status"
            Me.colStatus.Name = "colStatus"
            Me.colStatus.ReadOnly = True
            '
            'colCreatedBy
            '
            Me.colCreatedBy.FillWeight = 16.0!
            Me.colCreatedBy.HeaderText = "User"
            Me.colCreatedBy.Name = "colCreatedBy"
            Me.colCreatedBy.ReadOnly = True
            '
            'pnlDetails
            '
            Me.pnlDetails.BackColor = System.Drawing.Color.White
            Me.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlDetails.Controls.Add(Me.grpWorkflow)
            Me.pnlDetails.Controls.Add(Me.grpSnapshot)
            Me.pnlDetails.Controls.Add(Me.grpQuoteInfo)
            Me.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlDetails.Location = New System.Drawing.Point(0, 0)
            Me.pnlDetails.Name = "pnlDetails"
            Me.pnlDetails.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlDetails.Size = New System.Drawing.Size(376, 527)
            Me.pnlDetails.TabIndex = 0
            '
            'grpWorkflow
            '
            Me.grpWorkflow.Controls.Add(Me.btnCreateJob)
            Me.grpWorkflow.Controls.Add(Me.btnMarkRejected)
            Me.grpWorkflow.Controls.Add(Me.btnMarkAccepted)
            Me.grpWorkflow.Controls.Add(Me.btnMarkSent)
            Me.grpWorkflow.Dock = System.Windows.Forms.DockStyle.Fill
            Me.grpWorkflow.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.grpWorkflow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.grpWorkflow.Location = New System.Drawing.Point(12, 332)
            Me.grpWorkflow.Name = "grpWorkflow"
            Me.grpWorkflow.Padding = New System.Windows.Forms.Padding(10)
            Me.grpWorkflow.Size = New System.Drawing.Size(350, 181)
            Me.grpWorkflow.TabIndex = 2
            Me.grpWorkflow.TabStop = False
            Me.grpWorkflow.Text = "Quotation Lifecycle Actions"
            '
            'btnCreateJob
            '
            Me.btnCreateJob.BackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(160, Byte), Integer))
            Me.btnCreateJob.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCreateJob.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnCreateJob.Enabled = False
            Me.btnCreateJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCreateJob.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnCreateJob.ForeColor = System.Drawing.Color.White
            Me.btnCreateJob.Location = New System.Drawing.Point(10, 126)
            Me.btnCreateJob.Name = "btnCreateJob"
            Me.btnCreateJob.Size = New System.Drawing.Size(330, 36)
            Me.btnCreateJob.TabIndex = 3
            Me.btnCreateJob.Text = "📅 Schedule Job (Accepted Only)"
            Me.btnCreateJob.UseVisualStyleBackColor = False
            '
            'btnMarkRejected
            '
            Me.btnMarkRejected.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(47, Byte), Integer))
            Me.btnMarkRejected.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnMarkRejected.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnMarkRejected.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnMarkRejected.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnMarkRejected.ForeColor = System.Drawing.Color.White
            Me.btnMarkRejected.Location = New System.Drawing.Point(10, 92)
            Me.btnMarkRejected.Name = "btnMarkRejected"
            Me.btnMarkRejected.Size = New System.Drawing.Size(330, 34)
            Me.btnMarkRejected.TabIndex = 2
            Me.btnMarkRejected.Text = "✗ Mark as Rejected"
            Me.btnMarkRejected.UseVisualStyleBackColor = False
            '
            'btnMarkAccepted
            '
            Me.btnMarkAccepted.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.btnMarkAccepted.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnMarkAccepted.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnMarkAccepted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnMarkAccepted.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnMarkAccepted.ForeColor = System.Drawing.Color.White
            Me.btnMarkAccepted.Location = New System.Drawing.Point(10, 58)
            Me.btnMarkAccepted.Name = "btnMarkAccepted"
            Me.btnMarkAccepted.Size = New System.Drawing.Size(330, 34)
            Me.btnMarkAccepted.TabIndex = 1
            Me.btnMarkAccepted.Text = "✓ Mark as Accepted"
            Me.btnMarkAccepted.UseVisualStyleBackColor = False
            '
            'btnMarkSent
            '
            Me.btnMarkSent.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.btnMarkSent.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnMarkSent.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnMarkSent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnMarkSent.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnMarkSent.ForeColor = System.Drawing.Color.White
            Me.btnMarkSent.Location = New System.Drawing.Point(10, 26)
            Me.btnMarkSent.Name = "btnMarkSent"
            Me.btnMarkSent.Size = New System.Drawing.Size(330, 32)
            Me.btnMarkSent.TabIndex = 0
            Me.btnMarkSent.Text = "📤 Mark as Sent to Client"
            Me.btnMarkSent.UseVisualStyleBackColor = False
            '
            'grpSnapshot
            '
            Me.grpSnapshot.Controls.Add(Me.lblSnapVerdict)
            Me.grpSnapshot.Controls.Add(Me.lblSnapMargin)
            Me.grpSnapshot.Controls.Add(Me.lblSnapProfit)
            Me.grpSnapshot.Controls.Add(Me.lblSnapSuggested)
            Me.grpSnapshot.Controls.Add(Me.lblSnapTotalCost)
            Me.grpSnapshot.Controls.Add(Me.lblSnapTeamDays)
            Me.grpSnapshot.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpSnapshot.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.grpSnapshot.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.grpSnapshot.Location = New System.Drawing.Point(12, 142)
            Me.grpSnapshot.Name = "grpSnapshot"
            Me.grpSnapshot.Padding = New System.Windows.Forms.Padding(10)
            Me.grpSnapshot.Size = New System.Drawing.Size(350, 190)
            Me.grpSnapshot.TabIndex = 1
            Me.grpSnapshot.TabStop = False
            Me.grpSnapshot.Text = "Locked Pricing Snapshot"
            '
            'lblSnapVerdict
            '
            Me.lblSnapVerdict.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblSnapVerdict.ForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.lblSnapVerdict.Location = New System.Drawing.Point(10, 155)
            Me.lblSnapVerdict.Name = "lblSnapVerdict"
            Me.lblSnapVerdict.Size = New System.Drawing.Size(330, 20)
            Me.lblSnapVerdict.TabIndex = 5
            Me.lblSnapVerdict.Text = "Verdict: HEALTHY MARGIN"
            '
            'lblSnapMargin
            '
            Me.lblSnapMargin.AutoSize = True
            Me.lblSnapMargin.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSnapMargin.ForeColor = System.Drawing.Color.Black
            Me.lblSnapMargin.Location = New System.Drawing.Point(10, 130)
            Me.lblSnapMargin.Name = "lblSnapMargin"
            Me.lblSnapMargin.Size = New System.Drawing.Size(164, 15)
            Me.lblSnapMargin.TabIndex = 4
            Me.lblSnapMargin.Text = "Actual Gross Margin %: 37.7%"
            '
            'lblSnapProfit
            '
            Me.lblSnapProfit.AutoSize = True
            Me.lblSnapProfit.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSnapProfit.ForeColor = System.Drawing.Color.Black
            Me.lblSnapProfit.Location = New System.Drawing.Point(10, 105)
            Me.lblSnapProfit.Name = "lblSnapProfit"
            Me.lblSnapProfit.Size = New System.Drawing.Size(161, 15)
            Me.lblSnapProfit.TabIndex = 3
            Me.lblSnapProfit.Text = "Actual Profit: UGX 452,500"
            '
            'lblSnapSuggested
            '
            Me.lblSnapSuggested.AutoSize = True
            Me.lblSnapSuggested.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSnapSuggested.ForeColor = System.Drawing.Color.Black
            Me.lblSnapSuggested.Location = New System.Drawing.Point(10, 80)
            Me.lblSnapSuggested.Name = "lblSnapSuggested"
            Me.lblSnapSuggested.Size = New System.Drawing.Size(183, 15)
            Me.lblSnapSuggested.TabIndex = 2
            Me.lblSnapSuggested.Text = "Suggested Price: UGX 1,150,000"
            '
            'lblSnapTotalCost
            '
            Me.lblSnapTotalCost.AutoSize = True
            Me.lblSnapTotalCost.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSnapTotalCost.ForeColor = System.Drawing.Color.Black
            Me.lblSnapTotalCost.Location = New System.Drawing.Point(10, 55)
            Me.lblSnapTotalCost.Name = "lblSnapTotalCost"
            Me.lblSnapTotalCost.Size = New System.Drawing.Size(149, 15)
            Me.lblSnapTotalCost.TabIndex = 1
            Me.lblSnapTotalCost.Text = "Total Job Cost: UGX 747,500"
            '
            'lblSnapTeamDays
            '
            Me.lblSnapTeamDays.AutoSize = True
            Me.lblSnapTeamDays.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSnapTeamDays.ForeColor = System.Drawing.Color.Black
            Me.lblSnapTeamDays.Location = New System.Drawing.Point(10, 30)
            Me.lblSnapTeamDays.Name = "lblSnapTeamDays"
            Me.lblSnapTeamDays.Size = New System.Drawing.Size(193, 15)
            Me.lblSnapTeamDays.TabIndex = 0
            Me.lblSnapTeamDays.Text = "Team: 7 staff  |  2 days @ UGX 30k"
            '
            'grpQuoteInfo
            '
            Me.grpQuoteInfo.Controls.Add(Me.lblSelectedStatus)
            Me.grpQuoteInfo.Controls.Add(Me.lblSelectedAmount)
            Me.grpQuoteInfo.Controls.Add(Me.lblSelectedClient)
            Me.grpQuoteInfo.Controls.Add(Me.lblSelectedQuoteNo)
            Me.grpQuoteInfo.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpQuoteInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.grpQuoteInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.grpQuoteInfo.Location = New System.Drawing.Point(12, 12)
            Me.grpQuoteInfo.Name = "grpQuoteInfo"
            Me.grpQuoteInfo.Padding = New System.Windows.Forms.Padding(10)
            Me.grpQuoteInfo.Size = New System.Drawing.Size(350, 130)
            Me.grpQuoteInfo.TabIndex = 0
            Me.grpQuoteInfo.TabStop = False
            Me.grpQuoteInfo.Text = "Selected Quotation Header"
            '
            'lblSelectedStatus
            '
            Me.lblSelectedStatus.AutoSize = True
            Me.lblSelectedStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblSelectedStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.lblSelectedStatus.Location = New System.Drawing.Point(10, 95)
            Me.lblSelectedStatus.Name = "lblSelectedStatus"
            Me.lblSelectedStatus.Size = New System.Drawing.Size(81, 15)
            Me.lblSelectedStatus.TabIndex = 3
            Me.lblSelectedStatus.Text = "Status: DRAFT"
            '
            'lblSelectedAmount
            '
            Me.lblSelectedAmount.AutoSize = True
            Me.lblSelectedAmount.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblSelectedAmount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.lblSelectedAmount.Location = New System.Drawing.Point(10, 72)
            Me.lblSelectedAmount.Name = "lblSelectedAmount"
            Me.lblSelectedAmount.Size = New System.Drawing.Size(183, 17)
            Me.lblSelectedAmount.TabIndex = 2
            Me.lblSelectedAmount.Text = "Amount: UGX 1,200,000"
            '
            'lblSelectedClient
            '
            Me.lblSelectedClient.AutoSize = True
            Me.lblSelectedClient.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSelectedClient.ForeColor = System.Drawing.Color.Black
            Me.lblSelectedClient.Location = New System.Drawing.Point(10, 50)
            Me.lblSelectedClient.Name = "lblSelectedClient"
            Me.lblSelectedClient.Size = New System.Drawing.Size(133, 15)
            Me.lblSelectedClient.TabIndex = 1
            Me.lblSelectedClient.Text = "Client: Dr. James Bukiika"
            '
            'lblSelectedQuoteNo
            '
            Me.lblSelectedQuoteNo.AutoSize = True
            Me.lblSelectedQuoteNo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblSelectedQuoteNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.lblSelectedQuoteNo.Location = New System.Drawing.Point(10, 25)
            Me.lblSelectedQuoteNo.Name = "lblSelectedQuoteNo"
            Me.lblSelectedQuoteNo.Size = New System.Drawing.Size(131, 19)
            Me.lblSelectedQuoteNo.TabIndex = 0
            Me.lblSelectedQuoteNo.Text = "Quote: QUO-0001"
            '
            'FrmQuotes
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(249, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1100, 665)
            Me.Controls.Add(Me.splitContainer)
            Me.Controls.Add(Me.pnlFilterBar)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "FrmQuotes"
            Me.Padding = New System.Windows.Forms.Padding(20)
            Me.Text = "Quotations Workflow"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.pnlFilterBar.ResumeLayout(False)
            Me.pnlFilterBar.PerformLayout()
            Me.splitContainer.Panel1.ResumeLayout(False)
            Me.splitContainer.Panel2.ResumeLayout(False)
            CType(Me.splitContainer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.splitContainer.ResumeLayout(False)
            CType(Me.dgvQuotes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlDetails.ResumeLayout(False)
            Me.grpWorkflow.ResumeLayout(False)
            Me.grpSnapshot.ResumeLayout(False)
            Me.grpSnapshot.PerformLayout()
            Me.grpQuoteInfo.ResumeLayout(False)
            Me.grpQuoteInfo.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace
