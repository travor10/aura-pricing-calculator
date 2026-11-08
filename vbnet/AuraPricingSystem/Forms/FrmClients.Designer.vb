Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmClients
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
        Friend WithEvents lblClientNo As System.Windows.Forms.Label
        Friend WithEvents txtClientNo As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents txtFullName As System.Windows.Forms.TextBox
        Friend WithEvents lblPhone As System.Windows.Forms.Label
        Friend WithEvents txtPhone As System.Windows.Forms.TextBox
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents txtLocation As System.Windows.Forms.TextBox
        Friend WithEvents lblType As System.Windows.Forms.Label
        Friend WithEvents cboClientType As System.Windows.Forms.ComboBox
        Friend WithEvents btnNew As System.Windows.Forms.Button
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents btnDelete As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents pnlGrid As System.Windows.Forms.Panel
        Friend WithEvents txtSearch As System.Windows.Forms.TextBox
        Friend WithEvents lblSearch As System.Windows.Forms.Label
        Friend WithEvents dgvClients As System.Windows.Forms.DataGridView
        Friend WithEvents colNo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colPhone As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colLocation As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colType As System.Windows.Forms.DataGridViewTextBoxColumn

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.pnlHeader = New System.Windows.Forms.Panel()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.pnlForm = New System.Windows.Forms.Panel()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnDelete = New System.Windows.Forms.Button()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.btnNew = New System.Windows.Forms.Button()
            Me.cboClientType = New System.Windows.Forms.ComboBox()
            Me.lblType = New System.Windows.Forms.Label()
            Me.txtLocation = New System.Windows.Forms.TextBox()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.txtPhone = New System.Windows.Forms.TextBox()
            Me.lblPhone = New System.Windows.Forms.Label()
            Me.txtFullName = New System.Windows.Forms.TextBox()
            Me.lblName = New System.Windows.Forms.Label()
            Me.txtClientNo = New System.Windows.Forms.TextBox()
            Me.lblClientNo = New System.Windows.Forms.Label()
            Me.pnlGrid = New System.Windows.Forms.Panel()
            Me.dgvClients = New System.Windows.Forms.DataGridView()
            Me.colNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colType = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.txtSearch = New System.Windows.Forms.TextBox()
            Me.lblSearch = New System.Windows.Forms.Label()
            Me.pnlHeader.SuspendLayout()
            Me.pnlForm.SuspendLayout()
            Me.pnlGrid.SuspendLayout()
            CType(Me.dgvClients, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.lblTitle.Size = New System.Drawing.Size(217, 30)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "Client Management"
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
            Me.pnlForm.Controls.Add(Me.cboClientType)
            Me.pnlForm.Controls.Add(Me.lblType)
            Me.pnlForm.Controls.Add(Me.txtLocation)
            Me.pnlForm.Controls.Add(Me.lblLocation)
            Me.pnlForm.Controls.Add(Me.txtPhone)
            Me.pnlForm.Controls.Add(Me.lblPhone)
            Me.pnlForm.Controls.Add(Me.txtFullName)
            Me.pnlForm.Controls.Add(Me.lblName)
            Me.pnlForm.Controls.Add(Me.txtClientNo)
            Me.pnlForm.Controls.Add(Me.lblClientNo)
            Me.pnlForm.Dock = System.Windows.Forms.DockStyle.Left
            Me.pnlForm.Location = New System.Drawing.Point(20, 65)
            Me.pnlForm.Name = "pnlForm"
            Me.pnlForm.Padding = New System.Windows.Forms.Padding(15)
            Me.pnlForm.Size = New System.Drawing.Size(420, 580)
            Me.pnlForm.TabIndex = 1
            '
            'lblClientNo
            '
            Me.lblClientNo.AutoSize = True
            Me.lblClientNo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblClientNo.Location = New System.Drawing.Point(15, 15)
            Me.lblClientNo.Name = "lblClientNo"
            Me.lblClientNo.Size = New System.Drawing.Size(64, 15)
            Me.lblClientNo.TabIndex = 0
            Me.lblClientNo.Text = "Client No:"
            '
            'txtClientNo
            '
            Me.txtClientNo.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtClientNo.Location = New System.Drawing.Point(15, 33)
            Me.txtClientNo.Name = "txtClientNo"
            Me.txtClientNo.ReadOnly = True
            Me.txtClientNo.Size = New System.Drawing.Size(385, 24)
            Me.txtClientNo.TabIndex = 1
            '
            'lblName
            '
            Me.lblName.AutoSize = True
            Me.lblName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblName.Location = New System.Drawing.Point(15, 70)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(77, 15)
            Me.lblName.TabIndex = 2
            Me.lblName.Text = "Client Name:"
            '
            'txtFullName
            '
            Me.txtFullName.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtFullName.Location = New System.Drawing.Point(15, 88)
            Me.txtFullName.Name = "txtFullName"
            Me.txtFullName.Size = New System.Drawing.Size(385, 24)
            Me.txtFullName.TabIndex = 3
            '
            'lblPhone
            '
            Me.lblPhone.AutoSize = True
            Me.lblPhone.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblPhone.Location = New System.Drawing.Point(15, 125)
            Me.lblPhone.Name = "lblPhone"
            Me.lblPhone.Size = New System.Drawing.Size(45, 15)
            Me.lblPhone.TabIndex = 4
            Me.lblPhone.Text = "Phone:"
            '
            'txtPhone
            '
            Me.txtPhone.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtPhone.Location = New System.Drawing.Point(15, 143)
            Me.txtPhone.Name = "txtPhone"
            Me.txtPhone.Size = New System.Drawing.Size(385, 24)
            Me.txtPhone.TabIndex = 5
            '
            'lblLocation
            '
            Me.lblLocation.AutoSize = True
            Me.lblLocation.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblLocation.Location = New System.Drawing.Point(15, 180)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(57, 15)
            Me.lblLocation.TabIndex = 6
            Me.lblLocation.Text = "Location:"
            '
            'txtLocation
            '
            Me.txtLocation.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtLocation.Location = New System.Drawing.Point(15, 198)
            Me.txtLocation.Name = "txtLocation"
            Me.txtLocation.Size = New System.Drawing.Size(385, 24)
            Me.txtLocation.TabIndex = 7
            '
            'lblType
            '
            Me.lblType.AutoSize = True
            Me.lblType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblType.Location = New System.Drawing.Point(15, 235)
            Me.lblType.Name = "lblType"
            Me.lblType.Size = New System.Drawing.Size(72, 15)
            Me.lblType.TabIndex = 8
            Me.lblType.Text = "Client Type:"
            '
            'cboClientType
            '
            Me.cboClientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboClientType.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.cboClientType.FormattingEnabled = True
            Me.cboClientType.Items.AddRange(New Object() {"Residential", "Commercial"})
            Me.cboClientType.Location = New System.Drawing.Point(15, 253)
            Me.cboClientType.Name = "cboClientType"
            Me.cboClientType.Size = New System.Drawing.Size(385, 24)
            Me.cboClientType.TabIndex = 9
            '
            'btnNew
            '
            Me.btnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnNew.ForeColor = System.Drawing.Color.White
            Me.btnNew.Location = New System.Drawing.Point(15, 305)
            Me.btnNew.Name = "btnNew"
            Me.btnNew.Size = New System.Drawing.Size(70, 32)
            Me.btnNew.TabIndex = 10
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
            Me.btnSave.Location = New System.Drawing.Point(92, 305)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(70, 32)
            Me.btnSave.TabIndex = 11
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
            Me.btnUpdate.Location = New System.Drawing.Point(170, 305)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(70, 32)
            Me.btnUpdate.TabIndex = 12
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
            Me.btnDelete.Location = New System.Drawing.Point(248, 305)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(70, 32)
            Me.btnDelete.TabIndex = 13
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
            Me.btnClear.Location = New System.Drawing.Point(326, 305)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(70, 32)
            Me.btnClear.TabIndex = 14
            Me.btnClear.Text = "Clear"
            Me.btnClear.UseVisualStyleBackColor = False
            '
            'pnlGrid
            '
            Me.pnlGrid.Controls.Add(Me.dgvClients)
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
            Me.lblSearch.Size = New System.Drawing.Size(84, 15)
            Me.lblSearch.TabIndex = 0
            Me.lblSearch.Text = "Search Client:"
            '
            'txtSearch
            '
            Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtSearch.Location = New System.Drawing.Point(105, 3)
            Me.txtSearch.Name = "txtSearch"
            Me.txtSearch.PlaceholderText = "Search by client name, number, phone or location..."
            Me.txtSearch.Size = New System.Drawing.Size(535, 24)
            Me.txtSearch.TabIndex = 1
            '
            'dgvClients
            '
            Me.dgvClients.AllowUserToAddRows = False
            Me.dgvClients.AllowUserToDeleteRows = False
            Me.dgvClients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvClients.BackgroundColor = System.Drawing.Color.White
            Me.dgvClients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(244, Byte), Integer))
            dataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            dataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(4)
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
            Me.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvClients.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNo, Me.colName, Me.colPhone, Me.colLocation, Me.colType})
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            dataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(244, Byte), Integer))
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvClients.DefaultCellStyle = dataGridViewCellStyle2
            Me.dgvClients.EnableHeadersVisualStyles = False
            Me.dgvClients.Location = New System.Drawing.Point(15, 38)
            Me.dgvClients.MultiSelect = False
            Me.dgvClients.Name = "dgvClients"
            Me.dgvClients.ReadOnly = True
            Me.dgvClients.RowHeadersVisible = False
            Me.dgvClients.RowTemplate.Height = 28
            Me.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvClients.Size = New System.Drawing.Size(625, 542)
            Me.dgvClients.TabIndex = 2
            '
            'colNo
            '
            Me.colNo.FillWeight = 20.0!
            Me.colNo.HeaderText = "Client No"
            Me.colNo.Name = "colNo"
            Me.colNo.ReadOnly = True
            '
            'colName
            '
            Me.colName.FillWeight = 35.0!
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
            'colLocation
            '
            Me.colLocation.FillWeight = 25.0!
            Me.colLocation.HeaderText = "Location"
            Me.colLocation.Name = "colLocation"
            Me.colLocation.ReadOnly = True
            '
            'colType
            '
            Me.colType.FillWeight = 20.0!
            Me.colType.HeaderText = "Type"
            Me.colType.Name = "colType"
            Me.colType.ReadOnly = True
            '
            'FrmClients
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
            Me.Name = "FrmClients"
            Me.Padding = New System.Windows.Forms.Padding(20)
            Me.Text = "Client Management"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.pnlForm.ResumeLayout(False)
            Me.pnlForm.PerformLayout()
            Me.pnlGrid.ResumeLayout(False)
            Me.pnlGrid.PerformLayout()
            CType(Me.dgvClients, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace
