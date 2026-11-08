Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmJobs
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
        Friend WithEvents pnlForm As System.Windows.Forms.Panel
        Friend WithEvents lblJobNo As System.Windows.Forms.Label
        Friend WithEvents txtJobNo As System.Windows.Forms.TextBox
        Friend WithEvents lblQuote As System.Windows.Forms.Label
        Friend WithEvents cboAcceptedQuotes As System.Windows.Forms.ComboBox
        Friend WithEvents lblJobDate As System.Windows.Forms.Label
        Friend WithEvents dtpJobDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents cboJobStatus As System.Windows.Forms.ComboBox
        Friend WithEvents lblStaffAssignment As System.Windows.Forms.Label
        Friend WithEvents clbStaff As System.Windows.Forms.CheckedListBox
        Friend WithEvents lblNotes As System.Windows.Forms.Label
        Friend WithEvents txtNotes As System.Windows.Forms.TextBox
        Friend WithEvents btnNew As System.Windows.Forms.Button
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents btnCancelJob As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents pnlGrid As System.Windows.Forms.Panel
        Friend WithEvents pnlGridFilter As System.Windows.Forms.Panel
        Friend WithEvents lblFilterStatus As System.Windows.Forms.Label
        Friend WithEvents cboFilterStatus As System.Windows.Forms.ComboBox
        Friend WithEvents dgvJobs As System.Windows.Forms.DataGridView
        Friend WithEvents colJobNo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colQuoteNo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colClient As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colDate As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colStaffCount As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.pnlHeader = New System.Windows.Forms.Panel()
            Me.lblSubtitle = New System.Windows.Forms.Label()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.pnlForm = New System.Windows.Forms.Panel()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnCancelJob = New System.Windows.Forms.Button()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.btnNew = New System.Windows.Forms.Button()
            Me.txtNotes = New System.Windows.Forms.TextBox()
            Me.lblNotes = New System.Windows.Forms.Label()
            Me.clbStaff = New System.Windows.Forms.CheckedListBox()
            Me.lblStaffAssignment = New System.Windows.Forms.Label()
            Me.cboJobStatus = New System.Windows.Forms.ComboBox()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.dtpJobDate = New System.Windows.Forms.DateTimePicker()
            Me.lblJobDate = New System.Windows.Forms.Label()
            Me.cboAcceptedQuotes = New System.Windows.Forms.ComboBox()
            Me.lblQuote = New System.Windows.Forms.Label()
            Me.txtJobNo = New System.Windows.Forms.TextBox()
            Me.lblJobNo = New System.Windows.Forms.Label()
            Me.pnlGrid = New System.Windows.Forms.Panel()
            Me.dgvJobs = New System.Windows.Forms.DataGridView()
            Me.colJobNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colQuoteNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colClient = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colStaffCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlGridFilter = New System.Windows.Forms.Panel()
            Me.cboFilterStatus = New System.Windows.Forms.ComboBox()
            Me.lblFilterStatus = New System.Windows.Forms.Label()
            Me.pnlHeader.SuspendLayout()
            Me.pnlForm.SuspendLayout()
            Me.pnlGrid.SuspendLayout()
            CType(Me.dgvJobs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlGridFilter.SuspendLayout()
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
            Me.lblSubtitle.Text = "Schedule execution dates, assign personnel via JobStaff bridge table & monitor progress"
            '
            'lblTitle
            '
            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.lblTitle.Location = New System.Drawing.Point(0, 0)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(262, 30)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "Jobs && Bookings System"
            '
            'pnlForm
            '
            Me.pnlForm.BackColor = System.Drawing.Color.White
            Me.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlForm.Controls.Add(Me.btnClear)
            Me.pnlForm.Controls.Add(Me.btnCancelJob)
            Me.pnlForm.Controls.Add(Me.btnUpdate)
            Me.pnlForm.Controls.Add(Me.btnSave)
            Me.pnlForm.Controls.Add(Me.btnNew)
            Me.pnlForm.Controls.Add(Me.txtNotes)
            Me.pnlForm.Controls.Add(Me.lblNotes)
            Me.pnlForm.Controls.Add(Me.clbStaff)
            Me.pnlForm.Controls.Add(Me.lblStaffAssignment)
            Me.pnlForm.Controls.Add(Me.cboJobStatus)
            Me.pnlForm.Controls.Add(Me.lblStatus)
            Me.pnlForm.Controls.Add(Me.dtpJobDate)
            Me.pnlForm.Controls.Add(Me.lblJobDate)
            Me.pnlForm.Controls.Add(Me.cboAcceptedQuotes)
            Me.pnlForm.Controls.Add(Me.lblQuote)
            Me.pnlForm.Controls.Add(Me.txtJobNo)
            Me.pnlForm.Controls.Add(Me.lblJobNo)
            Me.pnlForm.Dock = System.Windows.Forms.DockStyle.Left
            Me.pnlForm.Location = New System.Drawing.Point(20, 70)
            Me.pnlForm.Name = "pnlForm"
            Me.pnlForm.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlForm.Size = New System.Drawing.Size(430, 575)
            Me.pnlForm.TabIndex = 1
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(232, Byte), Integer))
            Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnClear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            Me.btnClear.Location = New System.Drawing.Point(336, 525)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(75, 32)
            Me.btnClear.TabIndex = 16
            Me.btnClear.Text = "Clear"
            Me.btnClear.UseVisualStyleBackColor = False
            '
            'btnCancelJob
            '
            Me.btnCancelJob.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(47, Byte), Integer))
            Me.btnCancelJob.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCancelJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancelJob.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnCancelJob.ForeColor = System.Drawing.Color.White
            Me.btnCancelJob.Location = New System.Drawing.Point(255, 525)
            Me.btnCancelJob.Name = "btnCancelJob"
            Me.btnCancelJob.Size = New System.Drawing.Size(75, 32)
            Me.btnCancelJob.TabIndex = 15
            Me.btnCancelJob.Text = "Cancel"
            Me.btnCancelJob.UseVisualStyleBackColor = False
            '
            'btnUpdate
            '
            Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(31, Byte), Integer))
            Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUpdate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            Me.btnUpdate.Location = New System.Drawing.Point(175, 525)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(75, 32)
            Me.btnUpdate.TabIndex = 14
            Me.btnUpdate.Text = "Update"
            Me.btnUpdate.UseVisualStyleBackColor = False
            '
            'btnSave
            '
            Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.Location = New System.Drawing.Point(95, 525)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(75, 32)
            Me.btnSave.TabIndex = 13
            Me.btnSave.Text = "Save"
            Me.btnSave.UseVisualStyleBackColor = False
            '
            'btnNew
            '
            Me.btnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnNew.ForeColor = System.Drawing.Color.White
            Me.btnNew.Location = New System.Drawing.Point(15, 525)
            Me.btnNew.Name = "btnNew"
            Me.btnNew.Size = New System.Drawing.Size(75, 32)
            Me.btnNew.TabIndex = 12
            Me.btnNew.Text = "New"
            Me.btnNew.UseVisualStyleBackColor = False
            '
            'txtNotes
            '
            Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtNotes.Location = New System.Drawing.Point(15, 452)
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.PlaceholderText = "Job specific operational instructions..."
            Me.txtNotes.Size = New System.Drawing.Size(395, 60)
            Me.txtNotes.TabIndex = 11
            '
            'lblNotes
            '
            Me.lblNotes.AutoSize = True
            Me.lblNotes.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblNotes.Location = New System.Drawing.Point(15, 434)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(147, 15)
            Me.lblNotes.TabIndex = 10
            Me.lblNotes.Text = "Special Job Instructions:"
            '
            'clbStaff
            '
            Me.clbStaff.CheckOnClick = True
            Me.clbStaff.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.clbStaff.FormattingEnabled = True
            Me.clbStaff.Location = New System.Drawing.Point(15, 275)
            Me.clbStaff.Name = "clbStaff"
            Me.clbStaff.Size = New System.Drawing.Size(395, 148)
            Me.clbStaff.TabIndex = 9
            '
            'lblStaffAssignment
            '
            Me.lblStaffAssignment.AutoSize = True
            Me.lblStaffAssignment.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblStaffAssignment.Location = New System.Drawing.Point(15, 255)
            Me.lblStaffAssignment.Name = "lblStaffAssignment"
            Me.lblStaffAssignment.Size = New System.Drawing.Size(217, 15)
            Me.lblStaffAssignment.TabIndex = 8
            Me.lblStaffAssignment.Text = "Assign Cleaning Staff (JobStaff Table):"
            '
            'cboJobStatus
            '
            Me.cboJobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboJobStatus.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.cboJobStatus.FormattingEnabled = True
            Me.cboJobStatus.Items.AddRange(New Object() {"Scheduled", "In Progress", "Completed", "Cancelled"})
            Me.cboJobStatus.Location = New System.Drawing.Point(15, 218)
            Me.cboJobStatus.Name = "cboJobStatus"
            Me.cboJobStatus.Size = New System.Drawing.Size(395, 24)
            Me.cboJobStatus.TabIndex = 7
            '
            'lblStatus
            '
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblStatus.Location = New System.Drawing.Point(15, 200)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(68, 15)
            Me.lblStatus.TabIndex = 6
            Me.lblStatus.Text = "Job Status:"
            '
            'dtpJobDate
            '
            Me.dtpJobDate.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.dtpJobDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpJobDate.Location = New System.Drawing.Point(15, 160)
            Me.dtpJobDate.Name = "dtpJobDate"
            Me.dtpJobDate.Size = New System.Drawing.Size(395, 24)
            Me.dtpJobDate.TabIndex = 5
            '
            'lblJobDate
            '
            Me.lblJobDate.AutoSize = True
            Me.lblJobDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblJobDate.Location = New System.Drawing.Point(15, 142)
            Me.lblJobDate.Name = "lblJobDate"
            Me.lblJobDate.Size = New System.Drawing.Size(127, 15)
            Me.lblJobDate.TabIndex = 4
            Me.lblJobDate.Text = "Scheduled Job Date:"
            '
            'cboAcceptedQuotes
            '
            Me.cboAcceptedQuotes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboAcceptedQuotes.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.cboAcceptedQuotes.FormattingEnabled = True
            Me.cboAcceptedQuotes.Location = New System.Drawing.Point(15, 98)
            Me.cboAcceptedQuotes.Name = "cboAcceptedQuotes"
            Me.cboAcceptedQuotes.Size = New System.Drawing.Size(395, 24)
            Me.cboAcceptedQuotes.TabIndex = 3
            '
            'lblQuote
            '
            Me.lblQuote.AutoSize = True
            Me.lblQuote.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblQuote.Location = New System.Drawing.Point(15, 80)
            Me.lblQuote.Name = "lblQuote"
            Me.lblQuote.Size = New System.Drawing.Size(161, 15)
            Me.lblQuote.TabIndex = 2
            Me.lblQuote.Text = "Linked Accepted Quotation:"
            '
            'txtJobNo
            '
            Me.txtJobNo.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtJobNo.Location = New System.Drawing.Point(15, 38)
            Me.txtJobNo.Name = "txtJobNo"
            Me.txtJobNo.ReadOnly = True
            Me.txtJobNo.Size = New System.Drawing.Size(395, 24)
            Me.txtJobNo.TabIndex = 1
            '
            'lblJobNo
            '
            Me.lblJobNo.AutoSize = True
            Me.lblJobNo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblJobNo.Location = New System.Drawing.Point(15, 20)
            Me.lblJobNo.Name = "lblJobNo"
            Me.lblJobNo.Size = New System.Drawing.Size(78, 15)
            Me.lblJobNo.TabIndex = 0
            Me.lblJobNo.Text = "Job Number:"
            '
            'pnlGrid
            '
            Me.pnlGrid.Controls.Add(Me.dgvJobs)
            Me.pnlGrid.Controls.Add(Me.pnlGridFilter)
            Me.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlGrid.Location = New System.Drawing.Point(450, 70)
            Me.pnlGrid.Name = "pnlGrid"
            Me.pnlGrid.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
            Me.pnlGrid.Size = New System.Drawing.Size(630, 575)
            Me.pnlGrid.TabIndex = 2
            '
            'dgvJobs
            '
            Me.dgvJobs.AllowUserToAddRows = False
            Me.dgvJobs.AllowUserToDeleteRows = False
            Me.dgvJobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvJobs.BackgroundColor = System.Drawing.Color.White
            Me.dgvJobs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(244, Byte), Integer))
            dataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            dataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(4)
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
            Me.dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvJobs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colJobNo, Me.colQuoteNo, Me.colClient, Me.colDate, Me.colStatus, Me.colStaffCount, Me.colAmount})
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            dataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(244, Byte), Integer))
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvJobs.DefaultCellStyle = dataGridViewCellStyle2
            Me.dgvJobs.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvJobs.EnableHeadersVisualStyles = False
            Me.dgvJobs.Location = New System.Drawing.Point(15, 45)
            Me.dgvJobs.MultiSelect = False
            Me.dgvJobs.Name = "dgvJobs"
            Me.dgvJobs.ReadOnly = True
            Me.dgvJobs.RowHeadersVisible = False
            Me.dgvJobs.RowTemplate.Height = 28
            Me.dgvJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvJobs.Size = New System.Drawing.Size(615, 530)
            Me.dgvJobs.TabIndex = 1
            '
            'colJobNo
            '
            Me.colJobNo.FillWeight = 20.0!
            Me.colJobNo.HeaderText = "Job No"
            Me.colJobNo.Name = "colJobNo"
            Me.colJobNo.ReadOnly = True
            '
            'colQuoteNo
            '
            Me.colQuoteNo.FillWeight = 20.0!
            Me.colQuoteNo.HeaderText = "Quote"
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
            'colDate
            '
            Me.colDate.FillWeight = 20.0!
            Me.colDate.HeaderText = "Job Date"
            Me.colDate.Name = "colDate"
            Me.colDate.ReadOnly = True
            '
            'colStatus
            '
            Me.colStatus.FillWeight = 20.0!
            Me.colStatus.HeaderText = "Status"
            Me.colStatus.Name = "colStatus"
            Me.colStatus.ReadOnly = True
            '
            'colStaffCount
            '
            Me.colStaffCount.FillWeight = 16.0!
            Me.colStaffCount.HeaderText = "Staff"
            Me.colStaffCount.Name = "colStaffCount"
            Me.colStaffCount.ReadOnly = True
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
            'pnlGridFilter
            '
            Me.pnlGridFilter.Controls.Add(Me.cboFilterStatus)
            Me.pnlGridFilter.Controls.Add(Me.lblFilterStatus)
            Me.pnlGridFilter.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlGridFilter.Location = New System.Drawing.Point(15, 0)
            Me.pnlGridFilter.Name = "pnlGridFilter"
            Me.pnlGridFilter.Size = New System.Drawing.Size(615, 45)
            Me.pnlGridFilter.TabIndex = 0
            '
            'cboFilterStatus
            '
            Me.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboFilterStatus.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.cboFilterStatus.FormattingEnabled = True
            Me.cboFilterStatus.Items.AddRange(New Object() {"All", "Scheduled", "In Progress", "Completed", "Cancelled"})
            Me.cboFilterStatus.Location = New System.Drawing.Point(90, 8)
            Me.cboFilterStatus.Name = "cboFilterStatus"
            Me.cboFilterStatus.Size = New System.Drawing.Size(180, 24)
            Me.cboFilterStatus.TabIndex = 1
            '
            'lblFilterStatus
            '
            Me.lblFilterStatus.AutoSize = True
            Me.lblFilterStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblFilterStatus.Location = New System.Drawing.Point(5, 12)
            Me.lblFilterStatus.Name = "lblFilterStatus"
            Me.lblFilterStatus.Size = New System.Drawing.Size(75, 15)
            Me.lblFilterStatus.TabIndex = 0
            Me.lblFilterStatus.Text = "Filter Status:"
            '
            'FrmJobs
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(249, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1100, 665)
            Me.Controls.Add(Me.pnlGrid)
            Me.Controls.Add(Me.pnlForm)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "FrmJobs"
            Me.Padding = New System.Windows.Forms.Padding(20)
            Me.Text = "Jobs & Bookings"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.pnlForm.ResumeLayout(False)
            Me.pnlForm.PerformLayout()
            Me.pnlGrid.ResumeLayout(False)
            CType(Me.dgvJobs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlGridFilter.ResumeLayout(False)
            Me.pnlGridFilter.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace
