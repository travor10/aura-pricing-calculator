Imports AuraPricingSystem.Models
Imports AuraPricingSystem.Repositories
Imports AuraPricingSystem.Services
Imports System.Globalization

Namespace Forms
    ''' <summary>
    ''' Code-behind for Company Settings & Margin Guide Management (Module 11).
    ''' Admin-only interface for company info, document prefixes, target margin defaults,
    ''' and editable benchmark margin bands per service category.
    ''' </summary>
    Partial Public Class FrmSettings
        Private ReadOnly _settingsRepo As New SettingsRepository()
        Private ReadOnly _logRepo As New ActivityLogRepository()
        Private _marginGuides As List(Of MarginGuideItem)

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub FrmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' RBAC Check: Settings are restricted to Admin
            If AuthService.CurrentUser Is Nothing OrElse Not AuthService.CurrentUser.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase) Then
                MessageBox.Show("Access Denied: Only Administrator accounts can configure company settings and margin guides.", "Security Authorization", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Enabled = False
                Return
            End If

            LoadAllData()
        End Sub

        Private Sub LoadAllData()
            Try
                Dim s = _settingsRepo.GetSettings()
                txtCompanyName.Text = s.CompanyName
                txtPhone.Text = s.CompanyPhone
                txtEmail.Text = s.CompanyEmail
                txtAddress.Text = s.CompanyAddress
                txtQuotePrefix.Text = s.QuotePrefix
                txtJobPrefix.Text = s.JobPrefix
                numDefaultMargin.Value = Math.Round(s.DefaultMargin * 100D, 1)

                LoadMarginGuides()
            Catch ex As Exception
                MessageBox.Show($"Error loading system settings: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub LoadMarginGuides()
            _marginGuides = _settingsRepo.GetAllMarginGuides()
            dgvMarginGuide.Rows.Clear()
            For Each g In _marginGuides
                Dim rowIndex As Integer = dgvMarginGuide.Rows.Add(
                    g.JobType,
                    (g.MinMargin * 100D).ToString("0.0"),
                    (g.MaxMargin * 100D).ToString("0.0"),
                    g.DisplayRange
                )
                dgvMarginGuide.Rows(rowIndex).Tag = g
            Next
        End Sub

        Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
            If String.IsNullOrWhiteSpace(txtCompanyName.Text) Then
                MessageBox.Show("Company name cannot be blank.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCompanyName.Focus()
                Return
            End If

            Try
                Dim s As New SystemSettings With {
                    .CompanyName = txtCompanyName.Text.Trim(),
                    .CompanyPhone = txtPhone.Text.Trim(),
                    .CompanyEmail = txtEmail.Text.Trim(),
                    .CompanyAddress = txtAddress.Text.Trim(),
                    .QuotePrefix = txtQuotePrefix.Text.Trim(),
                    .JobPrefix = txtJobPrefix.Text.Trim(),
                    .DefaultMargin = numDefaultMargin.Value / 100D,
                    .Currency = "UGX"
                }

                _settingsRepo.SaveSettings(s)

                ' Save margin guide updates from grid
                For Each row As DataGridViewRow In dgvMarginGuide.Rows
                    If row.Tag IsNot Nothing AndAlso TypeOf row.Tag Is MarginGuideItem Then
                        Dim item = DirectCast(row.Tag, MarginGuideItem)
                        Dim minVal As Decimal
                        Dim maxVal As Decimal
                        Dim minStr = Convert.ToString(row.Cells(colMinMargin.Index).Value)
                        Dim maxStr = Convert.ToString(row.Cells(colMaxMargin.Index).Value)
                        Dim dispStr = Convert.ToString(row.Cells(colDisplayRange.Index).Value)

                        If Decimal.TryParse(minStr, NumberStyles.Any, CultureInfo.InvariantCulture, minVal) Then
                            item.MinMargin = minVal / 100D
                        End If
                        If Decimal.TryParse(maxStr, NumberStyles.Any, CultureInfo.InvariantCulture, maxVal) Then
                            item.MaxMargin = maxVal / 100D
                        End If
                        If Not String.IsNullOrWhiteSpace(dispStr) Then
                            item.DisplayRange = dispStr.Trim()
                        End If

                        _settingsRepo.UpdateMarginGuide(item)
                    End If
                Next

                _logRepo.LogAction(AuthService.CurrentUser?.UserID, "UPDATE_SETTINGS", "Updated system profile, document prefixes, and margin guide benchmark bands")
                MessageBox.Show("System settings and margin guide benchmarks saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadAllData()
            Catch ex As Exception
                MessageBox.Show($"Error saving settings: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
            LoadAllData()
        End Sub
    End Class
End Namespace
