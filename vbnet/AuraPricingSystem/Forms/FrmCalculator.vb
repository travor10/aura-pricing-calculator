Imports AuraPricingSystem.Helpers
Imports AuraPricingSystem.Models
Imports AuraPricingSystem.Repositories
Imports AuraPricingSystem.Services

Namespace Forms
    ''' <summary>
    ''' Code-behind for Pricing Calculator Engine (Module 6).
    ''' Implements the 3-panel layout matching the Excel workbook and UI mockups.
    ''' All financial math delegates to PricingEngine.
    ''' </summary>
    Partial Public Class FrmCalculator
        Private ReadOnly _clientRepo As New ClientRepository()
        Private ReadOnly _serviceRepo As New ServiceRepository()
        Private ReadOnly _settingsRepo As New SettingsRepository()
        Private ReadOnly _quoteRepo As New QuotationRepository()
        Private ReadOnly _logRepo As New ActivityLogRepository()

        Private _clients As List(Of Client)
        Private _services As List(Of ServiceItem)
        Private _marginGuides As List(Of MarginGuideItem)
        Private _systemSettings As SystemSettings
        Private _currentCalc As PricingCalculation

        Private _isLoading As Boolean = True

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub FrmCalculator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            _isLoading = True
            LoadCatalogData()
            LoadBukiikaSample()
            _isLoading = False
            Recalculate()
        End Sub

        Private Sub LoadCatalogData()
            Try
                ' 1. Load System Settings
                _systemSettings = _settingsRepo.GetSettings()

                ' 2. Load Clients
                _clients = _clientRepo.GetAllClients()
                cboClient.DataSource = _clients
                cboClient.DisplayMember = "FullName"
                cboClient.ValueMember = "ClientID"

                ' 3. Load Services
                _services = _serviceRepo.GetAllServices()
                cboService.DataSource = _services
                cboService.DisplayMember = "ServiceName"
                cboService.ValueMember = "ServiceID"

                ' 4. Load Margin Guides
                _marginGuides = _settingsRepo.GetAllMarginGuides()
                cboJobType.Items.Clear()
                For Each g In _marginGuides
                    cboJobType.Items.Add(g.JobType)
                Next
                If cboJobType.Items.Count > 2 Then
                    cboJobType.SelectedIndex = 2 ' Default to Residential - Post-Construction
                ElseIf cboJobType.Items.Count > 0 Then
                    cboJobType.SelectedIndex = 0
                End If

            Catch ex As Exception
                MessageBox.Show($"Error loading catalog data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub LoadBukiikaSample()
            ' Find Bukiika client if exists
            Dim bukiikaClient = _clients?.FirstOrDefault(Function(c) c.FullName.Contains("Bukiika"))
            If bukiikaClient IsNot Nothing Then
                cboClient.SelectedValue = bukiikaClient.ClientID
            End If

            ' Find Post-Construction Service
            Dim pcService = _services?.FirstOrDefault(Function(s) s.ServiceCode.Contains("PC") OrElse s.ServiceName.Contains("Post-Construction"))
            If pcService IsNot Nothing Then
                cboService.SelectedValue = pcService.ServiceID
            End If

            txtJobName.Text = "Bukiika"

            ' Select Residential - Post-Construction
            For i As Integer = 0 To cboJobType.Items.Count - 1
                If cboJobType.Items(i).ToString().Contains("Post-Construction") Then
                    cboJobType.SelectedIndex = i
                    Exit For
                End If
            Next

            numTeamMembers.Value = 7
            numDayRate.Value = 30000
            numDays.Value = 2.0D
            numSupplies.Value = 100000
            numTransport.Value = 200000
            numEquipmentWear.Value = 15000
            numMonthlyOverhead.Value = 100000
            numAvgJobs.Value = 8
            numTargetMargin.Value = 35.0D
            numActualQuote.Value = 1200000
        End Sub

        Private Sub Recalculate()
            If _isLoading Then Return

            Try
                Dim teamMembers As Integer = Convert.ToInt32(numTeamMembers.Value)
                Dim dayRate As Decimal = numDayRate.Value
                Dim days As Decimal = numDays.Value
                Dim supplies As Decimal = numSupplies.Value
                Dim transport As Decimal = numTransport.Value
                Dim equipmentWear As Decimal = numEquipmentWear.Value
                Dim monthlyOverhead As Decimal = numMonthlyOverhead.Value
                Dim avgJobs As Integer = Convert.ToInt32(numAvgJobs.Value)
                Dim targetMargin As Decimal = numTargetMargin.Value / 100.0D
                Dim actualQuote As Decimal = numActualQuote.Value

                ' Central Pricing Engine calculation
                _currentCalc = PricingEngine.Calculate(
                    teamMembers,
                    dayRate,
                    days,
                    supplies,
                    transport,
                    equipmentWear,
                    monthlyOverhead,
                    avgJobs,
                    targetMargin,
                    actualQuote
                )

                ' Update Panel 2: Cost Breakdown
                lblLaborCostVal.Text = CurrencyFormatter.FormatUgx(_currentCalc.LaborCost)
                lblSuppliesVal.Text = CurrencyFormatter.FormatUgx(_currentCalc.SuppliesCost)
                lblTransportVal.Text = CurrencyFormatter.FormatUgx(_currentCalc.TransportCost)
                lblEquipmentVal.Text = CurrencyFormatter.FormatUgx(_currentCalc.EquipmentWear)
                lblOverheadVal.Text = CurrencyFormatter.FormatUgx(_currentCalc.OverheadAllocation)
                lblTotalCostVal.Text = CurrencyFormatter.FormatUgx(_currentCalc.TotalCost)

                ' Update Suggested Price
                lblSuggestedPriceTitle.Text = $"SUGGESTED PRICE ({(targetMargin * 100D):0.#}%):"
                lblSuggestedPriceVal.Text = CurrencyFormatter.FormatUgx(_currentCalc.SuggestedPrice)
                lblProfitAtSuggested.Text = $"Profit at Suggested Price: {CurrencyFormatter.FormatUgx(_currentCalc.ProfitAtSuggested)}"

                Dim laborPctText = $"{(_currentCalc.LaborPercent * 100D):0.0}%"
                lblLaborPercent.Text = $"Labor % of Suggested Price: {laborPctText} (Aim 45%–60%)"

                ' Labor % Reference Warning
                Dim isLaborOutside = _currentCalc.LaborPercent < 0.45D OrElse _currentCalc.LaborPercent > 0.60D
                lblLaborWarning.Visible = isLaborOutside

                ' Update Panel 3: Actual Quote
                lblActualProfit.Text = $"Actual Profit: {CurrencyFormatter.FormatUgx(_currentCalc.ActualProfit)}"
                lblActualMargin.Text = $"Actual Gross Margin %: {(_currentCalc.ActualMargin * 100D):0.0}%"

                ' Update Verdict Badge
                lblVerdictValue.Text = _currentCalc.Verdict
                ApplyVerdictColor(_currentCalc.Verdict)

            Catch ex As Exception
                ' Keep UI resilient
            End Try
        End Sub

        Private Sub ApplyVerdictColor(verdict As String)
            If verdict.Contains("HEALTHY") Then
                pnlVerdict.BackColor = Color.FromArgb(209, 250, 229) ' Emerald 100
                lblVerdictValue.ForeColor = Color.FromArgb(6, 95, 70) ' Emerald 800
                lblVerdictTitle.ForeColor = Color.FromArgb(6, 95, 70)
            ElseIf verdict.Contains("THIN") Then
                pnlVerdict.BackColor = Color.FromArgb(254, 243, 199) ' Amber 100
                lblVerdictValue.ForeColor = Color.FromArgb(146, 64, 14) ' Amber 800
                lblVerdictTitle.ForeColor = Color.FromArgb(146, 64, 14)
            ElseIf verdict.Contains("SURVIVAL") Then
                pnlVerdict.BackColor = Color.FromArgb(254, 226, 226) ' Red 100
                lblVerdictValue.ForeColor = Color.FromArgb(153, 27, 27) ' Red 800
                lblVerdictTitle.ForeColor = Color.FromArgb(153, 27, 27)
            Else
                pnlVerdict.BackColor = Color.FromArgb(219, 234, 254) ' Blue 100
                lblVerdictValue.ForeColor = Color.FromArgb(30, 64, 175) ' Blue 800
                lblVerdictTitle.ForeColor = Color.FromArgb(30, 64, 175)
            End If
        End Sub

        ' Dynamic Event Handlers for Real-Time Recalculation
        Private Sub InputChanged(sender As Object, e As EventArgs) Handles _
            numTeamMembers.ValueChanged, numDayRate.ValueChanged, numDays.ValueChanged, _
            numSupplies.ValueChanged, numTransport.ValueChanged, numEquipmentWear.ValueChanged, _
            numMonthlyOverhead.ValueChanged, numAvgJobs.ValueChanged, numTargetMargin.ValueChanged, _
            numActualQuote.ValueChanged
            Recalculate()
        End Sub

        Private Sub cboJobType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboJobType.SelectedIndexChanged
            If cboJobType.SelectedItem IsNot Nothing Then
                Dim selectedType = cboJobType.SelectedItem.ToString()
                Dim guide = _marginGuides?.FirstOrDefault(Function(g) g.JobType = selectedType)
                If guide IsNot Nothing Then
                    lblGuideBenchmark.Text = $"Recommended Margin Benchmark: {guide.DisplayRange}"
                Else
                    lblGuideBenchmark.Text = "Recommended Margin Benchmark: 10%–20%"
                End If
            End If
            Recalculate()
        End Sub

        Private Sub cboService_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboService.SelectedIndexChanged
            If _isLoading Then Return
            If cboService.SelectedItem IsNot Nothing AndAlso TypeOf cboService.SelectedItem Is ServiceItem Then
                Dim svc = DirectCast(cboService.SelectedItem, ServiceItem)
                numDayRate.Value = svc.LaborRate
            End If
        End Sub

        Private Sub btnResetBukiika_Click(sender As Object, e As EventArgs) Handles btnResetBukiika.Click
            _isLoading = True
            LoadBukiikaSample()
            _isLoading = False
            Recalculate()
            MessageBox.Show("Calculator loaded with Bukiika reference sample (Residential Post-Construction).", "Sample Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
            _isLoading = True
            txtJobName.Clear()
            numTeamMembers.Value = 1
            numDayRate.Value = 30000
            numDays.Value = 1
            numSupplies.Value = 0
            numTransport.Value = 0
            numEquipmentWear.Value = 0
            numMonthlyOverhead.Value = 100000
            numAvgJobs.Value = 8
            numTargetMargin.Value = If(_systemSettings IsNot Nothing, _systemSettings.DefaultMargin * 100D, 35D)
            numActualQuote.Value = 0
            _isLoading = False
            Recalculate()
        End Sub

        Private Sub btnSaveQuote_Click(sender As Object, e As EventArgs) Handles btnSaveQuote.Click
            If cboClient.SelectedValue Is Nothing Then
                MessageBox.Show("Please select a client for this quotation.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboClient.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtJobName.Text) Then
                MessageBox.Show("Please provide a job name or description.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtJobName.Focus()
                Return
            End If

            If numActualQuote.Value <= 0 Then
                Dim dialogRes = MessageBox.Show(
                    "Actual Quote Price is 0. Do you want to set it to Suggested Price (" & CurrencyFormatter.FormatUgx(_currentCalc.SuggestedPrice) & ")?",
                    "Quotation Price", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dialogRes = DialogResult.Yes Then
                    numActualQuote.Value = _currentCalc.SuggestedPrice
                    Recalculate()
                Else
                    Return
                End If
            End If

            Try
                Dim prefix = If(_systemSettings IsNot Nothing, _systemSettings.QuotePrefix, "QUO-")
                Dim quoteNo = _quoteRepo.GetNextQuoteNo(prefix)
                Dim clientId = Convert.ToInt32(cboClient.SelectedValue)
                Dim serviceId = If(cboService.SelectedValue IsNot Nothing, Convert.ToInt32(cboService.SelectedValue), 1)

                Dim quote As New Quotation With {
                    .QuoteNo = quoteNo,
                    .ClientID = clientId,
                    .ServiceID = serviceId,
                    .JobName = txtJobName.Text.Trim(),
                    .JobType = cboJobType.SelectedItem.ToString(),
                    .QuoteDate = DateTime.Now,
                    .TotalAmount = numActualQuote.Value,
                    .Status = "Draft",
                    .CreatedByUserID = If(AuthService.CurrentUser IsNot Nothing, AuthService.CurrentUser.UserID, 1)
                }

                If _quoteRepo.SaveQuotationWithCalculation(quote, _currentCalc) Then
                    _logRepo.LogAction(AuthService.CurrentUser?.UserID, "CREATE_QUOTE", $"Created quote {quote.QuoteNo} for {quote.JobName} (UGX {quote.TotalAmount:N0})")
                    MessageBox.Show(
                        $"Quotation '{quote.QuoteNo}' saved successfully in Draft status!" & vbCrLf &
                        $"Total Amount: {CurrencyFormatter.FormatUgx(quote.TotalAmount)}" & vbCrLf &
                        $"Calculation snapshot permanently locked into database.",
                        "Quotation Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Failed to save quotation.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                MessageBox.Show($"Error saving quotation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace
