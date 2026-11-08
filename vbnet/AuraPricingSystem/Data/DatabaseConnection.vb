Imports System.IO
Imports Microsoft.Data.Sqlite

Namespace Data
    ''' <summary>
    ''' Manages SQLite database connection strings and provides opened, configured connection instances.
    ''' Automatically enforces SQLite Foreign Key constraints via PRAGMA foreign_keys = ON.
    ''' </summary>
    Public Class DatabaseConnection
        Private Shared _customConnectionString As String = String.Empty

        ''' <summary>
        ''' Gets the default SQLite database path located in the Local AppData folder.
        ''' </summary>
        Public Shared Function GetDefaultDatabasePath() As String
            Dim appDataFolder As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AuraCleaningSolutions")
            If Not Directory.Exists(appDataFolder) Then
                Directory.CreateDirectory(appDataFolder)
            End If
            Return Path.Combine(appDataFolder, "aura_pricing.db")
        End Function

        ''' <summary>
        ''' Gets the connection string used by repositories.
        ''' </summary>
        Public Shared Function GetConnectionString() As String
            If Not String.IsNullOrEmpty(_customConnectionString) Then
                Return _customConnectionString
            End If
            Return $"Data Source={GetDefaultDatabasePath()};Cache=Shared;"
        End Function

        ''' <summary>
        ''' Allows overriding connection string (e.g., in-memory databases for unit testing).
        ''' </summary>
        Public Shared Sub SetCustomConnectionString(connString As String)
            _customConnectionString = connString
        End Sub

        ''' <summary>
        ''' Creates and opens a new SQLite connection with foreign keys enabled.
        ''' </summary>
        Public Shared Function CreateAndOpenConnection() As SqliteConnection
            Dim conn As New SqliteConnection(GetConnectionString())
            conn.Open()

            ' Strict requirement: Enforce SQLite Foreign Keys
            Using cmd As SqliteCommand = conn.CreateCommand()
                cmd.CommandText = "PRAGMA foreign_keys = ON;"
                cmd.ExecuteNonQuery()
            End Using

            Return conn
        End Function
    End Class
End Namespace
