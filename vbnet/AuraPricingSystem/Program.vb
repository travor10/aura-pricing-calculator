Imports System.Windows.Forms
Imports AuraPricingSystem.Data
Imports AuraPricingSystem.Forms

Namespace AuraPricingSystem
    ''' <summary>
    ''' APPLICATION ENTRY POINT
    ''' Handles startup, database auto-initialization, unhandled exception catching,
    ''' and boots the secure Login workflow before displaying MainForm.
    ''' </summary>
    Public Module Program
        <STAThread>
        Public Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)

            ' Global Exception Handling to prevent unhandled desktop crashes
            AddHandler Application.ThreadException, AddressOf OnThreadException
            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf OnUnhandledException

            Try
                ' 1. Automatically initialize SQLite database schema and seeds on first run
                DatabaseInitializer.InitializeDatabase()
            Catch ex As Exception
                MessageBox.Show(
                    $"Fatal Database Initialization Error:{Environment.NewLine}{ex.Message}",
                    "Startup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                )
                Return
            End Try

            ' 2. Launch Login Screen
            Using loginForm As New FrmLogin()
                Dim loginResult As DialogResult = loginForm.ShowDialog()

                ' 3. If authenticated, open MainForm
                If loginResult = DialogResult.OK Then
                    Application.Run(New FrmMain())
                End If
            End Using
        End Sub

        Private Sub OnThreadException(sender As Object, e As Threading.ThreadExceptionEventArgs)
            MessageBox.Show(
                $"An unexpected application error occurred:{Environment.NewLine}{e.Exception.Message}",
                "System Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Sub

        Private Sub OnUnhandledException(sender As Object, e As UnhandledExceptionEventArgs)
            Dim ex As Exception = TryCast(e.ExceptionObject, Exception)
            MessageBox.Show(
                $"A critical system error occurred:{Environment.NewLine}{If(ex IsNot Nothing, ex.Message, "Unknown error")}",
                "Critical Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Stop
            )
        End Sub
    End Module
End Namespace
