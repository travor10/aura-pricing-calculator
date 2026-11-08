Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmLogin
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

        Friend WithEvents pnlCard As System.Windows.Forms.Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubtitle As System.Windows.Forms.Label
        Friend WithEvents lblUsername As System.Windows.Forms.Label
        Friend WithEvents txtUsername As System.Windows.Forms.TextBox
        Friend WithEvents lblPassword As System.Windows.Forms.Label
        Friend WithEvents txtPassword As System.Windows.Forms.TextBox
        Friend WithEvents chkShowPassword As System.Windows.Forms.CheckBox
        Friend WithEvents btnLogin As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents lblError As System.Windows.Forms.Label
        Friend WithEvents lblDemoHint As System.Windows.Forms.Label

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.pnlCard = New System.Windows.Forms.Panel()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.lblSubtitle = New System.Windows.Forms.Label()
            Me.lblUsername = New System.Windows.Forms.Label()
            Me.txtUsername = New System.Windows.Forms.TextBox()
            Me.lblPassword = New System.Windows.Forms.Label()
            Me.txtPassword = New System.Windows.Forms.TextBox()
            Me.chkShowPassword = New System.Windows.Forms.CheckBox()
            Me.btnLogin = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.lblError = New System.Windows.Forms.Label()
            Me.lblDemoHint = New System.Windows.Forms.Label()
            Me.pnlCard.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlCard
            '
            Me.pnlCard.BackColor = System.Drawing.Color.White
            Me.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlCard.Controls.Add(Me.lblDemoHint)
            Me.pnlCard.Controls.Add(Me.lblError)
            Me.pnlCard.Controls.Add(Me.btnCancel)
            Me.pnlCard.Controls.Add(Me.btnLogin)
            Me.pnlCard.Controls.Add(Me.chkShowPassword)
            Me.pnlCard.Controls.Add(Me.txtPassword)
            Me.pnlCard.Controls.Add(Me.lblPassword)
            Me.pnlCard.Controls.Add(Me.txtUsername)
            Me.pnlCard.Controls.Add(Me.lblUsername)
            Me.pnlCard.Controls.Add(Me.lblSubtitle)
            Me.pnlCard.Controls.Add(Me.lblTitle)
            Me.pnlCard.Location = New System.Drawing.Point(40, 30)
            Me.pnlCard.Name = "pnlCard"
            Me.pnlCard.Size = New System.Drawing.Size(420, 480)
            Me.pnlCard.TabIndex = 0
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.lblTitle.Location = New System.Drawing.Point(20, 25)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(380, 40)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "AURA CLEANING SOLUTIONS"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblSubtitle
            '
            Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
            Me.lblSubtitle.Location = New System.Drawing.Point(20, 65)
            Me.lblSubtitle.Name = "lblSubtitle"
            Me.lblSubtitle.Size = New System.Drawing.Size(380, 25)
            Me.lblSubtitle.TabIndex = 1
            Me.lblSubtitle.Text = "Login to continue"
            Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblUsername
            '
            Me.lblUsername.AutoSize = True
            Me.lblUsername.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            Me.lblUsername.Location = New System.Drawing.Point(40, 115)
            Me.lblUsername.Name = "lblUsername"
            Me.lblUsername.Size = New System.Drawing.Size(73, 17)
            Me.lblUsername.TabIndex = 2
            Me.lblUsername.Text = "Username:"
            '
            'txtUsername
            '
            Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtUsername.Location = New System.Drawing.Point(40, 138)
            Me.txtUsername.Name = "txtUsername"
            Me.txtUsername.Size = New System.Drawing.Size(340, 25)
            Me.txtUsername.TabIndex = 3
            '
            'lblPassword
            '
            Me.lblPassword.AutoSize = True
            Me.lblPassword.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            Me.lblPassword.Location = New System.Drawing.Point(40, 185)
            Me.lblPassword.Name = "lblPassword"
            Me.lblPassword.Size = New System.Drawing.Size(70, 17)
            Me.lblPassword.TabIndex = 4
            Me.lblPassword.Text = "Password:"
            '
            'txtPassword
            '
            Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtPassword.Location = New System.Drawing.Point(40, 208)
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.Size = New System.Drawing.Size(340, 25)
            Me.txtPassword.TabIndex = 5
            Me.txtPassword.UseSystemPasswordChar = True
            '
            'chkShowPassword
            '
            Me.chkShowPassword.AutoSize = True
            Me.chkShowPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.chkShowPassword.Location = New System.Drawing.Point(40, 245)
            Me.chkShowPassword.Name = "chkShowPassword"
            Me.chkShowPassword.Size = New System.Drawing.Size(108, 19)
            Me.chkShowPassword.TabIndex = 6
            Me.chkShowPassword.Text = "Show Password"
            Me.chkShowPassword.UseVisualStyleBackColor = True
            '
            'lblError
            '
            Me.lblError.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblError.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(47, Byte), Integer))
            Me.lblError.Location = New System.Drawing.Point(40, 275)
            Me.lblError.Name = "lblError"
            Me.lblError.Size = New System.Drawing.Size(340, 40)
            Me.lblError.TabIndex = 7
            Me.lblError.Text = ""
            Me.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnLogin
            '
            Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(136, Byte), Integer))
            Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLogin.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnLogin.ForeColor = System.Drawing.Color.White
            Me.btnLogin.Location = New System.Drawing.Point(40, 325)
            Me.btnLogin.Name = "btnLogin"
            Me.btnLogin.Size = New System.Drawing.Size(160, 42)
            Me.btnLogin.TabIndex = 8
            Me.btnLogin.Text = "Login"
            Me.btnLogin.UseVisualStyleBackColor = False
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(232, Byte), Integer))
            Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
            Me.btnCancel.Location = New System.Drawing.Point(220, 325)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(160, 42)
            Me.btnCancel.TabIndex = 9
            Me.btnCancel.Text = "Cancel"
            Me.btnCancel.UseVisualStyleBackColor = False
            '
            'lblDemoHint
            '
            Me.lblDemoHint.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
            Me.lblDemoHint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
            Me.lblDemoHint.Location = New System.Drawing.Point(40, 395)
            Me.lblDemoHint.Name = "lblDemoHint"
            Me.lblDemoHint.Size = New System.Drawing.Size(340, 45)
            Me.lblDemoHint.TabIndex = 10
            Me.lblDemoHint.Text = "Demonstration Accounts:" & vbCrLf & "Admin: admin / admin123" & vbCrLf & "Staff: staff1 / staff123"
            Me.lblDemoHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'FrmLogin
            '
            Me.AcceptButton = Me.btnLogin
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(249, Byte), Integer))
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(500, 540)
            Me.Controls.Add(Me.pnlCard)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FrmLogin"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Aura Cleaning Solutions - Login"
            Me.pnlCard.ResumeLayout(False)
            Me.pnlCard.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace
