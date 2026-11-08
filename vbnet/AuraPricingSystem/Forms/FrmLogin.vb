Imports AuraPricingSystem.Services
Imports AuraPricingSystem.Models

Namespace Forms
    ''' <summary>
    ''' MODULE 1: LOGIN FORM
    ''' Authenticates credentials using PBKDF2, retrieves account role from database,
    ''' and enforces role-based access without unrestricted role dropdown elevation.
    ''' </summary>
    Public Class FrmLogin
        Private ReadOnly _authService As New AuthService()

        Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            lblError.Text = String.Empty
            txtUsername.Select()
        End Sub

        Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
            txtPassword.UseSystemPasswordChar = Not chkShowPassword.Checked
        End Sub

        Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
            lblError.Text = String.Empty
            Dim username As String = txtUsername.Text.Trim()
            Dim password As String = txtPassword.Text

            Dim result = _authService.Login(username, password)
            If result.Success Then
                ' Authentication successful -> DialogResult.OK closes login and launches MainForm
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                lblError.Text = result.Message
                txtPassword.Clear()
                txtPassword.Focus()
            End If
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub
    End Class
End Namespace
