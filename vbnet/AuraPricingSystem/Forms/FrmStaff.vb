Imports AuraPricingSystem.Helpers
Imports AuraPricingSystem.Models
Imports AuraPricingSystem.Repositories
Imports AuraPricingSystem.Services

Namespace Forms
    ''' <summary>
    ''' Code-behind for Staff Management (Module 5).
    ''' Manages field staff, roles, status, and baseline daily labor compensation rates.
    ''' </summary>
    Partial Public Class FrmStaff
        Private ReadOnly _staffRepo As New StaffRepository()
        Private ReadOnly _logRepo As New ActivityLogRepository()
        Private _selectedStaff As StaffMember = Nothing

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub FrmStaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            cboRole.SelectedIndex = 0
            cboStatus.SelectedIndex = 0
            LoadStaff()
            PrepareNewStaff()
        End Sub

        Private Sub LoadStaff(Optional search As String = "")
            Try
                Dim list = _staffRepo.GetAllStaff()
                If Not String.IsNullOrWhiteSpace(search) Then
                    Dim q = search.Trim().ToLower()
                    list = list.Where(Function(s) s.FullName.ToLower().Contains(q) OrElse
                                                  s.StaffNo.ToLower().Contains(q) OrElse
                                                  s.Phone.ToLower().Contains(q) OrElse
                                                  s.Role.ToLower().Contains(q)).ToList()
                End If

                dgvStaff.Rows.Clear()
                For Each s In list
                    Dim rowIndex As Integer = dgvStaff.Rows.Add(
                        s.StaffNo,
                        s.FullName,
                        s.Phone,
                        s.Role,
                        CurrencyFormatter.FormatUgx(s.DailyRate),
                        s.Status
                    )
                    dgvStaff.Rows(rowIndex).Tag = s
                Next
            Catch ex As Exception
                MessageBox.Show($"Error loading staff: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub PrepareNewStaff()
            _selectedStaff = Nothing
            txtStaffNo.Text = _staffRepo.GetNextStaffNo()
            txtFullName.Clear()
            txtPhone.Clear()
            cboRole.SelectedIndex = 0
            numDailyRate.Value = 30000 ' Bukiika standard rate
            cboStatus.SelectedIndex = 0 ' Active
            txtFullName.Focus()

            btnSave.Enabled = True
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        End Sub

        Private Function ValidateInput() As Boolean
            If String.IsNullOrWhiteSpace(txtFullName.Text) Then
                MessageBox.Show("Staff full name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFullName.Focus()
                Return False
            End If

            If String.IsNullOrWhiteSpace(txtPhone.Text) Then
                MessageBox.Show("Staff phone number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPhone.Focus()
                Return False
            End If

            If cboRole.SelectedIndex < 0 Then
                MessageBox.Show("Please select a staff role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboRole.Focus()
                Return False
            End If

            If numDailyRate.Value < 0 Then
                MessageBox.Show("Daily rate cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                numDailyRate.Focus()
                Return False
            End If

            Return True
        End Function

        Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
            PrepareNewStaff()
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If Not ValidateInput() Then Return

            Dim s As New StaffMember With {
                .StaffNo = txtStaffNo.Text.Trim(),
                .FullName = txtFullName.Text.Trim(),
                .Phone = txtPhone.Text.Trim(),
                .Role = cboRole.SelectedItem.ToString(),
                .DailyRate = numDailyRate.Value,
                .Status = cboStatus.SelectedItem.ToString()
            }

            If _staffRepo.InsertStaff(s) Then
                _logRepo.LogAction(AuthService.CurrentUser?.UserID, "CREATE_STAFF", $"Registered staff {s.StaffNo} - {s.FullName} ({s.Role})")
                MessageBox.Show($"Staff member '{s.FullName}' ({s.StaffNo}) added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadStaff(txtSearch.Text)
                PrepareNewStaff()
            Else
                MessageBox.Show("Failed to save staff member. Staff number may already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
            If _selectedStaff Is Nothing Then
                MessageBox.Show("Please select a staff member to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If Not ValidateInput() Then Return

            _selectedStaff.FullName = txtFullName.Text.Trim()
            _selectedStaff.Phone = txtPhone.Text.Trim()
            _selectedStaff.Role = cboRole.SelectedItem.ToString()
            _selectedStaff.DailyRate = numDailyRate.Value
            _selectedStaff.Status = cboStatus.SelectedItem.ToString()

            If _staffRepo.UpdateStaff(_selectedStaff) Then
                _logRepo.LogAction(AuthService.CurrentUser?.UserID, "UPDATE_STAFF", $"Updated staff {_selectedStaff.StaffNo} - {_selectedStaff.FullName}")
                MessageBox.Show($"Staff member '{_selectedStaff.StaffNo}' updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadStaff(txtSearch.Text)
                PrepareNewStaff()
            Else
                MessageBox.Show("Failed to update staff member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
            If _selectedStaff Is Nothing Then
                MessageBox.Show("Please select a staff member to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim result As DialogResult = MessageBox.Show(
                $"Are you sure you want to delete staff member '{_selectedStaff.FullName}' ({_selectedStaff.StaffNo})?",
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                Try
                    If _staffRepo.DeleteStaff(_selectedStaff.StaffID) Then
                        _logRepo.LogAction(AuthService.CurrentUser?.UserID, "DELETE_STAFF", $"Deleted staff {_selectedStaff.StaffNo}")
                        MessageBox.Show("Staff member deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadStaff(txtSearch.Text)
                        PrepareNewStaff()
                    Else
                        MessageBox.Show("Failed to delete staff member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show($"Cannot delete staff because they are assigned to jobs: {ex.Message}", "Integrity Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If
        End Sub

        Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
            PrepareNewStaff()
        End Sub

        Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
            LoadStaff(txtSearch.Text)
        End Sub

        Private Sub dgvStaff_SelectionChanged(sender As Object, e As EventArgs) Handles dgvStaff.SelectionChanged
            If dgvStaff.SelectedRows.Count > 0 Then
                Dim row = dgvStaff.SelectedRows(0)
                If row.Tag IsNot Nothing AndAlso TypeOf row.Tag Is StaffMember Then
                    _selectedStaff = DirectCast(row.Tag, StaffMember)
                    txtStaffNo.Text = _selectedStaff.StaffNo
                    txtFullName.Text = _selectedStaff.FullName
                    txtPhone.Text = _selectedStaff.Phone
                    cboRole.SelectedItem = _selectedStaff.Role
                    numDailyRate.Value = _selectedStaff.DailyRate
                    cboStatus.SelectedItem = _selectedStaff.Status

                    btnSave.Enabled = False
                    btnUpdate.Enabled = True
                    btnDelete.Enabled = True
                End If
            End If
        End Sub
    End Class
End Namespace
