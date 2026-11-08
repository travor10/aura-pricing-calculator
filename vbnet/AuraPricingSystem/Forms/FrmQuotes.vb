Imports AuraPricingSystem.Helpers
Imports AuraPricingSystem.Models
Imports AuraPricingSystem.Repositories
Imports AuraPricingSystem.Services

Namespace Forms
    ''' <summary>
    ''' Code-behind for Quotations Workflow (Module 7).
    ''' Manages the complete lifecycle of quotes (Draft ➔ Sent ➔ Accepted / Rejected),
    ''' displays locked calculation snapshots, and transitions accepted quotes to jobs.
    ''' </summary>
    Partial Public Class FrmQuotes
        Private ReadOnly _quoteRepo As New QuotationRepository()
        Private ReadOnly _logRepo As New ActivityLogRepository()
        Private _selectedQuote As Quotation = Nothing
        Private _isLoading As Boolean = True

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub FrmQuotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            _isLoading = True
            cboStatusFilter.SelectedIndex = 0 ' "All"
            _isLoading = False
            LoadQuotations()
        End Sub

        Private Sub LoadQuotations()
            Try
                Dim statusFilter = If(cboStatusFilter.SelectedItem IsNot Nothing, cboStatusFilter.SelectedItem.ToString(), "All")
                Dim search = txtSearch.Text.Trim()

                Dim list = _quoteRepo.GetAllQuotations(statusFilter, search)
                dgvQuotes.Rows.Clear()

                For Each q In list
                    Dim rowIndex = dgvQuotes.Rows.Add(
                        q.QuoteNo,
                        q.ClientName,
                        q.JobName,
                        q.JobType,
                        q.QuoteDate.ToString("yyyy-MM-dd"),
                        CurrencyFormatter.FormatUgx(q.TotalAmount),
                        q.Status,
                        q.CreatedByUsername
                    )
                    dgvQuotes.Rows(rowIndex).Tag = q
                Next

                If dgvQuotes.Rows.Count > 0 Then
                    dgvQuotes.Rows(0).Selected = True
                    SelectQuote(DirectCast(dgvQuotes.Rows(0).Tag, Quotation))
                Else
                    ClearDetails()
                End If

            Catch ex As Exception
                MessageBox.Show($"Error loading quotations: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub SelectQuote(quoteHeader As Quotation)
            If quoteHeader Is Nothing Then Return

            ' Fetch complete quote entity including locked PricingCalculation snapshot
            _selectedQuote = _quoteRepo.GetQuotationWithCalculation(quoteHeader.QuotationID)
            If _selectedQuote Is Nothing Then Return

            ' Update Header Display
            lblSelectedQuoteNo.Text = $"Quote: {_selectedQuote.QuoteNo}"
            lblSelectedClient.Text = $"Client: {_selectedQuote.ClientName}"
            lblSelectedAmount.Text = $"Amount: {CurrencyFormatter.FormatUgx(_selectedQuote.TotalAmount)}"
            lblSelectedStatus.Text = $"Status: {_selectedQuote.Status.ToUpperInvariant()}"
            ApplyStatusBadgeColor(_selectedQuote.Status)

            ' Update Snapshot Display
            If _selectedQuote.Calculation IsNot Nothing Then
                Dim c = _selectedQuote.Calculation
                lblSnapTeamDays.Text = $"Team: {c.TeamMembers} staff  |  {c.Days} days @ {CurrencyFormatter.FormatUgx(c.DayRate)}"
                lblSnapTotalCost.Text = $"Total Job Cost: {CurrencyFormatter.FormatUgx(c.TotalCost)}"
                lblSnapSuggested.Text = $"Suggested Price: {CurrencyFormatter.FormatUgx(c.SuggestedPrice)}"
                lblSnapProfit.Text = $"Actual Profit: {CurrencyFormatter.FormatUgx(c.ActualProfit)}"
                lblSnapMargin.Text = $"Actual Gross Margin %: {(c.ActualMargin * 100D):0.0}%"
                lblSnapVerdict.Text = $"Verdict: {c.Verdict}"
            Else
                lblSnapTeamDays.Text = "No snapshot available"
                lblSnapTotalCost.Text = ""
                lblSnapSuggested.Text = ""
                lblSnapProfit.Text = ""
                lblSnapMargin.Text = ""
                lblSnapVerdict.Text = ""
            End If

            ' Enable / Disable Workflow Actions
            btnCreateJob.Enabled = _selectedQuote.Status.Equals("Accepted", StringComparison.OrdinalIgnoreCase)
        End Sub

        Private Sub ApplyStatusBadgeColor(status As String)
            Select Case status.ToUpperInvariant()
                Case "ACCEPTED"
                    lblSelectedStatus.ForeColor = Color.FromArgb(36, 122, 61) ' Emerald
                Case "REJECTED"
                    lblSelectedStatus.ForeColor = Color.FromArgb(192, 48, 47) ' Red
                Case "SENT"
                    lblSelectedStatus.ForeColor = Color.FromArgb(12, 75, 136) ' Blue
                Case Else
                    lblSelectedStatus.ForeColor = Color.FromArgb(85, 110, 130) ' Gray / Draft
            End Select
        End Sub

        Private Sub ClearDetails()
            _selectedQuote = Nothing
            lblSelectedQuoteNo.Text = "No quotation selected"
            lblSelectedClient.Text = ""
            lblSelectedAmount.Text = ""
            lblSelectedStatus.Text = ""
            lblSnapTeamDays.Text = ""
            lblSnapTotalCost.Text = ""
            lblSnapSuggested.Text = ""
            lblSnapProfit.Text = ""
            lblSnapMargin.Text = ""
            lblSnapVerdict.Text = ""
            btnCreateJob.Enabled = False
        End Sub

        Private Sub dgvQuotes_SelectionChanged(sender As Object, e As EventArgs) Handles dgvQuotes.SelectionChanged
            If dgvQuotes.SelectedRows.Count > 0 Then
                Dim row = dgvQuotes.SelectedRows(0)
                If row.Tag IsNot Nothing AndAlso TypeOf row.Tag Is Quotation Then
                    SelectQuote(DirectCast(row.Tag, Quotation))
                End If
            End If
        End Sub

        Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged
            If _isLoading Then Return
            LoadQuotations()
        End Sub

        Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
            LoadQuotations()
        End Sub

        Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
            LoadQuotations()
        End Sub

        Private Sub btnMarkSent_Click(sender As Object, e As EventArgs) Handles btnMarkSent.Click
            ChangeSelectedStatus("Sent", "Marked quotation as Sent to client")
        End Sub

        Private Sub btnMarkAccepted_Click(sender As Object, e As EventArgs) Handles btnMarkAccepted.Click
            ChangeSelectedStatus("Accepted", "Client accepted quotation")
        End Sub

        Private Sub btnMarkRejected_Click(sender As Object, e As EventArgs) Handles btnMarkRejected.Click
            ChangeSelectedStatus("Rejected", "Client declined/rejected quotation")
        End Sub

        Private Sub ChangeSelectedStatus(newStatus As String, logReason As String)
            If _selectedQuote Is Nothing Then
                MessageBox.Show("Please select a quotation first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If _selectedQuote.Status.Equals(newStatus, StringComparison.OrdinalIgnoreCase) Then
                MessageBox.Show($"Quotation is already in '{newStatus}' status.", "No Change", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If _quoteRepo.UpdateStatus(_selectedQuote.QuotationID, newStatus) Then
                _logRepo.LogAction(AuthService.CurrentUser?.UserID, "UPDATE_QUOTE_STATUS", $"{logReason}: {_selectedQuote.QuoteNo} ➔ {newStatus}")
                _selectedQuote.Status = newStatus
                SelectQuote(_selectedQuote)

                ' Refresh row in grid
                For Each row As DataGridViewRow In dgvQuotes.Rows
                    If row.Tag IsNot Nothing AndAlso DirectCast(row.Tag, Quotation).QuotationID = _selectedQuote.QuotationID Then
                        row.Cells(colStatus.Index).Value = newStatus
                        DirectCast(row.Tag, Quotation).Status = newStatus
                        Exit For
                    End If
                Next

                MessageBox.Show($"Quotation '{_selectedQuote.QuoteNo}' status changed to '{newStatus}'.", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to update quotation status.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btnCreateJob_Click(sender As Object, e As EventArgs) Handles btnCreateJob.Click
            If _selectedQuote Is Nothing OrElse Not _selectedQuote.Status.Equals("Accepted", StringComparison.OrdinalIgnoreCase) Then
                MessageBox.Show("Jobs can only be scheduled from 'Accepted' quotations.", "Validation Guard", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Open FrmJobs directly or via FrmMain
            Dim parentMain = TryCast(Me.ParentForm, FrmMain)
            If parentMain IsNot Nothing Then
                Dim frmJob As New FrmJobs(_selectedQuote)
                parentMain.NavigateTo(Nothing, frmJob)
            Else
                Dim frmJob As New FrmJobs(_selectedQuote)
                frmJob.ShowDialog()
                LoadQuotations()
            End If
        End Sub
    End Class
End Namespace
