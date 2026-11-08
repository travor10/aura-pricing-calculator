Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmMain
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

        Friend WithEvents pnlTop As System.Windows.Forms.Panel
        Friend WithEvents lblBrandTitle As System.Windows.Forms.Label
        Friend WithEvents lblBrandSubtitle As System.Windows.Forms.Label
        Friend WithEvents lblUserSession As System.Windows.Forms.Label
        Friend WithEvents pnlSidebar As System.Windows.Forms.Panel
        Friend WithEvents pnlContent As System.Windows.Forms.Panel
        Friend WithEvents btnNavDashboard As System.Windows.Forms.Button
        Friend WithEvents btnNavClients As System.Windows.Forms.Button
        Friend WithEvents btnNavServices As System.Windows.Forms.Button
        Friend WithEvents btnNavStaff As System.Windows.Forms.Button
        Friend WithEvents btnNavCalculator As System.Windows.Forms.Button
        Friend WithEvents btnNavQuotes As System.Windows.Forms.Button
        Friend WithEvents btnNavJobs As System.Windows.Forms.Button
        Friend WithEvents btnNavReports As System.Windows.Forms.Button
        Friend WithEvents btnNavUsers As System.Windows.Forms.Button
        Friend WithEvents btnNavSettings As System.Windows.Forms.Button
        Friend WithEvents btnNavLogout As System.Windows.Forms.Button

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.pnlTop = New System.Windows.Forms.Panel()
            Me.lblBrandTitle = New System.Windows.Forms.Label()
            Me.lblBrandSubtitle = New System.Windows.Forms.Label()
            Me.lblUserSession = New System.Windows.Forms.Label()
            Me.pnlSidebar = New System.Windows.Forms.Panel()
            Me.btnNavDashboard = New System.Windows.Forms.Button()
            Me.btnNavClients = New System.Windows.Forms.Button()
            Me.btnNavServices = New System.Windows.Forms.Button()
            Me.btnNavStaff = New System.Windows.Forms.Button()
            Me.btnNavCalculator = New System.Windows.Forms.Button()
            Me.btnNavQuotes = New System.Windows.Forms.Button()
            Me.btnNavJobs = New System.Windows.Forms.Button()
            Me.btnNavReports = New System.Windows.Forms.Button()
            Me.btnNavUsers = New System.Windows.Forms.Button()
            Me.btnNavSettings = New System.Windows.Forms.Button()
            Me.btnNavLogout = New System.Windows.Forms.Button()
            Me.pnlContent = New System.Windows.Forms.Panel()
            Me.pnlTop.SuspendLayout()
            Me.pnlSidebar.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.pnlTop.Controls.Add(Me.lblUserSession)
            Me.pnlTop.Controls.Add(Me.lblBrandSubtitle)
            Me.pnlTop.Controls.Add(Me.lblBrandTitle)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.Size = New System.Drawing.Size(1280, 75)
            Me.pnlTop.TabIndex = 0
            '
            'lblBrandTitle
            '
            Me.lblBrandTitle.AutoSize = True
            Me.lblBrandTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblBrandTitle.ForeColor = System.Drawing.Color.White
            Me.lblBrandTitle.Location = New System.Drawing.Point(20, 12)
            Me.lblBrandTitle.Name = "lblBrandTitle"
            Me.lblBrandTitle.Size = New System.Drawing.Size(328, 30)
            Me.lblBrandTitle.TabIndex = 0
            Me.lblBrandTitle.Text = "AURA CLEANING SOLUTIONS"
            '
            'lblBrandSubtitle
            '
            Me.lblBrandSubtitle.AutoSize = True
            Me.lblBrandSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblBrandSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(31, Byte), Integer))
            Me.lblBrandSubtitle.Location = New System.Drawing.Point(22, 42)
            Me.lblBrandSubtitle.Name = "lblBrandSubtitle"
            Me.lblBrandSubtitle.Size = New System.Drawing.Size(262, 17)
            Me.lblBrandSubtitle.TabIndex = 1
            Me.lblBrandSubtitle.Text = "Pricing && Quotation Management System"
            '
            'lblUserSession
            '
            Me.lblUserSession.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblUserSession.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblUserSession.ForeColor = System.Drawing.Color.White
            Me.lblUserSession.Location = New System.Drawing.Point(880, 25)
            Me.lblUserSession.Name = "lblUserSession"
            Me.lblUserSession.Size = New System.Drawing.Size(380, 25)
            Me.lblUserSession.TabIndex = 2
            Me.lblUserSession.Text = "Welcome, Admin (Role: Admin)"
            Me.lblUserSession.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pnlSidebar
            '
            Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(90, Byte), Integer))
            Me.pnlSidebar.Controls.Add(Me.btnNavLogout)
            Me.pnlSidebar.Controls.Add(Me.btnNavSettings)
            Me.pnlSidebar.Controls.Add(Me.btnNavUsers)
            Me.pnlSidebar.Controls.Add(Me.btnNavReports)
            Me.pnlSidebar.Controls.Add(Me.btnNavJobs)
            Me.pnlSidebar.Controls.Add(Me.btnNavQuotes)
            Me.pnlSidebar.Controls.Add(Me.btnNavCalculator)
            Me.pnlSidebar.Controls.Add(Me.btnNavStaff)
            Me.pnlSidebar.Controls.Add(Me.btnNavServices)
            Me.pnlSidebar.Controls.Add(Me.btnNavClients)
            Me.pnlSidebar.Controls.Add(Me.btnNavDashboard)
            Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
            Me.pnlSidebar.Location = New System.Drawing.Point(0, 75)
            Me.pnlSidebar.Name = "pnlSidebar"
            Me.pnlSidebar.Size = New System.Drawing.Size(180, 685)
            Me.pnlSidebar.TabIndex = 1
            '
            'btnNavDashboard
            '
            Me.btnNavDashboard.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(90, Byte), Integer))
            Me.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavDashboard.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnNavDashboard.FlatAppearance.BorderSize = 0
            Me.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavDashboard.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnNavDashboard.ForeColor = System.Drawing.Color.White
            Me.btnNavDashboard.Location = New System.Drawing.Point(0, 0)
            Me.btnNavDashboard.Name = "btnNavDashboard"
            Me.btnNavDashboard.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
            Me.btnNavDashboard.Size = New System.Drawing.Size(180, 45)
            Me.btnNavDashboard.TabIndex = 0
            Me.btnNavDashboard.Text = "Dashboard"
            Me.btnNavDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnNavDashboard.UseVisualStyleBackColor = False
            '
            'btnNavClients
            '
            Me.btnNavClients.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(90, Byte), Integer))
            Me.btnNavClients.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavClients.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnNavClients.FlatAppearance.BorderSize = 0
            Me.btnNavClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavClients.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnNavClients.ForeColor = System.Drawing.Color.White
            Me.btnNavClients.Location = New System.Drawing.Point(0, 45)
            Me.btnNavClients.Name = "btnNavClients"
            Me.btnNavClients.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
            Me.btnNavClients.Size = New System.Drawing.Size(180, 45)
            Me.btnNavClients.TabIndex = 1
            Me.btnNavClients.Text = "Clients"
            Me.btnNavClients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnNavClients.UseVisualStyleBackColor = False
            '
            'btnNavServices
            '
            Me.btnNavServices.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(90, Byte), Integer))
            Me.btnNavServices.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavServices.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnNavServices.FlatAppearance.BorderSize = 0
            Me.btnNavServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavServices.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnNavServices.ForeColor = System.Drawing.Color.White
            Me.btnNavServices.Location = New System.Drawing.Point(0, 90)
            Me.btnNavServices.Name = "btnNavServices"
            Me.btnNavServices.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
            Me.btnNavServices.Size = New System.Drawing.Size(180, 45)
            Me.btnNavServices.TabIndex = 2
            Me.btnNavServices.Text = "Services"
            Me.btnNavServices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnNavServices.UseVisualStyleBackColor = False
            '
            'btnNavStaff
            '
            Me.btnNavStaff.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(90, Byte), Integer))
            Me.btnNavStaff.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavStaff.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnNavStaff.FlatAppearance.BorderSize = 0
            Me.btnNavStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavStaff.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnNavStaff.ForeColor = System.Drawing.Color.White
            Me.btnNavStaff.Location = New System.Drawing.Point(0, 135)
            Me.btnNavStaff.Name = "btnNavStaff"
            Me.btnNavStaff.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
            Me.btnNavStaff.Size = New System.Drawing.Size(180, 45)
            Me.btnNavStaff.TabIndex = 3
            Me.btnNavStaff.Text = "Staff"
            Me.btnNavStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnNavStaff.UseVisualStyleBackColor = False
            '
            'btnNavCalculator
            '
            Me.btnNavCalculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(90, Byte), Integer))
            Me.btnNavCalculator.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavCalculator.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnNavCalculator.FlatAppearance.BorderSize = 0
            Me.btnNavCalculator.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavCalculator.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnNavCalculator.ForeColor = System.Drawing.Color.White
            Me.btnNavCalculator.Location = New System.Drawing.Point(0, 180)
            Me.btnNavCalculator.Name = "btnNavCalculator"
            Me.btnNavCalculator.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
            Me.btnNavCalculator.Size = New System.Drawing.Size(180, 45)
            Me.btnNavCalculator.TabIndex = 4
            Me.btnNavCalculator.Text = "Calculator"
            Me.btnNavCalculator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnNavCalculator.UseVisualStyleBackColor = False
            '
            'btnNavQuotes
            '
            Me.btnNavQuotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(90, Byte), Integer))
            Me.btnNavQuotes.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavQuotes.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnNavQuotes.FlatAppearance.BorderSize = 0
            Me.btnNavQuotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavQuotes.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnNavQuotes.ForeColor = System.Drawing.Color.White
            Me.btnNavQuotes.Location = New System.Drawing.Point(0, 225)
            Me.btnNavQuotes.Name = "btnNavQuotes"
            Me.btnNavQuotes.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
            Me.btnNavQuotes.Size = New System.Drawing.Size(180, 45)
            Me.btnNavQuotes.TabIndex = 5
            Me.btnNavQuotes.Text = "Quotes"
            Me.btnNavQuotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnNavQuotes.UseVisualStyleBackColor = False
            '
            'btnNavJobs
            '
            Me.btnNavJobs.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(90, Byte), Integer))
            Me.btnNavJobs.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavJobs.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnNavJobs.FlatAppearance.BorderSize = 0
            Me.btnNavJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavJobs.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnNavJobs.ForeColor = System.Drawing.Color.White
            Me.btnNavJobs.Location = New System.Drawing.Point(0, 270)
            Me.btnNavJobs.Name = "btnNavJobs"
            Me.btnNavJobs.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
            Me.btnNavJobs.Size = New System.Drawing.Size(180, 45)
            Me.btnNavJobs.TabIndex = 6
            Me.btnNavJobs.Text = "Jobs"
            Me.btnNavJobs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnNavJobs.UseVisualStyleBackColor = False
            '
            'btnNavReports
            '
            Me.btnNavReports.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(90, Byte), Integer))
            Me.btnNavReports.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavReports.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnNavReports.FlatAppearance.BorderSize = 0
            Me.btnNavReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavReports.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnNavReports.ForeColor = System.Drawing.Color.White
            Me.btnNavReports.Location = New System.Drawing.Point(0, 315)
            Me.btnNavReports.Name = "btnNavReports"
            Me.btnNavReports.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
            Me.btnNavReports.Size = New System.Drawing.Size(180, 45)
            Me.btnNavReports.TabIndex = 7
            Me.btnNavReports.Text = "Reports"
            Me.btnNavReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnNavReports.UseVisualStyleBackColor = False
            '
            'btnNavUsers
            '
            Me.btnNavUsers.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(90, Byte), Integer))
            Me.btnNavUsers.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavUsers.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnNavUsers.FlatAppearance.BorderSize = 0
            Me.btnNavUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavUsers.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnNavUsers.ForeColor = System.Drawing.Color.White
            Me.btnNavUsers.Location = New System.Drawing.Point(0, 360)
            Me.btnNavUsers.Name = "btnNavUsers"
            Me.btnNavUsers.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
            Me.btnNavUsers.Size = New System.Drawing.Size(180, 45)
            Me.btnNavUsers.TabIndex = 8
            Me.btnNavUsers.Text = "Users"
            Me.btnNavUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnNavUsers.UseVisualStyleBackColor = False
            '
            'btnNavSettings
            '
            Me.btnNavSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(90, Byte), Integer))
            Me.btnNavSettings.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavSettings.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnNavSettings.FlatAppearance.BorderSize = 0
            Me.btnNavSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavSettings.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnNavSettings.ForeColor = System.Drawing.Color.White
            Me.btnNavSettings.Location = New System.Drawing.Point(0, 405)
            Me.btnNavSettings.Name = "btnNavSettings"
            Me.btnNavSettings.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
            Me.btnNavSettings.Size = New System.Drawing.Size(180, 45)
            Me.btnNavSettings.TabIndex = 9
            Me.btnNavSettings.Text = "Settings"
            Me.btnNavSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnNavSettings.UseVisualStyleBackColor = False
            '
            'btnNavLogout
            '
            Me.btnNavLogout.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(90, Byte), Integer))
            Me.btnNavLogout.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNavLogout.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.btnNavLogout.FlatAppearance.BorderSize = 0
            Me.btnNavLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNavLogout.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnNavLogout.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(128, Byte), Integer))
            Me.btnNavLogout.Location = New System.Drawing.Point(0, 635)
            Me.btnNavLogout.Name = "btnNavLogout"
            Me.btnNavLogout.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
            Me.btnNavLogout.Size = New System.Drawing.Size(180, 50)
            Me.btnNavLogout.TabIndex = 10
            Me.btnNavLogout.Text = "Logout"
            Me.btnNavLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnNavLogout.UseVisualStyleBackColor = False
            '
            'pnlContent
            '
            Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(249, Byte), Integer))
            Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlContent.Location = New System.Drawing.Point(180, 75)
            Me.pnlContent.Name = "pnlContent"
            Me.pnlContent.Size = New System.Drawing.Size(1100, 685)
            Me.pnlContent.TabIndex = 2
            '
            'FrmMain
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1280, 760)
            Me.Controls.Add(Me.pnlContent)
            Me.Controls.Add(Me.pnlSidebar)
            Me.Controls.Add(Me.pnlTop)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.MinimumSize = New System.Drawing.Size(1024, 700)
            Me.Name = "FrmMain"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Aura Cleaning Solutions – Pricing and Quotation Management System"
            Me.pnlTop.ResumeLayout(False)
            Me.pnlTop.PerformLayout()
            Me.pnlSidebar.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace
