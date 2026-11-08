Imports AuraPricingSystem.Helpers
Imports AuraPricingSystem.Models
Imports AuraPricingSystem.Repositories
Imports AuraPricingSystem.Services

Namespace Forms
    ''' <summary>
    ''' Code-behind for Jobs & Bookings Management (Module 8).
    ''' Implements job scheduling strictly from Accepted quotations,
    ''' multi-staff assignment via the JobStaff bridge table, and status tracking.
    ''' </summary>
    Partial Public Class FrmJobs
        Private ReadOnly _jobRepo As New JobRepository()
        Private ReadOnly _quoteRepo As New QuotationRepository()
        Private ReadOnly _staffRepo As New StaffRepository()
        Private ReadOnly _settingsRepo As New SettingsRepository()
        Private ReadOnly _logRepo As New ActivityLogRepository()

        Private _acceptedQuotes As List(Of Quotation)
        Private _activeStaffList As List(Of StaffMember)
        Private _selectedJob As JobBooking = Nothing
        Private _initialQuote As Quotation = Nothing
        Private _isLoading As Boolean = True

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(preselectedQuote As Quotation)
            InitializeComponent()
            _initialQuote = preselectedQuote
        End Sub

        Private Sub FrmJobs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            _isLoading = True
            cboJobStatus.SelectedIndex = 0 ' "Scheduled"
            cboFilterStatus.SelectedIndex = 0 ' "All"

            LoadAcceptedQuotes()
            LoadStaffChecklist()
            LoadJobs()
            PrepareNewJob()

            If _initialQuote IsNot Nothing Then
                For i As Integer = 0 To cboAcceptedQuotes.Items.Count - 1
                    Dim q = TryCast(cboAcceptedQuotes.Items(i), Quotation)
                    If q IsNot Nothing AndAlso q.QuotationID = _initialQuote.QuotationID Then
                        cboAcceptedQuotes.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If

            _isLoading = False
        End Sub

        Private Sub LoadAcceptedQuotes()
            Try
                ' Load only quotations that are Accepted
                _acceptedQuotes = _quoteRepo.GetAllQuotations("Accepted", "")
                cboAcceptedQuotes.Items.Clear()
                For Each q In _acceptedQuotes
                    cboAcceptedQuotes.Items.Add(q)
                Next
                cboAcceptedQuotes.DisplayMember = "QuoteNo"
                cboAcceptedQuotes.ValueMember = "QuotationID"
                If cboAcceptedQuotes.Items.Count > 0 Then
                    cboAcceptedQuotes.SelectedIndex = 0
                End If
            Catch ex As Exception
                MessageBox.Show($"Error loading accepted quotations: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub LoadStaffChecklist()
            Try
                _activeStaffList = _staffRepo.GetActiveStaff()
                clbStaff.Items.Clear()
                For Each s In _activeStaffList
                    clbStaff.Items.Add(s, False)
                Next
                clbStaff.DisplayMember = "FullName"
                clbStaff.ValueMember = "StaffID"
            Catch ex As Exception
                MessageBox.Show($"Error loading staff: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub LoadJobs()
            Try
                Dim filter = If(cboFilterStatus.SelectedItem IsNot Nothing, cboFilterStatus.SelectedItem.ToString(), "All")
                Dim list = _jobRepo.GetAllJobs(filter)

                dgvJobs.Rows.Clear()
                For Each j In list
                    Dim staffCount = If(j.AssignedStaffList IsNot Nothing, j.AssignedStaffList.Count, 0)
                    Dim rowIndex = dgvJobs.Rows.Add(
                        j.JobNo,
                        j.QuoteNo,
                        j.ClientName,
                        j.JobDate.ToString("yyyy-MM-dd"),
                        j.Status,
                        $"{staffCount} staff",
                        CurrencyFormatter.FormatUgx(j.TotalAmount)
                    )
                    dgvJobs.Rows(rowIndex).Tag = j
                Next
            Catch ex As Exception
                MessageBox.Show($"Error loading jobs: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub PrepareNewJob()
            _selectedJob = Nothing
            Dim prefix = _settingsRepo.GetSettings().JobPrefix
            txtJobNo.Text = _jobRepo.GetNextJobNo(prefix)
            dtpJobDate.Value = DateTime.Today.AddDays(1)
            cboJobStatus.SelectedIndex = 0 ' "Scheduled"
            txtNotes.Clear()

            ' Uncheck all staff
            For i As Integer = 0 To clbStaff.Items.Count - 1
                clbStaff.SetItemChecked(i, False)
            Next

            btnSave.Enabled = True
            btnUpdate.Enabled = False
            btnCancelJob.Enabled = False
        End Sub

        Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
            PrepareNewJob()
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If cboAcceptedQuotes.SelectedItem Is Nothing Then
                MessageBox.Show("Please select an Accepted Quotation to create a job.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboAcceptedQuotes.Focus()
                Return
            End If

            Dim selectedQuote = DirectCast(cboAcceptedQuotes.SelectedItem, Quotation)
            Dim assignedIds As New List(Of Integer)()

            For i As Integer = 0 To clbStaff.CheckedItems.Count - 1
                Dim staffItem = TryCast(clbStaff.CheckedItems(i), StaffMember)
                If staffItem IsNot Nothing Then
                    assignedIds.Add(staffItem.StaffID)
                End If
            Next

            Dim job As New JobBooking With {
                .JobNo = txtJobNo.Text.Trim(),
                .QuotationID = selectedQuote.QuotationID,
                .JobDate = dtpJobDate.Value.Date,
                .Status = cboJobStatus.SelectedItem.ToString(),
                .Notes = txtNotes.Text.Trim()
            }

            Try
                If _jobRepo.CreateJobFromQuotation(job, assignedIds) Then
                    _logRepo.LogAction(AuthService.CurrentUser?.UserID, "CREATE_JOB", $"Scheduled job {job.JobNo} for quote {selectedQuote.QuoteNo} ({assignedIds.Count} staff assigned)")
                    MessageBox.Show(
                        $"Job '{job.JobNo}' scheduled successfully for {job.JobDate:yyyy-MM-dd}!" & vbCrLf &
                        $"Assigned staff: {assignedIds.Count} team members.",
                        "Job Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadJobs()
                    PrepareNewJob()
                Else
                    MessageBox.Show("Failed to save job record.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"Error creating job: {ex.Message}", "Job Constraint", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

        Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
            If _selectedJob Is Nothing Then
                MessageBox.Show("Please select a job from the table to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim assignedIds As New List(Of Integer)()
            For i As Integer = 0 To clbStaff.CheckedItems.Count - 1
                Dim staffItem = TryCast(clbStaff.CheckedItems(i), StaffMember)
                If staffItem IsNot Nothing Then
                    assignedIds.Add(staffItem.StaffID)
                End If
            Next

            _selectedJob.JobDate = dtpJobDate.Value.Date
            _selectedJob.Status = cboJobStatus.SelectedItem.ToString()
            _selectedJob.Notes = txtNotes.Text.Trim()

            Try
                If _jobRepo.UpdateJob(_selectedJob, assignedIds) Then
                    _logRepo.LogAction(AuthService.CurrentUser?.UserID, "UPDATE_JOB", $"Updated job {_selectedJob.JobNo} (Status: {_selectedJob.Status}, {assignedIds.Count} staff)")
                    MessageBox.Show($"Job '{_selectedJob.JobNo}' updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadJobs()
                    PrepareNewJob()
                Else
                    MessageBox.Show("Failed to update job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"Error updating job: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCancelJob_Click(sender As Object, e As EventArgs) Handles btnCancelJob.Click
            If _selectedJob Is Nothing Then
                MessageBox.Show("Please select a job from the table to cancel.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim result = MessageBox.Show($"Are you sure you want to cancel Job '{_selectedJob.JobNo}'?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                cboJobStatus.SelectedItem = "Cancelled"
                btnUpdate_Click(sender, e)
            End If
        End Sub

        Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
            PrepareNewJob()
        End Sub

        Private Sub cboFilterStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterStatus.SelectedIndexChanged
            If _isLoading Then Return
            LoadJobs()
        End Sub

        Private Sub dgvJobs_SelectionChanged(sender As Object, e As EventArgs) Handles dgvJobs.SelectionChanged
            If dgvJobs.SelectedRows.Count > 0 Then
                Dim row = dgvJobs.SelectedRows(0)
                If row.Tag IsNot Nothing AndAlso TypeOf row.Tag Is JobBooking Then
                    _selectedJob = DirectCast(row.Tag, JobBooking)
                    txtJobNo.Text = _selectedJob.JobNo
                    dtpJobDate.Value = _selectedJob.JobDate
                    cboJobStatus.SelectedItem = _selectedJob.Status
                    txtNotes.Text = _selectedJob.Notes

                    ' Ensure linked quotation appears in combo
                    Dim foundQuote = False
                    For i As Integer = 0 To cboAcceptedQuotes.Items.Count - 1
                        Dim q = TryCast(cboAcceptedQuotes.Items(i), Quotation)
                        If q IsNot Nothing AndAlso q.QuotationID = _selectedJob.QuotationID Then
                            cboAcceptedQuotes.SelectedIndex = i
                            foundQuote = True
                            Exit For
                        End If
                    Next

                    ' Check assigned staff
                    Dim assignedIds = If(_selectedJob.AssignedStaffList IsNot Nothing,
                        _selectedJob.AssignedStaffList.Select(Function(s) s.StaffID).ToHashSet(),
                        New HashSet(Of Integer)())

                    For i As Integer = 0 To clbStaff.Items.Count - 1
                        Dim s = TryCast(clbStaff.Items(i), StaffMember)
                        If s IsNot Nothing AndAlso assignedIds.Contains(s.StaffID) Then
                            clbStaff.SetItemChecked(i, True)
                        Else
                            clbStaff.SetItemChecked(i, False)
                        End If
                    Next

                    btnSave.Enabled = False
                    btnUpdate.Enabled = True
                    btnCancelJob.Enabled = True
                End If
            End If
        End Sub
    End Class
End Namespace
