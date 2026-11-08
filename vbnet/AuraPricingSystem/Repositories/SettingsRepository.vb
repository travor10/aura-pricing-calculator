Imports Microsoft.Data.Sqlite
Imports AuraPricingSystem.Data
Imports AuraPricingSystem.Models
Imports System.Globalization

Namespace Repositories
    ''' <summary>
    ''' Data repository for Company Settings and Margin Guides (Module 11).
    ''' </summary>
    Public Class SettingsRepository
        Public Function GetSettings() As SystemSettings
            Dim settings As New SystemSettings()
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "SELECT SettingKey, SettingValue FROM Settings;"
                Using cmd As New SqliteCommand(sql, conn)
                    Using reader As SqliteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim key As String = reader.GetString(0)
                            Dim val As String = reader.GetString(1)

                            Select Case key
                                Case "CompanyName"
                                    settings.CompanyName = val
                                Case "DefaultMargin"
                                    Dim m As Decimal
                                    If Decimal.TryParse(val, NumberStyles.Any, CultureInfo.InvariantCulture, m) Then
                                        settings.DefaultMargin = m
                                    End If
                                Case "Currency"
                                    settings.Currency = val
                                Case "QuotePrefix"
                                    settings.QuotePrefix = val
                                Case "JobPrefix"
                                    settings.JobPrefix = val
                                Case "ClientPrefix"
                                    settings.ClientPrefix = val
                                Case "StaffPrefix"
                                    settings.StaffPrefix = val
                                Case "CompanyPhone"
                                    settings.CompanyPhone = val
                                Case "CompanyEmail"
                                    settings.CompanyEmail = val
                                Case "CompanyAddress"
                                    settings.CompanyAddress = val
                            End Select
                        End While
                    End Using
                End Using
            End Using
            Return settings
        End Function

        Public Function SaveSettings(settings As SystemSettings) As Boolean
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Using trans As SqliteTransaction = conn.BeginTransaction()
                    Try
                        SaveSettingValue(conn, trans, "CompanyName", settings.CompanyName)
                        SaveSettingValue(conn, trans, "DefaultMargin", settings.DefaultMargin.ToString(CultureInfo.InvariantCulture))
                        SaveSettingValue(conn, trans, "Currency", settings.Currency)
                        SaveSettingValue(conn, trans, "QuotePrefix", settings.QuotePrefix)
                        SaveSettingValue(conn, trans, "JobPrefix", settings.JobPrefix)
                        SaveSettingValue(conn, trans, "ClientPrefix", settings.ClientPrefix)
                        SaveSettingValue(conn, trans, "StaffPrefix", settings.StaffPrefix)
                        SaveSettingValue(conn, trans, "CompanyPhone", settings.CompanyPhone)
                        SaveSettingValue(conn, trans, "CompanyEmail", settings.CompanyEmail)
                        SaveSettingValue(conn, trans, "CompanyAddress", settings.CompanyAddress)
                        trans.Commit()
                        Return True
                    Catch ex As Exception
                        trans.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        End Function

        Public Function GetAllMarginGuides() As List(Of MarginGuideItem)
            Dim list As New List(Of MarginGuideItem)
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "SELECT GuideID, JobType, MinMargin, MaxMargin, DisplayRange FROM MarginGuide ORDER BY GuideID ASC;"
                Using cmd As New SqliteCommand(sql, conn)
                    Using reader As SqliteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            list.Add(New MarginGuideItem With {
                                .GuideID = reader.GetInt32(0),
                                .JobType = reader.GetString(1),
                                .MinMargin = Convert.ToDecimal(reader.GetDouble(2)),
                                .MaxMargin = Convert.ToDecimal(reader.GetDouble(3)),
                                .DisplayRange = reader.GetString(4)
                            })
                        End While
                    End Using
                End Using
            End Using
            Return list
        End Function

        Public Function GetMarginGuideForJobType(jobType As String) As MarginGuideItem
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "SELECT GuideID, JobType, MinMargin, MaxMargin, DisplayRange FROM MarginGuide WHERE JobType = @type LIMIT 1;"
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@type", jobType)
                    Using reader As SqliteDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return New MarginGuideItem With {
                                .GuideID = reader.GetInt32(0),
                                .JobType = reader.GetString(1),
                                .MinMargin = Convert.ToDecimal(reader.GetDouble(2)),
                                .MaxMargin = Convert.ToDecimal(reader.GetDouble(3)),
                                .DisplayRange = reader.GetString(4)
                            }
                        End If
                    End Using
                End Using
            End Using

            ' Fallback to survival floor
            Return New MarginGuideItem With {
                .JobType = jobType,
                .MinMargin = 0.10D,
                .MaxMargin = 0.20D,
                .DisplayRange = "10%–20%"
            }
        End Function

        Public Function UpdateMarginGuide(item As MarginGuideItem) As Boolean
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "UPDATE MarginGuide SET MinMargin = @min, MaxMargin = @max, DisplayRange = @disp WHERE GuideID = @id;"
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@min", Convert.ToDouble(item.MinMargin))
                    cmd.Parameters.AddWithValue("@max", Convert.ToDouble(item.MaxMargin))
                    cmd.Parameters.AddWithValue("@disp", item.DisplayRange)
                    cmd.Parameters.AddWithValue("@id", item.GuideID)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function

        Private Sub SaveSettingValue(conn As SqliteConnection, trans As SqliteTransaction, key As String, val As String)
            Dim sql As String = "INSERT INTO Settings (SettingKey, SettingValue) VALUES (@k, @v) " &
                                "ON CONFLICT(SettingKey) DO UPDATE SET SettingValue = @v;"
            Using cmd As New SqliteCommand(sql, conn, trans)
                cmd.Parameters.AddWithValue("@k", key)
                cmd.Parameters.AddWithValue("@v", val)
                cmd.ExecuteNonQuery()
            End Using
        End Sub
    End Class
End Namespace
