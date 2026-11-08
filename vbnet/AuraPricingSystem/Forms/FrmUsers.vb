Imports AuraPricingSystem.Models
Imports AuraPricingSystem.Repositories
Imports AuraPricingSystem.Services

Namespace Forms
    ''' <summary>
    ''' Code-behind for User Management (Module 9).
    ''' Admin-only interface for creating user accounts, assigning RBAC roles,
    ''' updating credentials with PBKDF2 hashing, and enforcing self-deletion guards.
    ''' </summary>
    Partial Public Class FrmUsers
        Private ReadOnly _userRepo As New UserRepository()
        Private ReadOnly _logRepo As New ActivityLogRepository()
        Private _selectedUser As User = Nothing

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub FrmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' RBAC Check: User Management is strictly restricted to Admin
            If AuthService.CurrentUser Is Nothing OrElse Not AuthService.CurrentUser.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase) Then
                MessageBox.Show("Access Denied: Only Administrator accounts can access User Management.", "Security Authorization", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Enabled = False
                Return
            End If

            cboRole.SelectedIndex = 2 ' Default to Staff
            cboStatus.SelectedIndex = 0 ' Active
            LoadUsers()
            PrepareNewUser()
        End Sub

        Private Sub LoadUsers()
            Try
                Dim list = _userRepo.GetAllUsers()
                dgvUsers.Rows.Clear()
                For Each u In list
                    Dim rowIndex As Integer = dgvUsers.Rows.Add(
                        u.UserID,
                        u.Username,
                        u.Role,
                        u.Status,
                        u.CreatedAt.ToString("yyyy-MM-dd HH:mm")
                    )
                    dgvUsers.Rows(rowIndex).Tag = u
                Next
            Catch ex As Exception
                MessageBox.Show($"Error loading users: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub PrepareNewUser()
            _selectedUser = Nothing
            txtUsername.Clear()
            txtUsername.ReadOnly = False
            txtPassword.Clear()
            cboRole.SelectedIndex = 2 ' Staff
            cboStatus.SelectedIndex = 0 ' Active
            txtUsername.Focus()

            btnSave.Enabled = True
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        End Sub

        Private Function ValidateInput(isNew As Boolean) As Boolean
            If String.IsNullOrWhiteSpace(txtUsername.Text) Then
                MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtUsername.Focus()
                Return False
            End If

            If isNew AndAlso String.IsNullOrWhiteSpace(txtPassword.Text) Then
                MessageBox.Show("Password is required for new user accounts.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                Return False
            End If

            If isNew AndAlso txtPassword.Text.Length < 4 Then
                MessageBox.Show("Password must be at least 4 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                Return False
            End If

            If cboRole.SelectedIndex < 0 Then
                MessageBox.Show("Please select an authorization role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboRole.Focus()
                Return False
            End If

            Return True
        End Function

        Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
            PrepareNewUser()
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If Not ValidateInput(True) Then Return

            Dim username = txtUsername.Text.Trim()
            Dim password = txtPassword.Text
            Dim role = cboRole.SelectedItem.ToString()

            If _userRepo.CreateUser(username, password, role) Then
                _logRepo.LogAction(AuthService.CurrentUser?.UserID, "CREATE_USER", $"Created new user '{username}' with role '{role}'")
                MessageBox.Show($"User account '{username}' created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadUsers()
                PrepareNewUser()
            Else
                MessageBox.Show("Failed to create user. The username may already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
            If _selectedUser Is Nothing Then
                MessageBox.Show("Please select a user account to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If Not ValidateInput(False) Then Return

            Dim newRole = cboRole.SelectedItem.ToString()
            Dim newStatus = cboStatus.SelectedItem.ToString()
            Dim newPassword = If(String.IsNullOrWhiteSpace(txtPassword.Text), Nothing, txtPassword.Text)

            ' Last Admin Protection
            If _selectedUser.Role = "Admin" AndAlso (newRole <> "Admin" OrElse newStatus <> "Active") Then
                Dim allUsers = _userRepo.GetAllUsers()
                Dim activeAdmins = allUsers.Count(Function(u) u.Role = "Admin" AndAlso u.Status = "Active" AndAlso u.UserID <> _selectedUser.UserID)
                If activeAdmins = 0 Then
                    MessageBox.Show("Action prohibited: Cannot demote or deactivate the only remaining active Administrator.", "Security Guard", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If
            End If

            If _userRepo.UpdateUser(_selectedUser.UserID, newRole, newStatus, newPassword) Then
                Dim passMsg = If(newPassword IsNot Nothing, " (password was reset)", "")
                _logRepo.LogAction(AuthService.CurrentUser?.UserID, "UPDATE_USER", $"Updated user '{_selectedUser.Username}' (Role: {newRole}, Status: {newStatus}){passMsg}")
                MessageBox.Show($"User account '{_selectedUser.Username}' updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadUsers()
                PrepareNewUser()
            Else
                MessageBox.Show("Failed to update user account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
            If _selectedUser Is Nothing Then
                MessageBox.Show("Please select a user account to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Rule 1: Self-deletion guard
            If AuthService.CurrentUser IsNot Nothing AndAlso _selectedUser.UserID = AuthService.CurrentUser.UserID Then
                MessageBox.Show("Action prohibited: You cannot delete the currently authenticated user session.", "Security Violation", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            ' Rule 2: Last Admin guard
            If _selectedUser.Role = "Admin" Then
                Dim allUsers = _userRepo.GetAllUsers()
                Dim activeAdmins = allUsers.Count(Function(u) u.Role = "Admin" AndAlso u.Status = "Active" AndAlso u.UserID <> _selectedUser.UserID)
                If activeAdmins = 0 Then
                    MessageBox.Show("Action prohibited: Cannot delete the only remaining active Administrator.", "Security Guard", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If
            End If

            Dim result As DialogResult = MessageBox.Show(
                $"Are you sure you want to delete user '{_selectedUser.Username}'?" & vbCrLf &
                "This action is permanent and cannot be undone.",
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Try
                    If _userRepo.DeleteUser(_selectedUser.UserID) Then
                        _logRepo.LogAction(AuthService.CurrentUser?.UserID, "DELETE_USER", $"Deleted user '{_selectedUser.Username}'")
                        MessageBox.Show("User account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadUsers()
                        PrepareNewUser()
                    Else
                        MessageBox.Show("Failed to delete user account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show($"Cannot delete user because audit logs reference this user: {ex.Message}", "Integrity Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If
        End Sub

        Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
            PrepareNewUser()
        End Sub

        Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
            txtPassword.UseSystemPasswordChar = Not chkShowPassword.Checked
        End Sub

        Private Sub dgvUsers_SelectionChanged(sender As Object, e As EventArgs) Handles dgvUsers.SelectionChanged
            If dgvUsers.SelectedRows.Count > 0 Then
                Dim row = dgvUsers.SelectedRows(0)
                If row.Tag IsNot Nothing AndAlso TypeOf row.Tag Is User Then
                    _selectedUser = DirectCast(row.Tag, User)
                    txtUsername.Text = _selectedUser.Username
                    txtUsername.ReadOnly = True
                    txtPassword.Clear()
                    cboRole.SelectedItem = _selectedUser.Role
                    cboStatus.SelectedItem = _selectedUser.Status

                    btnSave.Enabled = False
                    btnUpdate.Enabled = True
                    btnDelete.Enabled = True
                End If
            End If
        End Sub
    End Class
End Namespace
