Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmStaff
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
        Friend WithEvents pnlForm As System.Windows.Forms.Panel
        Friend WithEvents lblStaffNo As System.Windows.Forms.Label
        Friend WithEvents txtStaffNo As System.Windows.Forms.TextBox
        Friend WithEvents lblFullName As System.Windows.Forms.Label
        Friend WithEvents txtFullName As System.Windows.Forms.TextBox
        Friend WithEvents lblPhone As System.Windows.Forms.Label
        Friend WithEvents txtPhone As System.Windows.Forms.TextBox
        Friend WithEvents lblRole As System.Windows.Forms.Label
        Friend WithEvents cboRole As System.Windows.Forms.ComboBox
        Friend WithEvents lblDailyRate As System.Windows.Forms.Label
        Friend WithEvents numDailyRate As System.Windows.Forms.NumericUpDown
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
        Friend WithEvents btnNew As System.Windows.Forms.Button
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents btnDelete As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents pnlGrid As System.Windows.Forms.Panel
        Friend WithEvents lblSearch As System.Windows.Forms.Label
        Friend WithEvents txtSearch As System.Windows.Forms.TextBox
        Friend WithEvents dgvStaff As System.Windows.Forms.DataGridView
        Friend WithEvents colNo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colPhone As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colRole As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colRate As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.pnlHeader = New System.Windows.Forms.Panel()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.pnlForm = New System.Windows.Forms.Panel()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnDelete = New System.Windows.Forms.Button()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.btnNew = New System.Windows.Forms.Button()
            Me.cboStatus = New System.Windows.Forms.ComboBox()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.numDailyRate = New System.Windows.Forms.NumericUpDown()
            Me.lblDailyRate = New System.Windows.Forms.Label()
            Me.cboRole = New System.Windows.Forms.ComboBox()
            Me.lblRole = New System.Windows.Forms.Label()
            Me.txtPhone = New System.Windows.Forms.TextBox()
            Me.lblPhone = New System.Windows.Forms.Label()
            Me.txtFullName = New System.Windows.Forms.TextBox()
            Me.lblFullName = New System.Windows.Forms.Label()
            Me.txtStaffNo = New System.Windows.Forms.TextBox()
            Me.lblStaffNo = New System.Windows.Forms.Label()
            Me.pnlGrid = New System.Windows.Forms.Panel()
            Me.dgvStaff = New System.Windows.Forms.DataGridView()
            Me.colNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colRole = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.txtSearch = New System.Windows.Forms.TextBox()
            Me.lblSearch = New System.Windows.Forms.Label()
            Me.pnlHeader.SuspendLayout()
            Me.pnlForm.SuspendLayout()
            CType(Me.numDailyRate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlGrid.SuspendLayout()
            CType(Me.dgvStaff, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlHeader
            '
            Me.pnlHeader.Controls.Add(Me.lblTitle)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(20, 20)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(1060, 45)
            Me.pnlHeader.TabIndex = 0
            '
            'lblTitle
            '
            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.lblTitle.Location = New System.Drawing.Point(0, 5)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(206, 30)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "Staff Management"
            '
            'pnlForm
            '
            Me.pnlForm.BackColor = System.Drawing.Color.White
            Me.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlForm.Controls.Add(Me.btnClear)
            Me.pnlForm.Controls.Add(Me.btnDelete)
            Me.pnlForm.Controls.Add(Me.btnUpdate)
            Me.pnlForm.Controls.Add(Me.btnSave)
            Me.pnlForm.Controls.Add(Me.btnNew)
            Me.pnlForm.Controls.Add(Me.cboStatus)
            Me.pnlForm.Controls.Add(Me.lblStatus)
            Me.pnlForm.Controls.Add(Me.numDailyRate)
            Me.pnlForm.Controls.Add(Me.lblDailyRate)
            Me.pnlForm.Controls.Add(Me.cboRole)
            Me.pnlForm.Controls.Add(Me.lblRole)
            Me.pnlForm.Controls.Add(Me.txtPhone)
            Me.pnlForm.Controls.Add(Me.lblPhone)
            Me.pnlForm.Controls.Add(Me.txtFullName)
            Me.pnlForm.Controls.Add(Me.lblFullName)
            Me.pnlForm.Controls.Add(Me.txtStaffNo)
            Me.pnlForm.Controls.Add(Me.lblStaffNo)
            Me.pnlForm.Dock = System.Windows.Forms.DockStyle.Left
            Me.pnlForm.Location = New System.Drawing.Point(20, 65)
            Me.pnlForm.Name = "pnlForm"
            Me.pnlForm.Padding = New System.Windows.Forms.Padding(15)
            Me.pnlForm.Size = New System.Drawing.Size(420, 580)
            Me.pnlForm.TabIndex = 1
            '
            'lblStaffNo
            '
            Me.lblStaffNo.AutoSize = True
            Me.lblStaffNo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblStaffNo.Location = New System.Drawing.Point(15, 10)
            Me.lblStaffNo.Name = "lblStaffNo"
            Me.lblStaffNo.Size = New System.Drawing.Size(57, 15)
            Me.lblStaffNo.TabIndex = 0
            Me.lblStaffNo.Text = "Staff No:"
            '
            'txtStaffNo
            '
            Me.txtStaffNo.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtStaffNo.Location = New System.Drawing.Point(15, 28)
            Me.txtStaffNo.Name = "txtStaffNo"
            Me.txtStaffNo.ReadOnly = True
            Me.txtStaffNo.Size = New System.Drawing.Size(385, 24)
            Me.txtStaffNo.TabIndex = 1
            '
            'lblFullName
            '
            Me.lblFullName.AutoSize = True
            Me.lblFullName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblFullName.Location = New System.Drawing.Point(15, 62)
            Me.lblFullName.Name = "lblFullName"
            Me.lblFullName.Size = New System.Drawing.Size(65, 15)
            Me.lblFullName.TabIndex = 2
            Me.lblFullName.Text = "Full Name:"
            '
            'txtFullName
            '
            Me.txtFullName.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtFullName.Location = New System.Drawing.Point(15, 80)
            Me.txtFullName.Name = "txtFullName"
            Me.txtFullName.Size = New System.Drawing.Size(385, 24)
            Me.txtFullName.TabIndex = 3
            '
            'lblPhone
            '
            Me.lblPhone.AutoSize = True
            Me.lblPhone.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblPhone.Location = New System.Drawing.Point(15, 114)
            Me.lblPhone.Name = "lblPhone"
            Me.lblPhone.Size = New System.Drawing.Size(45, 15)
            Me.lblPhone.TabIndex = 4
            Me.lblPhone.Text = "Phone:"
            '
            'txtPhone
            '
            Me.txtPhone.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtPhone.Location = New System.Drawing.Point(15, 132)
            Me.txtPhone.Name = "txtPhone"
            Me.txtPhone.Size = New System.Drawing.Size(385, 24)
            Me.txtPhone.TabIndex = 5
            '
            'lblRole
            '
            Me.lblRole.AutoSize = True
            Me.lblRole.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblRole.Location = New System.Drawing.Point(15, 166)
            Me.lblRole.Name = "lblRole"
            Me.lblRole.Size = New System.Drawing.Size(65, 15)
            Me.lblRole.TabIndex = 6
            Me.lblRole.Text = "Staff Role:"
            '
            'cboRole
            '
            Me.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboRole.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.cboRole.FormattingEnabled = True
            Me.cboRole.Items.AddRange(New Object() {"Cleaner", "Team Leader", "Specialist", "Supervisor"})
            Me.cboRole.Location = New System.Drawing.Point(15, 184)
            Me.cboRole.Name = "cboRole"
            Me.cboRole.Size = New System.Drawing.Size(385, 24)
            Me.cboRole.TabIndex = 7
            '
            'lblDailyRate
            '
            Me.lblDailyRate.AutoSize = True
            Me.lblDailyRate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblDailyRate.Location = New System.Drawing.Point(15, 218)
            Me.lblDailyRate.Name = "lblDailyRate"
            Me.lblDailyRate.Size = New System.Drawing.Size(99, 15)
            Me.lblDailyRate.TabIndex = 8
            Me.lblDailyRate.Text = "Daily Rate (UGX):"
            '
            'numDailyRate
            '
            Me.numDailyRate.DecimalPlaces = 0
            Me.numDailyRate.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.numDailyRate.Increment = New Decimal(New Integer() {5000, 0, 0, 0})
            Me.numDailyRate.Location = New System.Drawing.Point(15, 236)
            Me.numDailyRate.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
            Me.numDailyRate.Name = "numDailyRate"
            Me.numDailyRate.Size = New System.Drawing.Size(385, 24)
            Me.numDailyRate.TabIndex = 9
            Me.numDailyRate.ThousandsSeparator = True
            '
            'lblStatus
            '
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblStatus.Location = New System.Drawing.Point(15, 270)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(45, 15)
            Me.lblStatus.TabIndex = 10
            Me.lblStatus.Text = "Status:"
            '
            'cboStatus
            '
            Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboStatus.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.cboStatus.FormattingEnabled = True
            Me.cboStatus.Items.AddRange(New Object() {"Active", "Inactive"})
            Me.cboStatus.Location = New System.Drawing.Point(15, 288)
            Me.cboStatus.Name = "cboStatus"
            Me.cboStatus.Size = New System.Drawing.Size(385, 24)
            Me.cboStatus.TabIndex = 11
            '
            'btnNew
            '
            Me.btnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnNew.ForeColor = System.Drawing.Color.White
            Me.btnNew.Location = New System.Drawing.Point(15, 335)
            Me.btnNew.Name = "btnNew"
            Me.btnNew.Size = New System.Drawing.Size(70, 32)
            Me.btnNew.TabIndex = 12
            Me.btnNew.Text = "New"
            Me.btnNew.UseVisualStyleBackColor = False
            '
            'btnSave
            '
            Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.Location = New System.Drawing.Point(92, 335)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(70, 32)
            Me.btnSave.TabIndex = 13
            Me.btnSave.Text = "Save"
            Me.btnSave.UseVisualStyleBackColor = False
            '
            'btnUpdate
            '
            Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(31, Byte), Integer))
            Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUpdate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            Me.btnUpdate.Location = New System.Drawing.Point(170, 335)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(70, 32)
            Me.btnUpdate.TabIndex = 14
            Me.btnUpdate.Text = "Update"
            Me.btnUpdate.UseVisualStyleBackColor = False
            '
            'btnDelete
            '
            Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(47, Byte), Integer))
            Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnDelete.ForeColor = System.Drawing.Color.White
            Me.btnDelete.Location = New System.Drawing.Point(248, 335)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(70, 32)
            Me.btnDelete.TabIndex = 15
            Me.btnDelete.Text = "Delete"
            Me.btnDelete.UseVisualStyleBackColor = False
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(232, Byte), Integer))
            Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnClear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            Me.btnClear.Location = New System.Drawing.Point(326, 335)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(70, 32)
            Me.btnClear.TabIndex = 16
            Me.btnClear.Text = "Clear"
            Me.btnClear.UseVisualStyleBackColor = False
            '
            'pnlGrid
            '
            Me.pnlGrid.Controls.Add(Me.dgvStaff)
            Me.pnlGrid.Controls.Add(Me.txtSearch)
            Me.pnlGrid.Controls.Add(Me.lblSearch)
            Me.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlGrid.Location = New System.Drawing.Point(440, 65)
            Me.pnlGrid.Name = "pnlGrid"
            Me.pnlGrid.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
            Me.pnlGrid.Size = New System.Drawing.Size(640, 580)
            Me.pnlGrid.TabIndex = 2
            '
            'lblSearch
            '
            Me.lblSearch.AutoSize = True
            Me.lblSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblSearch.Location = New System.Drawing.Point(15, 7)
            Me.lblSearch.Name = "lblSearch"
            Me.lblSearch.Size = New System.Drawing.Size(76, 15)
            Me.lblSearch.TabIndex = 0
            Me.lblSearch.Text = "Search Staff:"
            '
            'txtSearch
            '
            Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtSearch.Location = New System.Drawing.Point(97, 3)
            Me.txtSearch.Name = "txtSearch"
            Me.txtSearch.PlaceholderText = "Search by staff name, number, or phone..."
            Me.txtSearch.Size = New System.Drawing.Size(543, 24)
            Me.txtSearch.TabIndex = 1
            '
            'dgvStaff
            '
            Me.dgvStaff.AllowUserToAddRows = False
            Me.dgvStaff.AllowUserToDeleteRows = False
            Me.dgvStaff.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvStaff.BackgroundColor = System.Drawing.Color.White
            Me.dgvStaff.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(244, Byte), Integer))
            dataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            dataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(4)
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvStaff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
            Me.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvStaff.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNo, Me.colName, Me.colPhone, Me.colRole, Me.colRate, Me.colStatus})
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            dataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(244, Byte), Integer))
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvStaff.DefaultCellStyle = dataGridViewCellStyle2
            Me.dgvStaff.EnableHeadersVisualStyles = False
            Me.dgvStaff.Location = New System.Drawing.Point(15, 38)
            Me.dgvStaff.MultiSelect = False
            Me.dgvStaff.Name = "dgvStaff"
            Me.dgvStaff.ReadOnly = True
            Me.dgvStaff.RowHeadersVisible = False
            Me.dgvStaff.RowTemplate.Height = 28
            Me.dgvStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvStaff.Size = New System.Drawing.Size(625, 542)
            Me.dgvStaff.TabIndex = 2
            '
            'colNo
            '
            Me.colNo.FillWeight = 18.0!
            Me.colNo.HeaderText = "Staff No"
            Me.colNo.Name = "colNo"
            Me.colNo.ReadOnly = True
            '
            'colName
            '
            Me.colName.FillWeight = 32.0!
            Me.colName.HeaderText = "Name"
            Me.colName.Name = "colName"
            Me.colName.ReadOnly = True
            '
            'colPhone
            '
            Me.colPhone.FillWeight = 20.0!
            Me.colPhone.HeaderText = "Phone"
            Me.colPhone.Name = "colPhone"
            Me.colPhone.ReadOnly = True
            '
            'colRole
            '
            Me.colRole.FillWeight = 20.0!
            Me.colRole.HeaderText = "Role"
            Me.colRole.Name = "colRole"
            Me.colRole.ReadOnly = True
            '
            'colRate
            '
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.colRate.DefaultCellStyle = dataGridViewCellStyle3
            Me.colRate.FillWeight = 20.0!
            Me.colRate.HeaderText = "Daily Rate"
            Me.colRate.Name = "colRate"
            Me.colRate.ReadOnly = True
            '
            'colStatus
            '
            Me.colStatus.FillWeight = 15.0!
            Me.colStatus.HeaderText = "Status"
            Me.colStatus.Name = "colStatus"
            Me.colStatus.ReadOnly = True
            '
            'FrmStaff
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
            Me.Name = "FrmStaff"
            Me.Padding = New System.Windows.Forms.Padding(20)
            Me.Text = "Staff Management"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.pnlForm.ResumeLayout(False)
            Me.pnlForm.PerformLayout()
            CType(Me.numDailyRate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlGrid.ResumeLayout(False)
            Me.pnlGrid.PerformLayout()
            CType(Me.dgvStaff, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace
