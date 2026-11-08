Imports Microsoft.Data.Sqlite
Imports AuraPricingSystem.Data
Imports AuraPricingSystem.Models

Namespace Repositories
    ''' <summary>
    ''' Data repository for Jobs & Bookings (Module 8).
    ''' Enforces that jobs can only be created from Accepted quotations.
    ''' </summary>
    Public Class JobRepository
        Public Function GetAllJobs(Optional statusFilter As String = "All") As List(Of JobBooking)
            Dim list As New List(Of JobBooking)
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "
                    SELECT j.JobID, j.JobNo, j.QuotationID, j.JobDate, j.Status, j.Notes, j.CreatedAt,
                           q.QuoteNo, c.FullName AS ClientName, s.ServiceName, q.TotalAmount
                    FROM Jobs j
                    INNER JOIN Quotations q ON j.QuotationID = q.QuotationID
                    INNER JOIN Clients c ON q.ClientID = c.ClientID
                    INNER JOIN Services s ON q.ServiceID = s.ServiceID
                    WHERE 1=1 "

                If Not String.IsNullOrEmpty(statusFilter) AndAlso Not statusFilter.Equals("All", StringComparison.OrdinalIgnoreCase) Then
                    sql &= " AND j.Status = @status "
                End If

                sql &= " ORDER BY j.JobID DESC;"

                Using cmd As New SqliteCommand(sql, conn)
                    If Not String.IsNullOrEmpty(statusFilter) AndAlso Not statusFilter.Equals("All", StringComparison.OrdinalIgnoreCase) Then
                        cmd.Parameters.AddWithValue("@status", statusFilter)
                    End If

                    Using reader As SqliteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim job As New JobBooking With {
                                .JobID = reader.GetInt32(0),
                                .JobNo = reader.GetString(1),
                                .QuotationID = reader.GetInt32(2),
                                .JobDate = DateTime.Parse(reader.GetString(3)),
                                .Status = reader.GetString(4),
                                .Notes = If(reader.IsDBNull(5), "", reader.GetString(5)),
                                .CreatedAt = DateTime.Parse(reader.GetString(6)),
                                .QuoteNo = reader.GetString(7),
                                .ClientName = reader.GetString(8),
                                .ServiceName = reader.GetString(9),
                                .TotalAmount = Convert.ToDecimal(reader.GetInt64(10))
                            }
                            list.Add(job)
                        End While
                    End Using
                End Using

                ' Populate assigned staff for each job
                For Each job In list
                    job.AssignedStaffList = GetAssignedStaffForJob(job.JobID, conn)
                Next
            End Using
            Return list
        End Function

        Public Function GetNextJobNo(prefix As String) As String
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Dim sql As String = "SELECT MAX(JobID) FROM Jobs;"
                Using cmd As New SqliteCommand(sql, conn)
                    Dim result As Object = cmd.ExecuteScalar()
                    Dim nextId As Integer = 1
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        nextId = Convert.ToInt32(result) + 1
                    End If
                    Return $"{prefix}{nextId:D4}"
                End Using
            End Using
        End Function

        Public Function CreateJobFromQuotation(job As JobBooking, assignedStaffIds As List(Of Integer)) As Boolean
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Using trans As SqliteTransaction = conn.BeginTransaction()
                    Try
                        ' Verify that the linked quotation exists and is Accepted
                        Dim verifySql As String = "SELECT Status FROM Quotations WHERE QuotationID = @qid;"
                        Using cmdVerify As New SqliteCommand(verifySql, conn, trans)
                            cmdVerify.Parameters.AddWithValue("@qid", job.QuotationID)
                            Dim quoteStatus As Object = cmdVerify.ExecuteScalar()
                            If quoteStatus Is Nothing OrElse Not quoteStatus.ToString().Equals("Accepted", StringComparison.OrdinalIgnoreCase) Then
                                Throw New InvalidOperationException("A job can only be scheduled for an Accepted quotation.")
                            End If
                        End Using

                        ' Insert Job record
                        Dim insertSql As String = "
                            INSERT INTO Jobs (JobNo, QuotationID, JobDate, Status, Notes)
                            VALUES (@no, @qid, @date, @status, @notes);"

                        Dim jobId As Integer
                        Using cmdJob As New SqliteCommand(insertSql, conn, trans)
                            cmdJob.Parameters.AddWithValue("@no", job.JobNo)
                            cmdJob.Parameters.AddWithValue("@qid", job.QuotationID)
                            cmdJob.Parameters.AddWithValue("@date", job.JobDate.ToString("yyyy-MM-dd"))
                            cmdJob.Parameters.AddWithValue("@status", job.Status)
                            cmdJob.Parameters.AddWithValue("@notes", job.Notes)
                            cmdJob.ExecuteNonQuery()
                        End Using

                        Using cmdId As New SqliteCommand("SELECT last_insert_rowid();", conn, trans)
                            jobId = Convert.ToInt32(cmdId.ExecuteScalar())
                            job.JobID = jobId
                        End Using

                        ' Insert assigned staff
                        If assignedStaffIds IsNot Nothing AndAlso assignedStaffIds.Count > 0 Then
                            Dim assignSql As String = "INSERT INTO JobStaff (JobID, StaffID) VALUES (@jid, @sid);"
                            For Each staffId In assignedStaffIds
                                Using cmdAssign As New SqliteCommand(assignSql, conn, trans)
                                    cmdAssign.Parameters.AddWithValue("@jid", jobId)
                                    cmdAssign.Parameters.AddWithValue("@sid", staffId)
                                    cmdAssign.ExecuteNonQuery()
                                End Using
                            Next
                        End If

                        trans.Commit()
                        Return True
                    Catch ex As Exception
                        trans.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        End Function

        Public Function UpdateJob(job As JobBooking, assignedStaffIds As List(Of Integer)) As Boolean
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Using trans As SqliteTransaction = conn.BeginTransaction()
                    Try
                        Dim sql As String = "UPDATE Jobs SET JobDate = @date, Status = @status, Notes = @notes WHERE JobID = @id;"
                        Using cmd As New SqliteCommand(sql, conn, trans)
                            cmd.Parameters.AddWithValue("@date", job.JobDate.ToString("yyyy-MM-dd"))
                            cmd.Parameters.AddWithValue("@status", job.Status)
                            cmd.Parameters.AddWithValue("@notes", job.Notes)
                            cmd.Parameters.AddWithValue("@id", job.JobID)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' Replace staff assignments
                        Using cmdDel As New SqliteCommand("DELETE FROM JobStaff WHERE JobID = @jid;", conn, trans)
                            cmdDel.Parameters.AddWithValue("@jid", job.JobID)
                            cmdDel.ExecuteNonQuery()
                        End Using

                        If assignedStaffIds IsNot Nothing AndAlso assignedStaffIds.Count > 0 Then
                            Dim assignSql As String = "INSERT INTO JobStaff (JobID, StaffID) VALUES (@jid, @sid);"
                            For Each staffId In assignedStaffIds
                                Using cmdAssign As New SqliteCommand(assignSql, conn, trans)
                                    cmdAssign.Parameters.AddWithValue("@jid", job.JobID)
                                    cmdAssign.Parameters.AddWithValue("@sid", staffId)
                                    cmdAssign.ExecuteNonQuery()
                                End Using
                            Next
                        End If

                        trans.Commit()
                        Return True
                    Catch ex As Exception
                        trans.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        End Function

        Private Function GetAssignedStaffForJob(jobId As Integer, conn As SqliteConnection) As List(Of StaffMember)
            Dim staffList As New List(Of StaffMember)
            Dim sql As String = "
                SELECT s.StaffID, s.StaffNo, s.FullName, s.Phone, s.Role, s.DailyRate, s.Status, s.CreatedAt
                FROM Staff s
                INNER JOIN JobStaff js ON s.StaffID = js.StaffID
                WHERE js.JobID = @jid;"

            Using cmd As New SqliteCommand(sql, conn)
                cmd.Parameters.AddWithValue("@jid", jobId)
                Using reader As SqliteDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        staffList.Add(New StaffMember With {
                            .StaffID = reader.GetInt32(0),
                            .StaffNo = reader.GetString(1),
                            .FullName = reader.GetString(2),
                            .Phone = reader.GetString(3),
                            .Role = reader.GetString(4),
                            .DailyRate = Convert.ToDecimal(reader.GetInt64(5)),
                            .Status = reader.GetString(6),
                            .CreatedAt = DateTime.Parse(reader.GetString(7))
                        })
                    End While
                End Using
            End Using
            Return staffList
        End Function
    End Class
End Namespace
