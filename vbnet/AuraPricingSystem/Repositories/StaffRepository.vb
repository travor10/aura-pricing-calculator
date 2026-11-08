Imports Microsoft.Data.Sqlite
Imports AuraPricingSystem.Data
Imports AuraPricingSystem.Models

Namespace Repositories
    ''' <summary>
    ''' Data repository for Staff Management (Module 5).
    ''' </summary>
    Public Class StaffRepository
        Public Function GetAllStaff() As List(Of StaffMember)
            Dim list As New List(Of StaffMember)
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "SELECT StaffID, StaffNo, FullName, Phone, Role, DailyRate, Status, CreatedAt " &
                                    "FROM Staff ORDER BY StaffID ASC;"
                Using cmd As New SqliteCommand(sql, conn)
                    Using reader As SqliteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            list.Add(MapStaff(reader))
                        End While
                    End Using
                End Using
            End Using
            Return list
        End Function

        Public Function GetActiveStaff() As List(Of StaffMember)
            Dim list As New List(Of StaffMember)
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "SELECT StaffID, StaffNo, FullName, Phone, Role, DailyRate, Status, CreatedAt " &
                                    "FROM Staff WHERE Status = 'Active' ORDER BY FullName ASC;"
                Using cmd As New SqliteCommand(sql, conn)
                    Using reader As SqliteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            list.Add(MapStaff(reader))
                        End While
                    End Using
                End Using
            End Using
            Return list
        End Function

        Public Function GetNextStaffNo() As String
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "SELECT MAX(StaffID) FROM Staff;"
                Using cmd As New SqliteCommand(sql, conn)
                    Dim result As Object = cmd.ExecuteScalar()
                    Dim nextId As Integer = 1
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        nextId = Convert.ToInt32(result) + 1
                    End If
                    Return $"ST{nextId:D3}"
                End Using
            End Using
        End Function

        Public Function InsertStaff(staff As StaffMember) As Boolean
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "INSERT INTO Staff (StaffNo, FullName, Phone, Role, DailyRate, Status) " &
                                    "VALUES (@no, @name, @phone, @role, @rate, @status);"
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@no", staff.StaffNo)
                    cmd.Parameters.AddWithValue("@name", staff.FullName)
                    cmd.Parameters.AddWithValue("@phone", staff.Phone)
                    cmd.Parameters.AddWithValue("@role", staff.Role)
                    cmd.Parameters.AddWithValue("@rate", Convert.ToInt64(staff.DailyRate))
                    cmd.Parameters.AddWithValue("@status", staff.Status)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function

        Public Function UpdateStaff(staff As StaffMember) As Boolean
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "UPDATE Staff SET FullName = @name, Phone = @phone, Role = @role, " &
                                    "DailyRate = @rate, Status = @status WHERE StaffID = @id;"
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@name", staff.FullName)
                    cmd.Parameters.AddWithValue("@phone", staff.Phone)
                    cmd.Parameters.AddWithValue("@role", staff.Role)
                    cmd.Parameters.AddWithValue("@rate", Convert.ToInt64(staff.DailyRate))
                    cmd.Parameters.AddWithValue("@status", staff.Status)
                    cmd.Parameters.AddWithValue("@id", staff.StaffID)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function

        Public Function DeleteStaff(staffId As Integer) As Boolean
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "DELETE FROM Staff WHERE StaffID = @id;"
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", staffId)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function

        Private Function MapStaff(reader As SqliteDataReader) As StaffMember
            Return New StaffMember With {
                .StaffID = reader.GetInt32(0),
                .StaffNo = reader.GetString(1),
                .FullName = reader.GetString(2),
                .Phone = reader.GetString(3),
                .Role = reader.GetString(4),
                .DailyRate = Convert.ToDecimal(reader.GetInt64(5)),
                .Status = reader.GetString(6),
                .CreatedAt = DateTime.Parse(reader.GetString(7))
            }
        End Function
    End Class
End Namespace
