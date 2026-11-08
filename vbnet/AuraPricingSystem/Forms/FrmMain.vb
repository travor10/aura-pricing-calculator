Imports AuraPricingSystem.Services
Imports AuraPricingSystem.Models

Namespace Forms
    ''' <summary>
    ''' MASTER APPLICATION CONTAINER (MAINFORM)
    ''' Implements the dark-blue navigation sidebar, top branding bar, and hosts all 12 modules.
    ''' Enforces role-based permissions by toggling access to administrative screens.
    ''' </summary>
    Public Class FrmMain
        Private _currentActiveButton As Button
        Private _activeChildForm As Form

        Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' 1. Display current user session
            If AuthService.IsAuthenticated Then
                lblUserSession.Text = $"Welcome, {AuthService.CurrentUser.Username} (Role: {AuthService.CurrentUser.Role})"
            Else
                lblUserSession.Text = "Not Logged In"
            End If

            ' 2. Enforce Role-Based UI Permissions
            ApplyRolePermissions()

            ' 3. Navigate to Dashboard by default
            NavigateTo(btnNavDashboard, New FrmDashboard())
        End Sub

        Private Sub ApplyRolePermissions()
            If Not AuthService.IsAuthenticated Then Return

            Dim role As String = AuthService.CurrentUser.Role.ToUpperInvariant()
            Select Case role
                Case "STAFF"
                    btnNavUsers.Visible = False
                    btnNavSettings.Visible = False
                    btnNavReports.Visible = False ' Staff cannot access reports

                Case "MANAGER"
                    btnNavUsers.Visible = False ' Manager cannot access user management
                    btnNavSettings.Visible = True
                    btnNavReports.Visible = True

                Case "ADMIN"
                    btnNavUsers.Visible = True
                    btnNavSettings.Visible = True
                    btnNavReports.Visible = True
            End Select
        End Sub

        Public Sub NavigateTo(navButton As Button, targetForm As Form)
            ' Highlight active sidebar button
            If _currentActiveButton IsNot Nothing Then
                _currentActiveButton.BackColor = System.Drawing.Color.FromArgb(8, 48, 90)
                _currentActiveButton.Font = New Font("Segoe UI", 10.0!, FontStyle.Regular)
            End If

            _currentActiveButton = navButton
            If _currentActiveButton IsNot Nothing Then
                _currentActiveButton.BackColor = System.Drawing.Color.FromArgb(12, 75, 136)
                _currentActiveButton.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold)
            End If

            ' Close previous child form
            If _activeChildForm IsNot Nothing Then
                _activeChildForm.Close()
                _activeChildForm.Dispose()
            End If

            ' Load new form inside content panel
            _activeChildForm = targetForm
            targetForm.TopLevel = False
            targetForm.FormBorderStyle = FormBorderStyle.None
            targetForm.Dock = DockStyle.Fill
            pnlContent.Controls.Clear()
            pnlContent.Controls.Add(targetForm)
            pnlContent.Tag = targetForm
            targetForm.BringToFront()
            targetForm.Show()
        End Sub

        ' Sidebar Navigation Event Handlers
        Private Sub btnNavDashboard_Click(sender As Object, e As EventArgs) Handles btnNavDashboard.Click
            NavigateTo(btnNavDashboard, New FrmDashboard())
        End Sub

        Private Sub btnNavClients_Click(sender As Object, e As EventArgs) Handles btnNavClients.Click
            NavigateTo(btnNavClients, New FrmClients())
        End Sub

        Private Sub btnNavServices_Click(sender As Object, e As EventArgs) Handles btnNavServices.Click
            NavigateTo(btnNavServices, New FrmServices())
        End Sub

        Private Sub btnNavStaff_Click(sender As Object, e As EventArgs) Handles btnNavStaff.Click
            NavigateTo(btnNavStaff, New FrmStaff())
        End Sub

        Private Sub btnNavCalculator_Click(sender As Object, e As EventArgs) Handles btnNavCalculator.Click
            NavigateTo(btnNavCalculator, New FrmCalculator())
        End Sub

        Private Sub btnNavQuotes_Click(sender As Object, e As EventArgs) Handles btnNavQuotes.Click
            NavigateTo(btnNavQuotes, New FrmQuotes())
        End Sub

        Private Sub btnNavJobs_Click(sender As Object, e As EventArgs) Handles btnNavJobs.Click
            NavigateTo(btnNavJobs, New FrmJobs())
        End Sub

        Private Sub btnNavReports_Click(sender As Object, e As EventArgs) Handles btnNavReports.Click
            If Not AuthService.CanAccessModule("REPORTS") Then
                MessageBox.Show("Access Denied: You do not have permission to view Financial Reports.", "Authorization", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            NavigateTo(btnNavReports, New FrmReports())
        End Sub

        Private Sub btnNavUsers_Click(sender As Object, e As EventArgs) Handles btnNavUsers.Click
            If Not AuthService.CanAccessModule("USERS") Then
                MessageBox.Show("Access Denied: Only Administrators can access User Management.", "Authorization", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            NavigateTo(btnNavUsers, New FrmUsers())
        End Sub

        Private Sub btnNavSettings_Click(sender As Object, e As EventArgs) Handles btnNavSettings.Click
            If Not AuthService.CanAccessModule("SETTINGS") Then
                MessageBox.Show("Access Denied: Only Administrators can alter System Settings.", "Authorization", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            NavigateTo(btnNavSettings, New FrmSettings())
        End Sub

        Private Sub btnNavLogout_Click(sender As Object, e As EventArgs) Handles btnNavLogout.Click
            Dim confirmResult As DialogResult = MessageBox.Show(
                "Are you sure you want to log out of Aura Cleaning Solutions?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

            If confirmResult = DialogResult.Yes Then
                Dim auth As New AuthService()
                auth.Logout()
                Me.Hide()

                ' Show login form again
                Dim loginForm As New FrmLogin()
                If loginForm.ShowDialog() = DialogResult.OK Then
                    Me.FrmMain_Load(Nothing, Nothing)
                    Me.Show()
                Else
                    Application.Exit()
                End If
            End If
        End Sub
    End Class
End Namespace
