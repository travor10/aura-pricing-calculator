Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmSettings
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
        Friend WithEvents splitContainer As System.Windows.Forms.SplitContainer
        Friend WithEvents grpCompany As System.Windows.Forms.GroupBox
        Friend WithEvents lblCompanyName As System.Windows.Forms.Label
        Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
        Friend WithEvents lblPhone As System.Windows.Forms.Label
        Friend WithEvents txtPhone As System.Windows.Forms.TextBox
        Friend WithEvents lblEmail As System.Windows.Forms.Label
        Friend WithEvents txtEmail As System.Windows.Forms.TextBox
        Friend WithEvents lblAddress As System.Windows.Forms.Label
        Friend WithEvents txtAddress As System.Windows.Forms.TextBox
        Friend WithEvents grpPrefixes As System.Windows.Forms.GroupBox
        Friend WithEvents lblQuotePrefix As System.Windows.Forms.Label
        Friend WithEvents txtQuotePrefix As System.Windows.Forms.TextBox
        Friend WithEvents lblJobPrefix As System.Windows.Forms.Label
        Friend WithEvents txtJobPrefix As System.Windows.Forms.TextBox
        Friend WithEvents lblDefaultMargin As System.Windows.Forms.Label
        Friend WithEvents numDefaultMargin As System.Windows.Forms.NumericUpDown
        Friend WithEvents grpMarginGuide As System.Windows.Forms.GroupBox
        Friend WithEvents dgvMarginGuide As System.Windows.Forms.DataGridView
        Friend WithEvents colGuideType As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colMinMargin As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colMaxMargin As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colDisplayRange As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents pnlActions As System.Windows.Forms.Panel
        Friend WithEvents btnSaveSettings As System.Windows.Forms.Button
        Friend WithEvents btnReload As System.Windows.Forms.Button

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.pnlHeader = New System.Windows.Forms.Panel()
            Me.lblSubtitle = New System.Windows.Forms.Label()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.splitContainer = New System.Windows.Forms.SplitContainer()
            Me.grpPrefixes = New System.Windows.Forms.GroupBox()
            Me.numDefaultMargin = New System.Windows.Forms.NumericUpDown()
            Me.lblDefaultMargin = New System.Windows.Forms.Label()
            Me.txtJobPrefix = New System.Windows.Forms.TextBox()
            Me.lblJobPrefix = New System.Windows.Forms.Label()
            Me.txtQuotePrefix = New System.Windows.Forms.TextBox()
            Me.lblQuotePrefix = New System.Windows.Forms.Label()
            Me.grpCompany = New System.Windows.Forms.GroupBox()
            Me.txtAddress = New System.Windows.Forms.TextBox()
            Me.lblAddress = New System.Windows.Forms.Label()
            Me.txtEmail = New System.Windows.Forms.TextBox()
            Me.lblEmail = New System.Windows.Forms.Label()
            Me.txtPhone = New System.Windows.Forms.TextBox()
            Me.lblPhone = New System.Windows.Forms.Label()
            Me.txtCompanyName = New System.Windows.Forms.TextBox()
            Me.lblCompanyName = New System.Windows.Forms.Label()
            Me.grpMarginGuide = New System.Windows.Forms.GroupBox()
            Me.dgvMarginGuide = New System.Windows.Forms.DataGridView()
            Me.colGuideType = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colMinMargin = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colMaxMargin = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colDisplayRange = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlActions = New System.Windows.Forms.Panel()
            Me.btnReload = New System.Windows.Forms.Button()
            Me.btnSaveSettings = New System.Windows.Forms.Button()
            Me.pnlHeader.SuspendLayout()
            CType(Me.splitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.splitContainer.Panel1.SuspendLayout()
            Me.splitContainer.Panel2.SuspendLayout()
            Me.splitContainer.SuspendLayout()
            Me.grpPrefixes.SuspendLayout()
            CType(Me.numDefaultMargin, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpCompany.SuspendLayout()
            Me.grpMarginGuide.SuspendLayout()
            CType(Me.dgvMarginGuide, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlActions.SuspendLayout()
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
            Me.lblSubtitle.Size = New System.Drawing.Size(434, 15)
            Me.lblSubtitle.TabIndex = 1
            Me.lblSubtitle.Text = "Manage company profile, document prefixes, target margins and benchmark guides"
            '
            'lblTitle
            '
            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.lblTitle.Location = New System.Drawing.Point(0, 0)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(296, 30)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "Settings && Margin Guide"
            '
            'splitContainer
            '
            Me.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
            Me.splitContainer.Location = New System.Drawing.Point(20, 70)
            Me.splitContainer.Name = "splitContainer"
            '
            'splitContainer.Panel1
            '
            Me.splitContainer.Panel1.Controls.Add(Me.grpPrefixes)
            Me.splitContainer.Panel1.Controls.Add(Me.grpCompany)
            '
            'splitContainer.Panel2
            '
            Me.splitContainer.Panel2.Controls.Add(Me.grpMarginGuide)
            Me.splitContainer.Panel2.Controls.Add(Me.pnlActions)
            Me.splitContainer.Size = New System.Drawing.Size(1060, 575)
            Me.splitContainer.SplitterDistance = 490
            Me.splitContainer.TabIndex = 1
            '
            'grpPrefixes
            '
            Me.grpPrefixes.BackColor = System.Drawing.Color.White
            Me.grpPrefixes.Controls.Add(Me.numDefaultMargin)
            Me.grpPrefixes.Controls.Add(Me.lblDefaultMargin)
            Me.grpPrefixes.Controls.Add(Me.txtJobPrefix)
            Me.grpPrefixes.Controls.Add(Me.lblJobPrefix)
            Me.grpPrefixes.Controls.Add(Me.txtQuotePrefix)
            Me.grpPrefixes.Controls.Add(Me.lblQuotePrefix)
            Me.grpPrefixes.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpPrefixes.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.grpPrefixes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.grpPrefixes.Location = New System.Drawing.Point(0, 260)
            Me.grpPrefixes.Name = "grpPrefixes"
            Me.grpPrefixes.Padding = New System.Windows.Forms.Padding(15)
            Me.grpPrefixes.Size = New System.Drawing.Size(490, 190)
            Me.grpPrefixes.TabIndex = 1
            Me.grpPrefixes.TabStop = False
            Me.grpPrefixes.Text = "Document Prefixes & Default Target Margin"
            '
            'numDefaultMargin
            '
            Me.numDefaultMargin.DecimalPlaces = 1
            Me.numDefaultMargin.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.numDefaultMargin.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
            Me.numDefaultMargin.Location = New System.Drawing.Point(18, 140)
            Me.numDefaultMargin.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
            Me.numDefaultMargin.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
            Me.numDefaultMargin.Name = "numDefaultMargin"
            Me.numDefaultMargin.Size = New System.Drawing.Size(440, 24)
            Me.numDefaultMargin.TabIndex = 5
            Me.numDefaultMargin.Value = New Decimal(New Integer() {35, 0, 0, 0})
            '
            'lblDefaultMargin
            '
            Me.lblDefaultMargin.AutoSize = True
            Me.lblDefaultMargin.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblDefaultMargin.ForeColor = System.Drawing.Color.Black
            Me.lblDefaultMargin.Location = New System.Drawing.Point(18, 122)
            Me.lblDefaultMargin.Name = "lblDefaultMargin"
            Me.lblDefaultMargin.Size = New System.Drawing.Size(127, 15)
            Me.lblDefaultMargin.TabIndex = 4
            Me.lblDefaultMargin.Text = "Default Target Margin %:"
            '
            'txtJobPrefix
            '
            Me.txtJobPrefix.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtJobPrefix.Location = New System.Drawing.Point(18, 92)
            Me.txtJobPrefix.Name = "txtJobPrefix"
            Me.txtJobPrefix.Size = New System.Drawing.Size(440, 24)
            Me.txtJobPrefix.TabIndex = 3
            '
            'lblJobPrefix
            '
            Me.lblJobPrefix.AutoSize = True
            Me.lblJobPrefix.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblJobPrefix.ForeColor = System.Drawing.Color.Black
            Me.lblJobPrefix.Location = New System.Drawing.Point(18, 74)
            Me.lblJobPrefix.Name = "lblJobPrefix"
            Me.lblJobPrefix.Size = New System.Drawing.Size(117, 15)
            Me.lblJobPrefix.TabIndex = 2
            Me.lblJobPrefix.Text = "Job/Booking Prefix:"
            '
            'txtQuotePrefix
            '
            Me.txtQuotePrefix.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtQuotePrefix.Location = New System.Drawing.Point(18, 44)
            Me.txtQuotePrefix.Name = "txtQuotePrefix"
            Me.txtQuotePrefix.Size = New System.Drawing.Size(440, 24)
            Me.txtQuotePrefix.TabIndex = 1
            '
            'lblQuotePrefix
            '
            Me.lblQuotePrefix.AutoSize = True
            Me.lblQuotePrefix.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblQuotePrefix.ForeColor = System.Drawing.Color.Black
            Me.lblQuotePrefix.Location = New System.Drawing.Point(18, 26)
            Me.lblQuotePrefix.Name = "lblQuotePrefix"
            Me.lblQuotePrefix.Size = New System.Drawing.Size(100, 15)
            Me.lblQuotePrefix.TabIndex = 0
            Me.lblQuotePrefix.Text = "Quotation Prefix:"
            '
            'grpCompany
            '
            Me.grpCompany.BackColor = System.Drawing.Color.White
            Me.grpCompany.Controls.Add(Me.txtAddress)
            Me.grpCompany.Controls.Add(Me.lblAddress)
            Me.grpCompany.Controls.Add(Me.txtEmail)
            Me.grpCompany.Controls.Add(Me.lblEmail)
            Me.grpCompany.Controls.Add(Me.txtPhone)
            Me.grpCompany.Controls.Add(Me.lblPhone)
            Me.grpCompany.Controls.Add(Me.txtCompanyName)
            Me.grpCompany.Controls.Add(Me.lblCompanyName)
            Me.grpCompany.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpCompany.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.grpCompany.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.grpCompany.Location = New System.Drawing.Point(0, 0)
            Me.grpCompany.Name = "grpCompany"
            Me.grpCompany.Padding = New System.Windows.Forms.Padding(15)
            Me.grpCompany.Size = New System.Drawing.Size(490, 260)
            Me.grpCompany.TabIndex = 0
            Me.grpCompany.TabStop = False
            Me.grpCompany.Text = "Company Profile (Quotation Header)"
            '
            'txtAddress
            '
            Me.txtAddress.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtAddress.Location = New System.Drawing.Point(18, 196)
            Me.txtAddress.Multiline = True
            Me.txtAddress.Name = "txtAddress"
            Me.txtAddress.Size = New System.Drawing.Size(440, 48)
            Me.txtAddress.TabIndex = 7
            '
            'lblAddress
            '
            Me.lblAddress.AutoSize = True
            Me.lblAddress.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblAddress.ForeColor = System.Drawing.Color.Black
            Me.lblAddress.Location = New System.Drawing.Point(18, 178)
            Me.lblAddress.Name = "lblAddress"
            Me.lblAddress.Size = New System.Drawing.Size(89, 15)
            Me.lblAddress.TabIndex = 6
            Me.lblAddress.Text = "Physical Office:"
            '
            'txtEmail
            '
            Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtEmail.Location = New System.Drawing.Point(18, 146)
            Me.txtEmail.Name = "txtEmail"
            Me.txtEmail.Size = New System.Drawing.Size(440, 24)
            Me.txtEmail.TabIndex = 5
            '
            'lblEmail
            '
            Me.lblEmail.AutoSize = True
            Me.lblEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblEmail.ForeColor = System.Drawing.Color.Black
            Me.lblEmail.Location = New System.Drawing.Point(18, 128)
            Me.lblEmail.Name = "lblEmail"
            Me.lblEmail.Size = New System.Drawing.Size(84, 15)
            Me.lblEmail.TabIndex = 4
            Me.lblEmail.Text = "Contact Email:"
            '
            'txtPhone
            '
            Me.txtPhone.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtPhone.Location = New System.Drawing.Point(18, 96)
            Me.txtPhone.Name = "txtPhone"
            Me.txtPhone.Size = New System.Drawing.Size(440, 24)
            Me.txtPhone.TabIndex = 3
            '
            'lblPhone
            '
            Me.lblPhone.AutoSize = True
            Me.lblPhone.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblPhone.ForeColor = System.Drawing.Color.Black
            Me.lblPhone.Location = New System.Drawing.Point(18, 78)
            Me.lblPhone.Name = "lblPhone"
            Me.lblPhone.Size = New System.Drawing.Size(91, 15)
            Me.lblPhone.TabIndex = 2
            Me.lblPhone.Text = "Contact Phone:"
            '
            'txtCompanyName
            '
            Me.txtCompanyName.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtCompanyName.Location = New System.Drawing.Point(18, 46)
            Me.txtCompanyName.Name = "txtCompanyName"
            Me.txtCompanyName.Size = New System.Drawing.Size(440, 24)
            Me.txtCompanyName.TabIndex = 1
            '
            'lblCompanyName
            '
            Me.lblCompanyName.AutoSize = True
            Me.lblCompanyName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblCompanyName.ForeColor = System.Drawing.Color.Black
            Me.lblCompanyName.Location = New System.Drawing.Point(18, 28)
            Me.lblCompanyName.Name = "lblCompanyName"
            Me.lblCompanyName.Size = New System.Drawing.Size(96, 15)
            Me.lblCompanyName.TabIndex = 0
            Me.lblCompanyName.Text = "Company Name:"
            '
            'grpMarginGuide
            '
            Me.grpMarginGuide.BackColor = System.Drawing.Color.White
            Me.grpMarginGuide.Controls.Add(Me.dgvMarginGuide)
            Me.grpMarginGuide.Dock = System.Windows.Forms.DockStyle.Fill
            Me.grpMarginGuide.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.grpMarginGuide.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.grpMarginGuide.Location = New System.Drawing.Point(0, 0)
            Me.grpMarginGuide.Name = "grpMarginGuide"
            Me.grpMarginGuide.Padding = New System.Windows.Forms.Padding(15)
            Me.grpMarginGuide.Size = New System.Drawing.Size(566, 515)
            Me.grpMarginGuide.TabIndex = 0
            Me.grpMarginGuide.TabStop = False
            Me.grpMarginGuide.Text = "Editable Margin Guide Benchmark Bands"
            '
            'dgvMarginGuide
            '
            Me.dgvMarginGuide.AllowUserToAddRows = False
            Me.dgvMarginGuide.AllowUserToDeleteRows = False
            Me.dgvMarginGuide.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvMarginGuide.BackgroundColor = System.Drawing.Color.White
            Me.dgvMarginGuide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(244, Byte), Integer))
            dataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            dataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(4)
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvMarginGuide.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
            Me.dgvMarginGuide.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvMarginGuide.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colGuideType, Me.colMinMargin, Me.colMaxMargin, Me.colDisplayRange})
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            dataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(244, Byte), Integer))
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvMarginGuide.DefaultCellStyle = dataGridViewCellStyle2
            Me.dgvMarginGuide.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvMarginGuide.EnableHeadersVisualStyles = False
            Me.dgvMarginGuide.Location = New System.Drawing.Point(15, 33)
            Me.dgvMarginGuide.MultiSelect = False
            Me.dgvMarginGuide.Name = "dgvMarginGuide"
            Me.dgvMarginGuide.RowHeadersVisible = False
            Me.dgvMarginGuide.RowTemplate.Height = 28
            Me.dgvMarginGuide.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvMarginGuide.Size = New System.Drawing.Size(536, 467)
            Me.dgvMarginGuide.TabIndex = 0
            '
            'colGuideType
            '
            Me.colGuideType.FillWeight = 40.0!
            Me.colGuideType.HeaderText = "Job Category"
            Me.colGuideType.Name = "colGuideType"
            Me.colGuideType.ReadOnly = True
            '
            'colMinMargin
            '
            Me.colMinMargin.FillWeight = 20.0!
            Me.colMinMargin.HeaderText = "Min %"
            Me.colMinMargin.Name = "colMinMargin"
            '
            'colMaxMargin
            '
            Me.colMaxMargin.FillWeight = 20.0!
            Me.colMaxMargin.HeaderText = "Max %"
            Me.colMaxMargin.Name = "colMaxMargin"
            '
            'colDisplayRange
            '
            Me.colDisplayRange.FillWeight = 25.0!
            Me.colDisplayRange.HeaderText = "Display Range"
            Me.colDisplayRange.Name = "colDisplayRange"
            '
            'pnlActions
            '
            Me.pnlActions.Controls.Add(Me.btnReload)
            Me.pnlActions.Controls.Add(Me.btnSaveSettings)
            Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlActions.Location = New System.Drawing.Point(0, 515)
            Me.pnlActions.Name = "pnlActions"
            Me.pnlActions.Size = New System.Drawing.Size(566, 60)
            Me.pnlActions.TabIndex = 1
            '
            'btnReload
            '
            Me.btnReload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReload.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(232, Byte), Integer))
            Me.btnReload.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnReload.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnReload.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            Me.btnReload.Location = New System.Drawing.Point(230, 15)
            Me.btnReload.Name = "btnReload"
            Me.btnReload.Size = New System.Drawing.Size(140, 36)
            Me.btnReload.TabIndex = 1
            Me.btnReload.Text = "Discard Changes"
            Me.btnReload.UseVisualStyleBackColor = False
            '
            'btnSaveSettings
            '
            Me.btnSaveSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSaveSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.btnSaveSettings.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSaveSettings.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnSaveSettings.ForeColor = System.Drawing.Color.White
            Me.btnSaveSettings.Location = New System.Drawing.Point(380, 15)
            Me.btnSaveSettings.Name = "btnSaveSettings"
            Me.btnSaveSettings.Size = New System.Drawing.Size(170, 36)
            Me.btnSaveSettings.TabIndex = 0
            Me.btnSaveSettings.Text = "Save All Settings"
            Me.btnSaveSettings.UseVisualStyleBackColor = False
            '
            'FrmSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(249, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1100, 665)
            Me.Controls.Add(Me.splitContainer)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "FrmSettings"
            Me.Padding = New System.Windows.Forms.Padding(20)
            Me.Text = "Settings & Margin Guide"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.splitContainer.Panel1.ResumeLayout(False)
            Me.splitContainer.Panel2.ResumeLayout(False)
            CType(Me.splitContainer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.splitContainer.ResumeLayout(False)
            Me.grpPrefixes.ResumeLayout(False)
            Me.grpPrefixes.PerformLayout()
            CType(Me.numDefaultMargin, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpCompany.ResumeLayout(False)
            Me.grpCompany.PerformLayout()
            Me.grpMarginGuide.ResumeLayout(False)
            CType(Me.dgvMarginGuide, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlActions.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace
