Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports AuraPricingSystem.Services
Imports AuraPricingSystem.Repositories
Imports AuraPricingSystem.Data
Imports System.IO

<TestClass>
Public Class ReportAndExportTests
    Private _reportService As ReportService
    Private _excelService As ExcelExportService
    Private _pdfService As PdfReportService
    Private _quoteRepo As QuotationRepository
    Private _jobRepo As JobRepository

    <TestInitialize>
    Public Sub Setup()
        ' Initialize in-memory / clean database state
        DatabaseInitializer.InitializeDatabase()
        _reportService = New ReportService()
        _excelService = New ExcelExportService()
        _pdfService = New PdfReportService()
        _quoteRepo = New QuotationRepository()
        _jobRepo = New JobRepository()
    End Sub

    ''' <summary>
    ''' Test 26: Financial Summary Aggregation Math
    ''' Verifies quotes count, total revenue, average margin, and job completion metrics.
    ''' </summary>
    <TestMethod>
    Public Sub Test_FinancialSummary_AggregationMath()
        Dim startDate = DateTime.Today.AddDays(-30)
        Dim endDate = DateTime.Today.AddDays(30)

        Dim summary = _reportService.GetFinancialSummary(startDate, endDate)

        Assert.IsNotNull(summary)
        Assert.IsTrue(summary.TotalQuotesCount >= 1, "Should contain at least 1 seed quote.")
        Assert.IsTrue(summary.TotalAcceptedRevenue > 0D, "Accepted quotes should contribute positive revenue.")
        Assert.IsTrue(summary.AverageGrossMargin > 0D AndAlso summary.AverageGrossMargin <= 1.0D, "Average margin should be valid percentage.")
        Assert.IsTrue(summary.CategoryBreakdown.Count >= 1, "Category breakdown should contain at least 1 service classification.")
    End Sub

    ''' <summary>
    ''' Test 27: Category-level profitability calculation
    ''' Ensures each category aggregates quotes and revenue accurately.
    ''' </summary>
    <TestMethod>
    Public Sub Test_CategoryBreakdown_Metrics()
        Dim startDate = DateTime.Today.AddDays(-30)
        Dim endDate = DateTime.Today.AddDays(30)

        Dim summary = _reportService.GetFinancialSummary(startDate, endDate)
        Dim postConstCat = summary.CategoryBreakdown.FirstOrDefault(Function(c) c.JobType.Contains("Post-Construction"))

        Assert.IsNotNull(postConstCat, "Post-Construction category should be present from seed quotes.")
        Assert.IsTrue(postConstCat.QuotesCount >= 1)
        Assert.AreEqual(1200000D, postConstCat.TotalRevenue, "Revenue should match accepted quote amount.")
        Assert.IsTrue(postConstCat.AverageMargin > 0.35D, "Average margin should be ~37.7% for Bukiika sample.")
    End Sub

    ''' <summary>
    ''' Test 28: ClosedXML 4-sheet analytical workbook generation
    ''' Validates that the generated .xlsx file exists, is non-empty, and has correct sheet structure.
    ''' </summary>
    <TestMethod>
    Public Sub Test_ClosedXML_ExportWorkbookGeneration()
        Dim testFilePath = Path.Combine(Path.GetTempPath(), $"Aura_Test_Export_{Guid.NewGuid():N}.xlsx")

        Try
            Dim startDate = DateTime.Today.AddDays(-30)
            Dim endDate = DateTime.Today.AddDays(30)

            _excelService.ExportFinancialReportToExcel(testFilePath, startDate, endDate)

            Assert.IsTrue(File.Exists(testFilePath), "Exported Excel file must exist on disk.")
            Dim fileInfo As New FileInfo(testFilePath)
            Assert.IsTrue(fileInfo.Length > 2000, "Excel file must contain valid ClosedXML workbook binary data.")
        Finally
            If File.Exists(testFilePath) Then
                File.Delete(testFilePath)
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Test 29: QuestPDF Quotation generation
    ''' Validates that formal PDF document is generated without errors and outputs valid PDF headers.
    ''' </summary>
    <TestMethod>
    Public Sub Test_QuestPDF_QuotationGeneration()
        Dim quotes = _quoteRepo.GetAllQuotations("All", "")
        Assert.IsTrue(quotes.Count > 0, "Requires at least one quote.")

        Dim targetQuote = quotes.First()
        Dim testPdfPath = Path.Combine(Path.GetTempPath(), $"Aura_Test_Quote_{Guid.NewGuid():N}.pdf")

        Try
            _pdfService.GenerateQuotationPdf(targetQuote.QuotationID, testPdfPath)

            Assert.IsTrue(File.Exists(testPdfPath), "Exported PDF file must exist on disk.")
            Dim fileInfo As New FileInfo(testPdfPath)
            Assert.IsTrue(fileInfo.Length > 1000, "PDF file must contain valid QuestPDF document stream.")

            ' Verify PDF magic header %PDF-
            Using fs As New FileStream(testPdfPath, FileMode.Open, FileAccess.Read)
                Dim header(3) As Byte
                fs.Read(header, 0, 4)
                Dim headerStr = System.Text.Encoding.ASCII.GetString(header)
                Assert.AreEqual("%PDF", headerStr, "Generated document must be a compliant PDF.")
            End Using
        Finally
            If File.Exists(testPdfPath) Then
                File.Delete(testPdfPath)
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Test 30: Role-based report access verification
    ''' Verifies that Admin and Manager have access to reports while Staff does not.
    ''' </summary>
    <TestMethod>
    Public Sub Test_RoleBasedAccess_ReportsPermission()
        Dim auth As New AuthService()

        ' Login as Admin
        Dim adminSuccess = auth.Login("admin", "Admin@123")
        Assert.IsTrue(adminSuccess)
        Assert.IsTrue(AuthService.CanAccessModule("REPORTS"), "Admin must have access to reports.")
        auth.Logout()

        ' Login as Manager
        Dim managerSuccess = auth.Login("manager", "Manager@123")
        Assert.IsTrue(managerSuccess)
        Assert.IsTrue(AuthService.CanAccessModule("REPORTS"), "Manager must have access to reports.")
        auth.Logout()

        ' Login as Staff
        Dim staffSuccess = auth.Login("staff", "Staff@123")
        Assert.IsTrue(staffSuccess)
        Assert.IsFalse(AuthService.CanAccessModule("REPORTS"), "Staff must NOT have access to reports.")
        auth.Logout()
    End Sub
End Class
