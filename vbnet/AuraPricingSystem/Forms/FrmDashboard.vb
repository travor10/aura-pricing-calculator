Imports AuraPricingSystem.Services
Imports AuraPricingSystem.Helpers
Imports AuraPricingSystem.Models

Namespace Forms
    ''' <summary>
    ''' MODULE 2: DASHBOARD
    ''' Displays live database statistics (Clients, Quotes This Month, Active Jobs, Revenue in UGX)
    ''' and populates the Recent Activities grid from the audit trail table.
    ''' </summary>
    Public Class FrmDashboard
        Private ReadOnly _dashboardService As New DashboardService()

        Private Sub FrmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            LoadDashboardData()
        End Sub

        Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
            LoadDashboardData()
        End Sub

        Public Sub LoadDashboardData()
            Try
                Dim stats = _dashboardService.GetDashboardStatistics()

                ' 1. Populate Metric Cards
                lblClientsValue.Text = stats.ClientsCount.ToString()
                lblQuotesValue.Text = stats.QuotesThisMonthCount.ToString()
                lblJobsValue.Text = stats.ActiveJobsCount.ToString()

                ' Display Revenue in standard UGX or abbreviated M/K
                If stats.TotalRevenueUgx >= 1000000D Then
                    lblRevenueValue.Text = $"UGX {(stats.TotalRevenueUgx / 1000000D):0.#}M"
                ElseIf stats.TotalRevenueUgx > 0D Then
                    lblRevenueValue.Text = CurrencyFormatter.FormatUgx(stats.TotalRevenueUgx)
                Else
                    lblRevenueValue.Text = "UGX 0"
                End If

                ' 2. Populate Recent Activities DataGridView
                dgvRecentActivities.Rows.Clear()
                Dim counter As Integer = 1
                For Each log In stats.RecentActivities
                    dgvRecentActivities.Rows.Add(
                        counter.ToString(),
                        log.Activity,
                        log.Username,
                        log.LogTimestamp.ToString("dd MMM yyyy HH:mm")
                    )
                    counter += 1
                Next

            Catch ex As Exception
                MessageBox.Show($"Failed to load dashboard metrics: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace
