Imports AuraPricingSystem.Helpers
Imports AuraPricingSystem.Models
Imports AuraPricingSystem.Repositories
Imports AuraPricingSystem.Services

Namespace Forms
    ''' <summary>
    ''' Code-behind for Services and Unit Rates Catalog (Module 4).
    ''' Manages standard services, billing units, and default labor rates.
    ''' Note: Updating rates here updates the catalog for future quotations;
    ''' historical quotations preserve their locked snapshot rates.
    ''' </summary>
    Partial Public Class FrmServices
        Private ReadOnly _serviceRepo As New ServiceRepository()
        Private ReadOnly _logRepo As New ActivityLogRepository()
        Private _selectedService As ServiceItem = Nothing

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub FrmServices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            cboUnit.SelectedIndex = 0
            LoadServices()
            PrepareNewService()
        End Sub

        Private Sub LoadServices()
            Try
                Dim list = _serviceRepo.GetAllServices()
                dgvServices.Rows.Clear()
                For Each s In list
                    Dim rowIndex As Integer = dgvServices.Rows.Add(
                        s.ServiceCode,
                        s.ServiceName,
                        CurrencyFormatter.FormatUgx(s.LaborRate),
                        s.Unit
                    )
                    dgvServices.Rows(rowIndex).Tag = s
                Next
            Catch ex As Exception
                MessageBox.Show($"Error loading services: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub PrepareNewService()
            _selectedService = Nothing
            txtServiceCode.Clear()
            txtServiceCode.ReadOnly = False
            txtServiceName.Clear()
            numLaborRate.Value = 30000 ' Standard default day rate
            cboUnit.SelectedIndex = 0
            txtServiceCode.Focus()

            btnSave.Enabled = True
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        End Sub

        Private Function ValidateInput() As Boolean
            If String.IsNullOrWhiteSpace(txtServiceCode.Text) Then
                MessageBox.Show("Service code is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtServiceCode.Focus()
                Return False
            End If

            If String.IsNullOrWhiteSpace(txtServiceName.Text) Then
                MessageBox.Show("Service name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtServiceName.Focus()
                Return False
            End If

            If numLaborRate.Value < 0 Then
                MessageBox.Show("Labor rate cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                numLaborRate.Focus()
                Return False
            End If

            If cboUnit.SelectedIndex < 0 Then
                MessageBox.Show("Please select a billing unit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboUnit.Focus()
                Return False
            End If

            Return True
        End Function

        Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
            PrepareNewService()
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If Not ValidateInput() Then Return

            Dim item As New ServiceItem With {
                .ServiceCode = txtServiceCode.Text.Trim().ToUpper(),
                .ServiceName = txtServiceName.Text.Trim(),
                .LaborRate = numLaborRate.Value,
                .Unit = cboUnit.SelectedItem.ToString()
            }

            If _serviceRepo.InsertService(item) Then
                _logRepo.LogAction(AuthService.CurrentUser?.UserID, "CREATE_SERVICE", $"Created service {item.ServiceCode} - {item.ServiceName} at {CurrencyFormatter.FormatUgx(item.LaborRate)}")
                MessageBox.Show($"Service '{item.ServiceName}' added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadServices()
                PrepareNewService()
            Else
                MessageBox.Show("Failed to save service. Code may already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
            If _selectedService Is Nothing Then
                MessageBox.Show("Please select a service from the table to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If Not ValidateInput() Then Return

            _selectedService.ServiceName = txtServiceName.Text.Trim()
            _selectedService.LaborRate = numLaborRate.Value
            _selectedService.Unit = cboUnit.SelectedItem.ToString()

            If _serviceRepo.UpdateService(_selectedService) Then
                _logRepo.LogAction(AuthService.CurrentUser?.UserID, "UPDATE_SERVICE", $"Updated service {_selectedService.ServiceCode}: rate set to {CurrencyFormatter.FormatUgx(_selectedService.LaborRate)}")
                MessageBox.Show($"Service '{_selectedService.ServiceCode}' updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadServices()
                PrepareNewService()
            Else
                MessageBox.Show("Failed to update service.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
            If _selectedService Is Nothing Then
                MessageBox.Show("Please select a service to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim result As DialogResult = MessageBox.Show(
                $"Are you sure you want to delete service '{_selectedService.ServiceName}' ({_selectedService.ServiceCode})?",
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                Try
                    If _serviceRepo.DeleteService(_selectedService.ServiceID) Then
                        _logRepo.LogAction(AuthService.CurrentUser?.UserID, "DELETE_SERVICE", $"Deleted service {_selectedService.ServiceCode}")
                        MessageBox.Show("Service deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadServices()
                        PrepareNewService()
                    Else
                        MessageBox.Show("Failed to delete service.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show($"Cannot delete service because it is referenced in quotations: {ex.Message}", "Integrity Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If
        End Sub

        Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
            PrepareNewService()
        End Sub

        Private Sub dgvServices_SelectionChanged(sender As Object, e As EventArgs) Handles dgvServices.SelectionChanged
            If dgvServices.SelectedRows.Count > 0 Then
                Dim row = dgvServices.SelectedRows(0)
                If row.Tag IsNot Nothing AndAlso TypeOf row.Tag Is ServiceItem Then
                    _selectedService = DirectCast(row.Tag, ServiceItem)
                    txtServiceCode.Text = _selectedService.ServiceCode
                    txtServiceCode.ReadOnly = True
                    txtServiceName.Text = _selectedService.ServiceName
                    numLaborRate.Value = _selectedService.LaborRate
                    cboUnit.SelectedItem = _selectedService.Unit

                    btnSave.Enabled = False
                    btnUpdate.Enabled = True
                    btnDelete.Enabled = True
                End If
            End If
        End Sub
    End Class
End Namespace
