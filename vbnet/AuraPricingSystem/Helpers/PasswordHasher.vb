Imports System.Security.Cryptography
Imports System.Text

Namespace Helpers
    ''' <summary>
    ''' Cryptographic security helper for PBKDF2 password hashing.
    ''' Conforms to university security standards: Never stores plain-text passwords.
    ''' Uses HMAC-SHA256 with 100,000 iterations and a cryptographically generated 16-byte salt.
    ''' </summary>
    Public NotInheritable Class PasswordHasher
        Private Sub New()
        End Sub

        Private Const SaltSize As Integer = 16 ' 128-bit salt
        Private Const HashSize As Integer = 32 ' 256-bit subkey
        Private Const Iterations As Integer = 100000

        ''' <summary>
        ''' Generates a cryptographically random salt and PBKDF2 hash.
        ''' </summary>
        Public Shared Sub HashPassword(password As String, ByRef hash As String, ByRef salt As String)
            If String.IsNullOrEmpty(password) Then Throw New ArgumentNullException(NameOf(password))

            Dim saltBytes(SaltSize - 1) As Byte
            Using rng As RandomNumberGenerator = RandomNumberGenerator.Create()
                rng.GetBytes(saltBytes)
            End Using

            Using pbkdf2 As New Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256)
                Dim hashBytes As Byte() = pbkdf2.GetBytes(HashSize)
                hash = Convert.ToBase64String(hashBytes)
                salt = Convert.ToBase64String(saltBytes)
            End Using
        End Sub

        ''' <summary>
        ''' Verifies a plain-text password against a stored PBKDF2 hash and salt.
        ''' Uses constant-time comparison to prevent timing attacks.
        ''' </summary>
        Public Shared Function VerifyPassword(password As String, storedHash As String, storedSalt As String) As Boolean
            If String.IsNullOrEmpty(password) OrElse String.IsNullOrEmpty(storedHash) OrElse String.IsNullOrEmpty(storedSalt) Then
                Return False
            End If

            Try
                Dim saltBytes As Byte() = Convert.FromBase64String(storedSalt)
                Dim expectedHashBytes As Byte() = Convert.FromBase64String(storedHash)

                Using pbkdf2 As New Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256)
                    Dim actualHashBytes As Byte() = pbkdf2.GetBytes(HashSize)
                    Return CryptographicOperations.FixedTimeEquals(actualHashBytes, expectedHashBytes)
                End Using
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Class
End Namespace
