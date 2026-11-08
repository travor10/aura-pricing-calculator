Imports Microsoft.Data.Sqlite
Imports AuraPricingSystem.Data
Imports AuraPricingSystem.Models
Imports AuraPricingSystem.Helpers

Namespace Repositories
    ''' <summary>
    ''' Data repository for User authentication and management.
    ''' Parameterized queries only to eliminate SQL injection vulnerabilities.
    ''' </summary>
    Public Class UserRepository
        Public Function Authenticate(username As String, password As String) As User
            If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
                Return Nothing
            End If

            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "SELECT UserID, Username, PasswordHash, Salt, Role, Status, CreatedAt " &
                                    "FROM Users WHERE Username = @u AND Status = 'Active' LIMIT 1;"

                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@u", username.Trim())
                    Using reader As SqliteDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim hash As String = reader.GetString(2)
                            Dim salt As String = reader.GetString(3)

                            If PasswordHasher.VerifyPassword(password, hash, salt) Then
                                Return New User With {
                                    .UserID = reader.GetInt32(0),
                                    .Username = reader.GetString(1),
                                    .PasswordHash = hash,
                                    .Salt = salt,
                                    .Role = reader.GetString(4),
                                    .Status = reader.GetString(5),
                                    .CreatedAt = DateTime.Parse(reader.GetString(6))
                                }
                            End If
                        End If
                    End Using
                End Using
            End Using

            Return Nothing
        End Function

        Public Function GetAllUsers() As List(Of User)
            Dim list As New List(Of User)
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "SELECT UserID, Username, PasswordHash, Salt, Role, Status, CreatedAt FROM Users ORDER BY Username ASC;"
                Using cmd As New SqliteCommand(sql, conn)
                    Using reader As SqliteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            list.Add(New User With {
                                .UserID = reader.GetInt32(0),
                                .Username = reader.GetString(1),
                                .PasswordHash = reader.GetString(2),
                                .Salt = reader.GetString(3),
                                .Role = reader.GetString(4),
                                .Status = reader.GetString(5),
                                .CreatedAt = DateTime.Parse(reader.GetString(6))
                            })
                        End While
                    End Using
                End Using
            End Using
            Return list
        End Function

        Public Function CreateUser(username As String, password As String, role As String) As Boolean
            Dim hash As String = String.Empty
            Dim salt As String = String.Empty
            PasswordHasher.HashPassword(password, hash, salt)

            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "INSERT INTO Users (Username, PasswordHash, Salt, Role, Status) " &
                                    "VALUES (@u, @h, @s, @r, 'Active');"
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@u", username.Trim())
                    cmd.Parameters.AddWithValue("@h", hash)
                    cmd.Parameters.AddWithValue("@s", salt)
                    cmd.Parameters.AddWithValue("@r", role)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function

        Public Function UpdateUser(userId As Integer, newRole As String, newStatus As String, Optional newPassword As String = Nothing) As Boolean
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                If String.IsNullOrWhiteSpace(newPassword) Then
                    Dim sql As String = "UPDATE Users SET Role = @r, Status = @s WHERE UserID = @id;"
                    Using cmd As New SqliteCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@r", newRole)
                        cmd.Parameters.AddWithValue("@s", newStatus)
                        cmd.Parameters.AddWithValue("@id", userId)
                        Return cmd.ExecuteNonQuery() > 0
                    End Using
                Else
                    Dim hash As String = String.Empty
                    Dim salt As String = String.Empty
                    PasswordHasher.HashPassword(newPassword, hash, salt)

                    Dim sql As String = "UPDATE Users SET PasswordHash = @h, Salt = @salt, Role = @r, Status = @s WHERE UserID = @id;"
                    Using cmd As New SqliteCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@h", hash)
                        cmd.Parameters.AddWithValue("@salt", salt)
                        cmd.Parameters.AddWithValue("@r", newRole)
                        cmd.Parameters.AddWithValue("@s", newStatus)
                        cmd.Parameters.AddWithValue("@id", userId)
                        Return cmd.ExecuteNonQuery() > 0
                    End Using
                End If
            End Using
        End Function

        Public Function DeleteUser(userId As Integer) As Boolean
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "DELETE FROM Users WHERE UserID = @id;"
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", userId)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function
    End Class
End Namespace
