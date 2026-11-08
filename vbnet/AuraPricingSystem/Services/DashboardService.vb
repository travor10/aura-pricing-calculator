Imports Microsoft.Data.Sqlite
Imports AuraPricingSystem.Data
Imports AuraPricingSystem.Models
Imports AuraPricingSystem.Repositories

Namespace Services
    ''' <summary>
    ''' Aggregates live database statistics and audit records for Module 2 Dashboard.
    ''' </summary>
    Public Class DashboardService
        Private ReadOnly _activityRepo As ActivityLogRepository

        Public Sub New()
            _activityRepo = New ActivityLogRepository()
        End Sub

        Public Class DashboardStats
            Public Property ClientsCount As Integer
            Public Property QuotesThisMonthCount As Integer
            Public Property ActiveJobsCount As Integer
            Public Property TotalRevenueUgx As Decimal
            Public Property RecentActivities As List(Of ActivityLog)
        End Class

        Public Function GetDashboardStatistics() As DashboardStats
            Dim stats As New DashboardStats()

            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                ' 1. Total Clients
                Using cmd As New SqliteCommand("SELECT COUNT(*) FROM Clients;", conn)
                    stats.ClientsCount = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                ' 2. Quotes This Month
                Dim currentMonthStart As String = DateTime.Today.ToString("yyyy-MM-01")
                Using cmd As New SqliteCommand("SELECT COUNT(*) FROM Quotations WHERE QuoteDate >= @mstart;", conn)
                    cmd.Parameters.AddWithValue("@mstart", currentMonthStart)
                    stats.QuotesThisMonthCount = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                ' 3. Active Jobs (Scheduled or In Progress)
                Using cmd As New SqliteCommand("SELECT COUNT(*) FROM Jobs WHERE Status IN ('Scheduled', 'In Progress');", conn)
                    stats.ActiveJobsCount = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                ' 4. Total Revenue (UGX) from Accepted or Completed quotes
                Dim revenueSql As String = "
                    SELECT COALESCE(SUM(TotalAmount), 0) FROM Quotations WHERE Status = 'Accepted';"
                Using cmd As New SqliteCommand(revenueSql, conn)
                    stats.TotalRevenueUgx = Convert.ToDecimal(cmd.ExecuteScalar())
                End Using
            End Using

            ' 5. Recent Activities
            stats.RecentActivities = _activityRepo.GetRecentActivities(10)

            Return stats
        End Function
    End Class
End Namespace
