Imports Microsoft.Data.Sqlite
Imports AuraPricingSystem.Data
Imports AuraPricingSystem.Models

Namespace Repositories
    ''' <summary>
    ''' Data repository for Client Management (Module 3).
    ''' </summary>
    Public Class ClientRepository
        Public Function GetAllClients() As List(Of Client)
            Dim list As New List(Of Client)
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "SELECT ClientID, ClientNo, FullName, Phone, Location, ClientType, CreatedAt " &
                                    "FROM Clients ORDER BY ClientID DESC;"
                Using cmd As New SqliteCommand(sql, conn)
                    Using reader As SqliteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            list.Add(MapClient(reader))
                        End While
                    End Using
                End Using
            End Using
            Return list
        End Function

        Public Function SearchClients(query As String) As List(Of Client)
            Dim list As New List(Of Client)
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "SELECT ClientID, ClientNo, FullName, Phone, Location, ClientType, CreatedAt " &
                                    "FROM Clients WHERE FullName LIKE @q OR ClientNo LIKE @q OR Location LIKE @q OR Phone LIKE @q " &
                                    "ORDER BY ClientID DESC;"
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@q", $"%{query}%")
                    Using reader As SqliteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            list.Add(MapClient(reader))
                        End While
                    End Using
                End Using
            End Using
            Return list
        End Function

        Public Function GetNextClientNo() As String
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "SELECT MAX(ClientID) FROM Clients;"
                Using cmd As New SqliteCommand(sql, conn)
                    Dim result As Object = cmd.ExecuteScalar()
                    Dim nextId As Integer = 1
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        nextId = Convert.ToInt32(result) + 1
                    End If
                    Return $"CL{nextId:D3}"
                End Using
            End Using
        End Function

        Public Function InsertClient(client As Client) As Boolean
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "INSERT INTO Clients (ClientNo, FullName, Phone, Location, ClientType) " &
                                    "VALUES (@no, @name, @phone, @loc, @type);"
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@no", client.ClientNo)
                    cmd.Parameters.AddWithValue("@name", client.FullName)
                    cmd.Parameters.AddWithValue("@phone", client.Phone)
                    cmd.Parameters.AddWithValue("@loc", client.Location)
                    cmd.Parameters.AddWithValue("@type", client.ClientType)
                    Dim rows As Integer = cmd.ExecuteNonQuery()
                    If rows > 0 Then
                        Using cmdId As New SqliteCommand("SELECT last_insert_rowid();", conn)
                            client.ClientID = Convert.ToInt32(cmdId.ExecuteScalar())
                        End Using
                        Return True
                    End If
                    Return False
                End Using
            End Using
        End Function

        Public Function UpdateClient(client As Client) As Boolean
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "UPDATE Clients SET FullName = @name, Phone = @phone, Location = @loc, ClientType = @type " &
                                    "WHERE ClientID = @id;"
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@name", client.FullName)
                    cmd.Parameters.AddWithValue("@phone", client.Phone)
                    cmd.Parameters.AddWithValue("@loc", client.Location)
                    cmd.Parameters.AddWithValue("@type", client.ClientType)
                    cmd.Parameters.AddWithValue("@id", client.ClientID)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function

        Public Function DeleteClient(clientId As Integer) As Boolean
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "DELETE FROM Clients WHERE ClientID = @id;"
                Using cmd As New SqliteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", clientId)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function

        Private Function MapClient(reader As SqliteDataReader) As Client
            Return New Client With {
                .ClientID = reader.GetInt32(0),
                .ClientNo = reader.GetString(1),
                .FullName = reader.GetString(2),
                .Phone = reader.GetString(3),
                .Location = reader.GetString(4),
                .ClientType = reader.GetString(5),
                .CreatedAt = DateTime.Parse(reader.GetString(6))
            }
        End Function
    End Class
End Namespace
