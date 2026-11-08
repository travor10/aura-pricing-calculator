Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmDashboard
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
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        Friend WithEvents pnlCards As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents cardClients As System.Windows.Forms.Panel
        Friend WithEvents lblClientsTitle As System.Windows.Forms.Label
        Friend WithEvents lblClientsValue As System.Windows.Forms.Label
        Friend WithEvents cardQuotes As System.Windows.Forms.Panel
        Friend WithEvents lblQuotesTitle As System.Windows.Forms.Label
        Friend WithEvents lblQuotesValue As System.Windows.Forms.Label
        Friend WithEvents cardJobs As System.Windows.Forms.Panel
        Friend WithEvents lblJobsTitle As System.Windows.Forms.Label
        Friend WithEvents lblJobsValue As System.Windows.Forms.Label
        Friend WithEvents cardRevenue As System.Windows.Forms.Panel
        Friend WithEvents lblRevenueTitle As System.Windows.Forms.Label
        Friend WithEvents lblRevenueValue As System.Windows.Forms.Label
        Friend WithEvents lblRecentTitle As System.Windows.Forms.Label
        Friend WithEvents dgvRecentActivities As System.Windows.Forms.DataGridView
        Friend WithEvents colNumber As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colActivity As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colUser As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colDateTime As System.Windows.Forms.DataGridViewTextBoxColumn

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.pnlHeader = New System.Windows.Forms.Panel()
            Me.btnRefresh = New System.Windows.Forms.Button()
            Me.lblSubtitle = New System.Windows.Forms.Label()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.pnlCards = New System.Windows.Forms.TableLayoutPanel()
            Me.cardClients = New System.Windows.Forms.Panel()
            Me.lblClientsValue = New System.Windows.Forms.Label()
            Me.lblClientsTitle = New System.Windows.Forms.Label()
            Me.cardQuotes = New System.Windows.Forms.Panel()
            Me.lblQuotesValue = New System.Windows.Forms.Label()
            Me.lblQuotesTitle = New System.Windows.Forms.Label()
            Me.cardJobs = New System.Windows.Forms.Panel()
            Me.lblJobsValue = New System.Windows.Forms.Label()
            Me.lblJobsTitle = New System.Windows.Forms.Label()
            Me.cardRevenue = New System.Windows.Forms.Panel()
            Me.lblRevenueValue = New System.Windows.Forms.Label()
            Me.lblRevenueTitle = New System.Windows.Forms.Label()
            Me.lblRecentTitle = New System.Windows.Forms.Label()
            Me.dgvRecentActivities = New System.Windows.Forms.DataGridView()
            Me.colNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colActivity = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlHeader.SuspendLayout()
            Me.pnlCards.SuspendLayout()
            Me.cardClients.SuspendLayout()
            Me.cardQuotes.SuspendLayout()
            Me.cardJobs.SuspendLayout()
            Me.cardRevenue.SuspendLayout()
            CType(Me.dgvRecentActivities, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlHeader
            '
            Me.pnlHeader.Controls.Add(Me.btnRefresh)
            Me.pnlHeader.Controls.Add(Me.lblSubtitle)
            Me.pnlHeader.Controls.Add(Me.lblTitle)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(20, 20)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(1060, 50)
            Me.pnlHeader.TabIndex = 0
            '
            'btnRefresh
            '
            Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnRefresh.ForeColor = System.Drawing.Color.White
            Me.btnRefresh.Location = New System.Drawing.Point(960, 8)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(95, 32)
            Me.btnRefresh.TabIndex = 2
            Me.btnRefresh.Text = "Refresh"
            Me.btnRefresh.UseVisualStyleBackColor = False
            '
            'lblSubtitle
            '
            Me.lblSubtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
            Me.lblSubtitle.Location = New System.Drawing.Point(680, 12)
            Me.lblSubtitle.Name = "lblSubtitle"
            Me.lblSubtitle.Size = New System.Drawing.Size(260, 25)
            Me.lblSubtitle.TabIndex = 1
            Me.lblSubtitle.Text = "Live Database Metrics"
            Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTitle
            '
            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.lblTitle.Location = New System.Drawing.Point(0, 8)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(126, 30)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "Dashboard"
            '
            'pnlCards
            '
            Me.pnlCards.ColumnCount = 4
            Me.pnlCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.pnlCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.pnlCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.pnlCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.pnlCards.Controls.Add(Me.cardRevenue, 3, 0)
            Me.pnlCards.Controls.Add(Me.cardJobs, 2, 0)
            Me.pnlCards.Controls.Add(Me.cardQuotes, 1, 0)
            Me.pnlCards.Controls.Add(Me.cardClients, 0, 0)
            Me.pnlCards.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlCards.Location = New System.Drawing.Point(20, 70)
            Me.pnlCards.Name = "pnlCards"
            Me.pnlCards.RowCount = 1
            Me.pnlCards.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.pnlCards.Size = New System.Drawing.Size(1060, 100)
            Me.pnlCards.TabIndex = 1
            '
            'cardClients
            '
            Me.cardClients.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.cardClients.Controls.Add(Me.lblClientsValue)
            Me.cardClients.Controls.Add(Me.lblClientsTitle)
            Me.cardClients.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardClients.Location = New System.Drawing.Point(3, 3)
            Me.cardClients.Name = "cardClients"
            Me.cardClients.Padding = New System.Windows.Forms.Padding(12)
            Me.cardClients.Size = New System.Drawing.Size(259, 94)
            Me.cardClients.TabIndex = 0
            '
            'lblClientsValue
            '
            Me.lblClientsValue.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblClientsValue.Font = New System.Drawing.Font("Segoe UI", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblClientsValue.ForeColor = System.Drawing.Color.White
            Me.lblClientsValue.Location = New System.Drawing.Point(12, 32)
            Me.lblClientsValue.Name = "lblClientsValue"
            Me.lblClientsValue.Size = New System.Drawing.Size(235, 50)
            Me.lblClientsValue.TabIndex = 1
            Me.lblClientsValue.Text = "48"
            Me.lblClientsValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblClientsTitle
            '
            Me.lblClientsTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblClientsTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblClientsTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(244, Byte), Integer))
            Me.lblClientsTitle.Location = New System.Drawing.Point(12, 12)
            Me.lblClientsTitle.Name = "lblClientsTitle"
            Me.lblClientsTitle.Size = New System.Drawing.Size(235, 20)
            Me.lblClientsTitle.TabIndex = 0
            Me.lblClientsTitle.Text = "Clients"
            '
            'cardQuotes
            '
            Me.cardQuotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.cardQuotes.Controls.Add(Me.lblQuotesValue)
            Me.cardQuotes.Controls.Add(Me.lblQuotesTitle)
            Me.cardQuotes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardQuotes.Location = New System.Drawing.Point(268, 3)
            Me.cardQuotes.Name = "cardQuotes"
            Me.cardQuotes.Padding = New System.Windows.Forms.Padding(12)
            Me.cardQuotes.Size = New System.Drawing.Size(259, 94)
            Me.cardQuotes.TabIndex = 1
            '
            'lblQuotesValue
            '
            Me.lblQuotesValue.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblQuotesValue.Font = New System.Drawing.Font("Segoe UI", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblQuotesValue.ForeColor = System.Drawing.Color.White
            Me.lblQuotesValue.Location = New System.Drawing.Point(12, 32)
            Me.lblQuotesValue.Name = "lblQuotesValue"
            Me.lblQuotesValue.Size = New System.Drawing.Size(235, 50)
            Me.lblQuotesValue.TabIndex = 1
            Me.lblQuotesValue.Text = "15"
            Me.lblQuotesValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblQuotesTitle
            '
            Me.lblQuotesTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblQuotesTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblQuotesTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(225, Byte), Integer))
            Me.lblQuotesTitle.Location = New System.Drawing.Point(12, 12)
            Me.lblQuotesTitle.Name = "lblQuotesTitle"
            Me.lblQuotesTitle.Size = New System.Drawing.Size(235, 20)
            Me.lblQuotesTitle.TabIndex = 0
            Me.lblQuotesTitle.Text = "Quotes This Month"
            '
            'cardJobs
            '
            Me.cardJobs.BackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(160, Byte), Integer))
            Me.cardJobs.Controls.Add(Me.lblJobsValue)
            Me.cardJobs.Controls.Add(Me.lblJobsTitle)
            Me.cardJobs.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardJobs.Location = New System.Drawing.Point(533, 3)
            Me.cardJobs.Name = "cardJobs"
            Me.cardJobs.Padding = New System.Windows.Forms.Padding(12)
            Me.cardJobs.Size = New System.Drawing.Size(259, 94)
            Me.cardJobs.TabIndex = 2
            '
            'lblJobsValue
            '
            Me.lblJobsValue.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblJobsValue.Font = New System.Drawing.Font("Segoe UI", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblJobsValue.ForeColor = System.Drawing.Color.White
            Me.lblJobsValue.Location = New System.Drawing.Point(12, 32)
            Me.lblJobsValue.Name = "lblJobsValue"
            Me.lblJobsValue.Size = New System.Drawing.Size(235, 50)
            Me.lblJobsValue.TabIndex = 1
            Me.lblJobsValue.Text = "6"
            Me.lblJobsValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblJobsTitle
            '
            Me.lblJobsTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblJobsTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblJobsTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.lblJobsTitle.Location = New System.Drawing.Point(12, 12)
            Me.lblJobsTitle.Name = "lblJobsTitle"
            Me.lblJobsTitle.Size = New System.Drawing.Size(235, 20)
            Me.lblJobsTitle.TabIndex = 0
            Me.lblJobsTitle.Text = "Active Jobs"
            '
            'cardRevenue
            '
            Me.cardRevenue.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(31, Byte), Integer))
            Me.cardRevenue.Controls.Add(Me.lblRevenueValue)
            Me.cardRevenue.Controls.Add(Me.lblRevenueTitle)
            Me.cardRevenue.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cardRevenue.Location = New System.Drawing.Point(798, 3)
            Me.cardRevenue.Name = "cardRevenue"
            Me.cardRevenue.Padding = New System.Windows.Forms.Padding(12)
            Me.cardRevenue.Size = New System.Drawing.Size(259, 94)
            Me.cardRevenue.TabIndex = 3
            '
            'lblRevenueValue
            '
            Me.lblRevenueValue.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblRevenueValue.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblRevenueValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            Me.lblRevenueValue.Location = New System.Drawing.Point(12, 32)
            Me.lblRevenueValue.Name = "lblRevenueValue"
            Me.lblRevenueValue.Size = New System.Drawing.Size(235, 50)
            Me.lblRevenueValue.TabIndex = 1
            Me.lblRevenueValue.Text = "UGX 4.8M"
            Me.lblRevenueValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRevenueTitle
            '
            Me.lblRevenueTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblRevenueTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblRevenueTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            Me.lblRevenueTitle.Location = New System.Drawing.Point(12, 12)
            Me.lblRevenueTitle.Name = "lblRevenueTitle"
            Me.lblRevenueTitle.Size = New System.Drawing.Size(235, 20)
            Me.lblRevenueTitle.TabIndex = 0
            Me.lblRevenueTitle.Text = "Revenue (UGX)"
            '
            'lblRecentTitle
            '
            Me.lblRecentTitle.AutoSize = True
            Me.lblRecentTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblRecentTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            Me.lblRecentTitle.Location = New System.Drawing.Point(20, 195)
            Me.lblRecentTitle.Name = "lblRecentTitle"
            Me.lblRecentTitle.Size = New System.Drawing.Size(142, 21)
            Me.lblRecentTitle.TabIndex = 2
            Me.lblRecentTitle.Text = "Recent Activities"
            '
            'dgvRecentActivities
            '
            Me.dgvRecentActivities.AllowUserToAddRows = False
            Me.dgvRecentActivities.AllowUserToDeleteRows = False
            Me.dgvRecentActivities.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.dgvRecentActivities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvRecentActivities.BackgroundColor = System.Drawing.Color.White
            Me.dgvRecentActivities.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(244, Byte), Integer))
            dataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            dataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(4)
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvRecentActivities.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1
            Me.dgvRecentActivities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvRecentActivities.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNumber, Me.colActivity, Me.colUser, Me.colDateTime})
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            dataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(244, Byte), Integer))
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvRecentActivities.DefaultCellStyle = dataGridViewCellStyle2
            Me.dgvRecentActivities.EnableHeadersVisualStyles = False
            Me.dgvRecentActivities.Location = New System.Drawing.Point(20, 225)
            Me.dgvRecentActivities.MultiSelect = False
            Me.dgvRecentActivities.Name = "dgvRecentActivities"
            Me.dgvRecentActivities.ReadOnly = True
            Me.dgvRecentActivities.RowHeadersVisible = False
            Me.dgvRecentActivities.RowTemplate.Height = 30
            Me.dgvRecentActivities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvRecentActivities.Size = New System.Drawing.Size(1060, 420)
            Me.dgvRecentActivities.TabIndex = 3
            '
            'colNumber
            '
            Me.colNumber.FillWeight = 15.0!
            Me.colNumber.HeaderText = "No."
            Me.colNumber.Name = "colNumber"
            Me.colNumber.ReadOnly = True
            '
            'colActivity
            '
            Me.colActivity.FillWeight = 50.0!
            Me.colActivity.HeaderText = "Activity"
            Me.colActivity.Name = "colActivity"
            Me.colActivity.ReadOnly = True
            '
            'colUser
            '
            Me.colUser.FillWeight = 15.0!
            Me.colUser.HeaderText = "User"
            Me.colUser.Name = "colUser"
            Me.colUser.ReadOnly = True
            '
            'colDateTime
            '
            Me.colDateTime.FillWeight = 20.0!
            Me.colDateTime.HeaderText = "Date & Time"
            Me.colDateTime.Name = "colDateTime"
            Me.colDateTime.ReadOnly = True
            '
            'FrmDashboard
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(249, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1100, 665)
            Me.Controls.Add(Me.dgvRecentActivities)
            Me.Controls.Add(Me.lblRecentTitle)
            Me.Controls.Add(Me.pnlCards)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "FrmDashboard"
            Me.Padding = New System.Windows.Forms.Padding(20)
            Me.Text = "Dashboard"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.pnlCards.ResumeLayout(False)
            Me.cardClients.ResumeLayout(False)
            Me.cardQuotes.ResumeLayout(False)
            Me.cardJobs.ResumeLayout(False)
            Me.cardRevenue.ResumeLayout(False)
            CType(Me.dgvRecentActivities, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
    End Class
End Namespace
