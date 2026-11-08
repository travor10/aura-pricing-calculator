Imports Microsoft.Data.Sqlite
Imports AuraPricingSystem.Data
Imports AuraPricingSystem.Models

Namespace Repositories
    ''' <summary>
    ''' Data repository for Services and Unit Rates (Module 4).
    ''' </summary>
    Public Class ServiceRepository
        Public Function GetAllServices() As List(Of ServiceItem)
            Dim list As New List(Of ServiceItem)
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "SELECT ServiceID, ServiceCode, ServiceName, LaborRate, Unit, CreatedAt " &
                                    "FROM Services ORDER BY ServiceCode ASC;"
                Using cmd As New SqliteCommand(sql, conn)
                    Using reader As SqliteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            list.Add(MapService(reader))
                        End While
                    End Using
                End Using
            End Using
            Return list
        End Function

        Public Function GetServiceByCode(code As String) As ServiceItem
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "SELECT ServiceID, ServiceCode, ServiceName, LaborRate, Unit, CreatedAt " &
                                    "FROM Services WHERE ServiceCode = @code LIMIT 1;"
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@code", code)
                    Using reader As SqliteDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return MapService(reader)
                        End If
                    End Using
                End Using
            End Using
            Return Nothing
        End Function

        Public Function InsertService(item As ServiceItem) As Boolean
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "INSERT INTO Services (ServiceCode, ServiceName, LaborRate, Unit) " &
                                    "VALUES (@code, @name, @rate, @unit);"
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@code", item.ServiceCode.Trim())
                    cmd.Parameters.AddWithValue("@name", item.ServiceName.Trim())
                    cmd.Parameters.AddWithValue("@rate", Convert.ToInt64(item.LaborRate))
                    cmd.Parameters.AddWithValue("@unit", item.Unit)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function

        Public Function UpdateService(item As ServiceItem) As Boolean
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "UPDATE Services SET ServiceName = @name, LaborRate = @rate, Unit = @unit " &
                                    "WHERE ServiceID = @id;"
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@name", item.ServiceName.Trim())
                    cmd.Parameters.AddWithValue("@rate", Convert.ToInt64(item.LaborRate))
                    cmd.Parameters.AddWithValue("@unit", item.Unit)
                    cmd.Parameters.AddWithValue("@id", item.ServiceID)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function

        Public Function DeleteService(serviceId As Integer) As Boolean
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "DELETE FROM Services WHERE ServiceID = @id;"
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", serviceId)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function

        Private Function MapService(reader As SqliteDataReader) As ServiceItem
            Return New ServiceItem With {
                .ServiceID = reader.GetInt32(0),
                .ServiceCode = reader.GetString(1),
                .ServiceName = reader.GetString(2),
                .LaborRate = Convert.ToDecimal(reader.GetInt64(3)),
                .Unit = reader.GetString(4),
                .CreatedAt = DateTime.Parse(reader.GetString(5))
            }
        End Function
    End Class
End Namespace
