Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmServices
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
        Friend WithEvents lblServiceCode As System.Windows.Forms.Label
        Friend WithEvents txtServiceCode As System.Windows.Forms.TextBox
        Friend WithEvents lblServiceName As System.Windows.Forms.Label
        Friend WithEvents txtServiceName As System.Windows.Forms.TextBox
        Friend WithEvents lblLaborRate As System.Windows.Forms.Label
        Friend WithEvents numLaborRate As System.Windows.Forms.NumericUpDown
        Friend WithEvents lblUnit As System.Windows.Forms.Label
        Friend WithEvents cboUnit As System.Windows.Forms.ComboBox
        Friend WithEvents btnNew As System.Windows.Forms.Button
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents btnDelete As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents pnlGrid As System.Windows.Forms.Panel
        Friend WithEvents dgvServices As System.Windows.Forms.DataGridView
        Friend WithEvents colCode As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colRate As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colUnit As System.Windows.Forms.DataGridViewTextBoxColumn

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
            Me.cboUnit = New System.Windows.Forms.ComboBox()
            Me.lblUnit = New System.Windows.Forms.Label()
            Me.numLaborRate = New System.Windows.Forms.NumericUpDown()
            Me.lblLaborRate = New System.Windows.Forms.Label()
            Me.txtServiceName = New System.Windows.Forms.TextBox()
            Me.lblServiceName = New System.Windows.Forms.Label()
            Me.txtServiceCode = New System.Windows.Forms.TextBox()
            Me.lblServiceCode = New System.Windows.Forms.Label()
            Me.pnlGrid = New System.Windows.Forms.Panel()
            Me.dgvServices = New System.Windows.Forms.DataGridView()
            Me.colCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlHeader.SuspendLayout()
            Me.pnlForm.SuspendLayout()
            CType(Me.numLaborRate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlGrid.SuspendLayout()
            CType(Me.dgvServices, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.lblTitle.Size = New System.Drawing.Size(262, 30)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "Services && Rates Catalog"
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
            Me.pnlForm.Controls.Add(Me.cboUnit)
            Me.pnlForm.Controls.Add(Me.lblUnit)
            Me.pnlForm.Controls.Add(Me.numLaborRate)
            Me.pnlForm.Controls.Add(Me.lblLaborRate)
            Me.pnlForm.Controls.Add(Me.txtServiceName)
            Me.pnlForm.Controls.Add(Me.lblServiceName)
            Me.pnlForm.Controls.Add(Me.txtServiceCode)
            Me.pnlForm.Controls.Add(Me.lblServiceCode)
            Me.pnlForm.Dock = System.Windows.Forms.DockStyle.Left
            Me.pnlForm.Location = New System.Drawing.Point(20, 65)
            Me.pnlForm.Name = "pnlForm"
            Me.pnlForm.Padding = New System.Windows.Forms.Padding(15)
            Me.pnlForm.Size = New System.Drawing.Size(420, 580)
            Me.pnlForm.TabIndex = 1
            '
            'lblServiceCode
            '
            Me.lblServiceCode.AutoSize = True
            Me.lblServiceCode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblServiceCode.Location = New System.Drawing.Point(15, 15)
            Me.lblServiceCode.Name = "lblServiceCode"
            Me.lblServiceCode.Size = New System.Drawing.Size(83, 15)
            Me.lblServiceCode.TabIndex = 0
            Me.lblServiceCode.Text = "Service Code:"
            '
            'txtServiceCode
            '
            Me.txtServiceCode.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtServiceCode.Location = New System.Drawing.Point(15, 33)
            Me.txtServiceCode.Name = "txtServiceCode"
            Me.txtServiceCode.PlaceholderText = "e.g., SVC001 or PC01"
            Me.txtServiceCode.Size = New System.Drawing.Size(385, 24)
            Me.txtServiceCode.TabIndex = 1
            '
            'lblServiceName
            '
            Me.lblServiceName.AutoSize = True
            Me.lblServiceName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblServiceName.Location = New System.Drawing.Point(15, 75)
            Me.lblServiceName.Name = "lblServiceName"
            Me.lblServiceName.Size = New System.Drawing.Size(87, 15)
            Me.lblServiceName.TabIndex = 2
            Me.lblServiceName.Text = "Service Name:"
            '
            'txtServiceName
            '
            Me.txtServiceName.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtServiceName.Location = New System.Drawing.Point(15, 93)
            Me.txtServiceName.Name = "txtServiceName"
            Me.txtServiceName.PlaceholderText = "e.g., Post-Construction Cleaning"
            Me.txtServiceName.Size = New System.Drawing.Size(385, 24)
            Me.txtServiceName.TabIndex = 3
            '
            'lblLaborRate
            '
            Me.lblLaborRate.AutoSize = True
            Me.lblLaborRate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblLaborRate.Location = New System.Drawing.Point(15, 135)
            Me.lblLaborRate.Name = "lblLaborRate"
            Me.lblLaborRate.Size = New System.Drawing.Size(130, 15)
            Me.lblLaborRate.TabIndex = 4
            Me.lblLaborRate.Text = "Standard Rate (UGX):"
            '
            'numLaborRate
            '
            Me.numLaborRate.DecimalPlaces = 0
            Me.numLaborRate.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.numLaborRate.Increment = New Decimal(New Integer() {5000, 0, 0, 0})
            Me.numLaborRate.Location = New System.Drawing.Point(15, 153)
            Me.numLaborRate.Maximum = New Decimal(New Integer() {50000000, 0, 0, 0})
            Me.numLaborRate.Name = "numLaborRate"
            Me.numLaborRate.Size = New System.Drawing.Size(385, 24)
            Me.numLaborRate.TabIndex = 5
            Me.numLaborRate.ThousandsSeparator = True
            '
            'lblUnit
            '
            Me.lblUnit.AutoSize = True
            Me.lblUnit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblUnit.Location = New System.Drawing.Point(15, 195)
            Me.lblUnit.Name = "lblUnit"
            Me.lblUnit.Size = New System.Drawing.Size(89, 15)
            Me.lblUnit.TabIndex = 6
            Me.lblUnit.Text = "Billing Unit:"
            '
            'cboUnit
            '
            Me.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboUnit.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.cboUnit.FormattingEnabled = True
            Me.cboUnit.Items.AddRange(New Object() {"Per Day", "Per Sqm", "Per Unit", "Per Job", "Per Room"})
            Me.cboUnit.Location = New System.Drawing.Point(15, 213)
            Me.cboUnit.Name = "cboUnit"
            Me.cboUnit.Size = New System.Drawing.Size(385, 24)
            Me.cboUnit.TabIndex = 7
            '
            'btnNew
            '
            Me.btnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnNew.ForeColor = System.Drawing.Color.White
            Me.btnNew.Location = New System.Drawing.Point(15, 265)
            Me.btnNew.Name = "btnNew"
            Me.btnNew.Size = New System.Drawing.Size(70, 32)
            Me.btnNew.TabIndex = 8
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
            Me.btnSave.Location = New System.Drawing.Point(92, 265)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(70, 32)
            Me.btnSave.TabIndex = 9
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
            Me.btnUpdate.Location = New System.Drawing.Point(170, 265)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(70, 32)
            Me.btnUpdate.TabIndex = 10
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
            Me.btnDelete.Location = New System.Drawing.Point(248, 265)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(70, 32)
            Me.btnDelete.TabIndex = 11
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
            Me.btnClear.Location = New System.Drawing.Point(326, 265)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(70, 32)
            Me.btnClear.TabIndex = 12
            Me.btnClear.Text = "Clear"
            Me.btnClear.UseVisualStyleBackColor = False
            '
            'pnlGrid
            '
            Me.pnlGrid.Controls.Add(Me.dgvServices)
            Me.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlGrid.Location = New System.Drawing.Point(440, 65)
            Me.pnlGrid.Name = "pnlGrid"
            Me.pnlGrid.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
            Me.pnlGrid.Size = New System.Drawing.Size(640, 580)
            Me.pnlGrid.TabIndex = 2
            '
            'dgvServices
            '
            Me.dgvServices.AllowUserToAddRows = False
            Me.dgvServices.AllowUserToDeleteRows = False
            Me.dgvServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvServices.BackgroundColor = System.Drawing.Color.White
            Me.dgvServices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(244, Byte), Integer))
            dataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            dataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(4)
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
            Me.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvServices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCode, Me.colName, Me.colRate, Me.colUnit})
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            dataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(244, Byte), Integer))
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvServices.DefaultCellStyle = dataGridViewCellStyle2
            Me.dgvServices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvServices.EnableHeadersVisualStyles = False
            Me.dgvServices.Location = New System.Drawing.Point(15, 0)
            Me.dgvServices.MultiSelect = False
            Me.dgvServices.Name = "dgvServices"
            Me.dgvServices.ReadOnly = True
            Me.dgvServices.RowHeadersVisible = False
            Me.dgvServices.RowTemplate.Height = 28
            Me.dgvServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvServices.Size = New System.Drawing.Size(625, 580)
            Me.dgvServices.TabIndex = 0
            '
            'colCode
            '
            Me.colCode.FillWeight = 20.0!
            Me.colCode.HeaderText = "Service Code"
            Me.colCode.Name = "colCode"
            Me.colCode.ReadOnly = True
            '
            'colName
            '
            Me.colName.FillWeight = 45.0!
            Me.colName.HeaderText = "Service Name"
            Me.colName.Name = "colName"
            Me.colName.ReadOnly = True
            '
            'colRate
            '
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.colRate.DefaultCellStyle = dataGridViewCellStyle3
            Me.colRate.FillWeight = 20.0!
            Me.colRate.HeaderText = "Labor Rate"
            Me.colRate.Name = "colRate"
            Me.colRate.ReadOnly = True
            '
            'colUnit
            '
            Me.colUnit.FillWeight = 15.0!
            Me.colUnit.HeaderText = "Unit"
            Me.colUnit.Name = "colUnit"
            Me.colUnit.ReadOnly = True
            '
            'FrmServices
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
            Me.Name = "FrmServices"
            Me.Padding = New System.Windows.Forms.Padding(20)
            Me.Text = "Services & Rates Catalog"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.pnlForm.ResumeLayout(False)
            Me.pnlForm.PerformLayout()
            CType(Me.numLaborRate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlGrid.ResumeLayout(False)
            CType(Me.dgvServices, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace
