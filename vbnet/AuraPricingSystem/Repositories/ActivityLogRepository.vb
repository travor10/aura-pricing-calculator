Imports Microsoft.Data.Sqlite
Imports AuraPricingSystem.Data
Imports AuraPricingSystem.Models

Namespace Repositories
    ''' <summary>
    ''' Data repository for audit logging and Dashboard Recent Activities (Module 2).
    ''' </summary>
    Public Class ActivityLogRepository
        Public Shared Sub Log(activity As String, username As String)
            Try
                Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                    Dim sql As String = "INSERT INTO ActivityLogs (Activity, Username) VALUES (@act, @user);"
                    Using cmd As New SqliteCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@act", activity)
                        cmd.Parameters.AddWithValue("@user", If(String.IsNullOrWhiteSpace(username), "System", username))
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                ' Fail safely without halting core business operations
                Debug.WriteLine($"Failed to write activity log: {ex.Message}")
            End Try
        End Sub

        Public Function GetRecentActivities(Optional limit As Integer = 10) As List(Of ActivityLog)
            Dim list As New List(Of ActivityLog)
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = $"SELECT LogID, Activity, Username, LogTimestamp FROM ActivityLogs ORDER BY LogID DESC LIMIT {limit};"
                Using cmd As New SqliteCommand(sql, conn)
                    Using reader As SqliteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            list.Add(New ActivityLog With {
                                .LogID = reader.GetInt32(0),
                                .Activity = reader.GetString(1),
                                .Username = reader.GetString(2),
                                .LogTimestamp = DateTime.Parse(reader.GetString(3))
                            })
                        End While
                    End Using
                End Using
            End Using
            Return list
        End Function
    End Class
End Namespace
