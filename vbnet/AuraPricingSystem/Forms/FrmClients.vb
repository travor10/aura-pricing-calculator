Imports AuraPricingSystem.Models
Imports AuraPricingSystem.Repositories
Imports AuraPricingSystem.Services

Namespace Forms
    ''' <summary>
    ''' Code-behind for Client Management (Module 3).
    ''' Provides complete CRUD operations with search, validation, and auto-numbering.
    ''' </summary>
    Partial Public Class FrmClients
        Private ReadOnly _clientRepo As New ClientRepository()
        Private ReadOnly _logRepo As New ActivityLogRepository()
        Private _selectedClient As Client = Nothing

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub FrmClients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            cboClientType.SelectedIndex = 0
            LoadClients()
            PrepareNewClient()
        End Sub

        Private Sub LoadClients(Optional search As String = "")
            Try
                Dim list As List(Of Client)
                If String.IsNullOrWhiteSpace(search) Then
                    list = _clientRepo.GetAllClients()
                Else
                    list = _clientRepo.SearchClients(search.Trim())
                End If

                dgvClients.Rows.Clear()
                For Each c In list
                    Dim rowIndex As Integer = dgvClients.Rows.Add(c.ClientNo, c.FullName, c.Phone, c.Location, c.ClientType)
                    dgvClients.Rows(rowIndex).Tag = c
                Next
            Catch ex As Exception
                MessageBox.Show($"Error loading clients: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub PrepareNewClient()
            _selectedClient = Nothing
            txtClientNo.Text = _clientRepo.GetNextClientNo()
            txtFullName.Clear()
            txtPhone.Clear()
            txtLocation.Clear()
            cboClientType.SelectedIndex = 0
            txtFullName.Focus()

            btnSave.Enabled = True
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        End Sub

        Private Function ValidateInput() As Boolean
            If String.IsNullOrWhiteSpace(txtFullName.Text) Then
                MessageBox.Show("Client full name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFullName.Focus()
                Return False
            End If

            If String.IsNullOrWhiteSpace(txtPhone.Text) Then
                MessageBox.Show("Phone number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPhone.Focus()
                Return False
            End If

            If String.IsNullOrWhiteSpace(txtLocation.Text) Then
                MessageBox.Show("Location/Address is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtLocation.Focus()
                Return False
            End If

            If cboClientType.SelectedIndex < 0 Then
                MessageBox.Show("Please select a client type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboClientType.Focus()
                Return False
            End If

            Return True
        End Function

        Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
            PrepareNewClient()
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If Not ValidateInput() Then Return

            Dim client As New Client With {
                .ClientNo = txtClientNo.Text.Trim(),
                .FullName = txtFullName.Text.Trim(),
                .Phone = txtPhone.Text.Trim(),
                .Location = txtLocation.Text.Trim(),
                .ClientType = cboClientType.SelectedItem.ToString()
            }

            If _clientRepo.InsertClient(client) Then
                _logRepo.LogAction(AuthService.CurrentUser?.UserID, "CREATE_CLIENT", $"Registered new client {client.ClientNo} - {client.FullName}")
                MessageBox.Show($"Client {client.FullName} ({client.ClientNo}) registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadClients(txtSearch.Text)
                PrepareNewClient()
            Else
                MessageBox.Show("Failed to save client. Client number may already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
            If _selectedClient Is Nothing Then
                MessageBox.Show("Please select a client from the table to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If Not ValidateInput() Then Return

            _selectedClient.FullName = txtFullName.Text.Trim()
            _selectedClient.Phone = txtPhone.Text.Trim()
            _selectedClient.Location = txtLocation.Text.Trim()
            _selectedClient.ClientType = cboClientType.SelectedItem.ToString()

            If _clientRepo.UpdateClient(_selectedClient) Then
                _logRepo.LogAction(AuthService.CurrentUser?.UserID, "UPDATE_CLIENT", $"Updated client {_selectedClient.ClientNo} - {_selectedClient.FullName}")
                MessageBox.Show($"Client {_selectedClient.ClientNo} updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadClients(txtSearch.Text)
                PrepareNewClient()
            Else
                MessageBox.Show("Failed to update client record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
            If _selectedClient Is Nothing Then
                MessageBox.Show("Please select a client from the table to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim result As DialogResult = MessageBox.Show(
                $"Are you sure you want to delete client '{_selectedClient.FullName}' ({_selectedClient.ClientNo})?" & vbCrLf &
                "Note: Clients linked to existing quotations or jobs cannot be deleted.",
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                Try
                    If _clientRepo.DeleteClient(_selectedClient.ClientID) Then
                        _logRepo.LogAction(AuthService.CurrentUser?.UserID, "DELETE_CLIENT", $"Deleted client {_selectedClient.ClientNo} - {_selectedClient.FullName}")
                        MessageBox.Show("Client record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadClients(txtSearch.Text)
                        PrepareNewClient()
                    Else
                        MessageBox.Show("Failed to delete client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show($"Cannot delete client because related records (quotes/jobs) exist. {ex.Message}", "Foreign Key Constraint", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If
        End Sub

        Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
            PrepareNewClient()
        End Sub

        Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
            LoadClients(txtSearch.Text)
        End Sub

        Private Sub dgvClients_SelectionChanged(sender As Object, e As EventArgs) Handles dgvClients.SelectionChanged
            If dgvClients.SelectedRows.Count > 0 Then
                Dim row = dgvClients.SelectedRows(0)
                If row.Tag IsNot Nothing AndAlso TypeOf row.Tag Is Client Then
                    _selectedClient = DirectCast(row.Tag, Client)
                    txtClientNo.Text = _selectedClient.ClientNo
                    txtFullName.Text = _selectedClient.FullName
                    txtPhone.Text = _selectedClient.Phone
                    txtLocation.Text = _selectedClient.Location
                    cboClientType.SelectedItem = _selectedClient.ClientType

                    btnSave.Enabled = False
                    btnUpdate.Enabled = True
                    btnDelete.Enabled = True
                End If
            End If
        End Sub
    End Class
End Namespace
