Imports QuestPDF.Fluent
Imports QuestPDF.Helpers
Imports QuestPDF.Infrastructure
Imports AuraPricingSystem.Repositories
Imports AuraPricingSystem.Models
Imports System.IO

Namespace Services
    ''' <summary>
    ''' QuestPDF quotation generator conforming to professional commercial quotation standards.
    ''' QuestPDF is open-source under the Community license for educational/small business projects.
    ''' </summary>
    Public Class PdfReportService
        Private ReadOnly _quoteRepo As New QuotationRepository()
        Private ReadOnly _settingsRepo As New SettingsRepository()

        Public Sub New()
            ' Initialize QuestPDF Community license (complies with open source / academic project use)
            QuestPDF.Settings.License = LicenseType.Community
        End Sub

        ''' <summary>
        ''' Generates an executive, client-ready quotation PDF document.
        ''' </summary>
        Public Sub GenerateQuotationPdf(quotationId As Integer, outputPath As String)
            Dim quote = _quoteRepo.GetQuotationWithCalculation(quotationId)
            If quote Is Nothing Then
                Throw New ArgumentException($"Quotation #{quotationId} not found.")
            End If

            Dim settings = _settingsRepo.GetSettings()
            Dim calc = quote.Calculation

            Document.Create(Sub(container)
                                container.Page(Sub(page)
                                                   page.Size(PageSizes.A4)
                                                   page.Margin(35)
                                                   page.PageColor(Colors.White)
                                                   page.DefaultTextStyle(Sub(x) x.FontSize(10).FontFamily("Arial"))

                                                   ' HEADER
                                                   page.Header().Element(Sub(c) ComposeHeader(c, quote, settings))

                                                   ' CONTENT BODY
                                                   page.Content().Element(Sub(c) ComposeContent(c, quote, calc, settings))

                                                   ' FOOTER
                                                   page.Footer().Element(Sub(c) ComposeFooter(c, settings))
                                               End Sub)
                            End Sub).GeneratePdf(outputPath)
        End Sub

        Private Sub ComposeHeader(container As IContainer, quote As Quotation, settings As SystemSettings)
            container.Row(Sub(row)
                              ' Left: Brand and Info
                              row.RelativeItem().Column(Sub(col)
                                                            col.Item().Text(settings.CompanyName.ToUpper()).FontSize(20).Bold().FontColor("#0C4B88")
                                                            col.Item().Text(settings.CompanyTagline).FontSize(10).Italic().FontColor("#666666")
                                                            col.Item().PaddingTop(4).Text($"{settings.CompanyAddress}").FontSize(9)
                                                            col.Item().Text($"Tel: {settings.CompanyPhone}  |  Email: {settings.CompanyEmail}").FontSize(9)
                                                            col.Item().Text($"TIN: {settings.TaxIdentificationNumber}").FontSize(9)
                                                        End Sub)

                              ' Right: Quotation Badge
                              row.ConstantItem(180).Column(Sub(col)
                                                               col.Item().Background("#0C4B88").Padding(8).Column(Sub(badgeCol)
                                                                                                                      badgeCol.Item().AlignCenter().Text("FORMAL QUOTATION").FontSize(12).Bold().FontColor(Colors.White)
                                                                                                                      badgeCol.Item().AlignCenter().Text(quote.QuoteNo).FontSize(13).Bold().FontColor("#F9A01F")
                                                                                                                  End Sub)
                                                               col.Item().PaddingTop(6).AlignRight().Text($"Date: {quote.QuoteDate:dd-MMM-yyyy}").FontSize(9)
                                                               col.Item().AlignRight().Text($"Validity: {quote.ValidUntil:dd-MMM-yyyy}").FontSize(9).Bold()
                                                               col.Item().AlignRight().Text($"Status: {quote.Status.ToUpper()}").FontSize(9).Bold().FontColor(If(quote.Status = "Accepted", "#247A3D", "#0C4B88"))
                                                           End Sub)
                          End Sub)
        End Sub

        Private Sub ComposeContent(container As IContainer, quote As Quotation, calc As PricingCalculation, settings As SystemSettings)
            container.PaddingTop(15).Column(Sub(col)
                                                ' CLIENT & JOB METADATA
                                                col.Item().Row(Sub(r)
                                                                   ' Prepared For
                                                                   r.RelativeItem().Background("#F0F4F8").Padding(10).Column(Sub(c)
                                                                                                                                 c.Item().Text("PREPARED FOR (CLIENT)").FontSize(9).Bold().FontColor("#0C4B88")
                                                                                                                                 c.Item().Text(quote.ClientName).FontSize(12).Bold()
                                                                                                                                 c.Item().Text($"Contact: {quote.ClientContactPerson}").FontSize(9)
                                                                                                                                 c.Item().Text($"Phone: {quote.ClientPhone} | Email: {quote.ClientEmail}").FontSize(9)
                                                                                                                                 c.Item().Text($"Site Address: {quote.ClientAddress}").FontSize(9)
                                                                                                                             End Sub)

                                                                   r.ConstantItem(15)

                                                                   ' Service Specifications
                                                                   r.RelativeItem().Background("#F0F4F8").Padding(10).Column(Sub(c)
                                                                                                                                 c.Item().Text("PROJECT SPECIFICATIONS").FontSize(9).Bold().FontColor("#0C4B88")
                                                                                                                                 c.Item().Text(quote.JobName).FontSize(12).Bold()
                                                                                                                                 c.Item().Text($"Service Category: {quote.JobType}").FontSize(9)
                                                                                                                                 If calc IsNot Nothing Then
                                                                                                                                     c.Item().Text($"Team Deployment: {calc.TeamMembers} Personnel").FontSize(9)
                                                                                                                                     c.Item().Text($"Estimated Duration: {calc.Days:0.#} Operational Days").FontSize(9)
                                                                                                                                 End If
                                                                                                                             End Sub)
                                                               End Sub)

                                                ' SCOPE OF WORK & LINE ITEMS TABLE
                                                col.Item().PaddingTop(15).Text("SCOPE OF CLEANING SERVICES & COMMERCIAL SUMMARY").FontSize(11).Bold().FontColor("#0C4B88")

                                                col.Item().PaddingTop(5).Table(Sub(table)
                                                                                   table.ColumnsDefinition(Sub(columns)
                                                                                                               columns.ConstantColumn(30)
                                                                                                               columns.RelativeColumn(4)
                                                                                                               columns.RelativeColumn(2)
                                                                                                               columns.RelativeColumn(2)
                                                                                                           End Sub)

                                                                                   ' Table Header
                                                                                   table.Header(Sub(header)
                                                                                                    header.Cell().Background("#0C4B88").Padding(6).Text("#").Bold().FontColor(Colors.White)
                                                                                                    header.Cell().Background("#0C4B88").Padding(6).Text("Description / Service Scope").Bold().FontColor(Colors.White)
                                                                                                    header.Cell().Background("#0C4B88").Padding(6).AlignCenter().Text("Category").Bold().FontColor(Colors.White)
                                                                                                    header.Cell().Background("#0C4B88").Padding(6).AlignRight().Text("Amount (UGX)").Bold().FontColor(Colors.White)
                                                                                                End Sub)

                                                                                   ' Main Job Row
                                                                                   table.Cell().BorderBottom(1).BorderColor("#E0E0E0").Padding(8).Text("1")
                                                                                   table.Cell().BorderBottom(1).BorderColor("#E0E0E0").Padding(8).Column(Sub(c)
                                                                                                                                                             c.Item().Text(quote.JobName).Bold()
                                                                                                                                                             c.Item().Text(quote.Notes).FontSize(8).Italic().FontColor("#555555")
                                                                                                                                                         End Sub)
                                                                                   table.Cell().BorderBottom(1).BorderColor("#E0E0E0").Padding(8).AlignCenter().Text(quote.JobType)
                                                                                   table.Cell().BorderBottom(1).BorderColor("#E0E0E0").Padding(8).AlignRight().Text(quote.TotalAmount.ToString("#,##0") & " UGX").Bold()
                                                                               End Sub)

                                                ' FINANCIAL TOTAL BLOCK
                                                col.Item().PaddingTop(10).Row(Sub(r)
                                                                                  r.RelativeItem(2).Padding(5).Column(Sub(noteCol)
                                                                                                                          noteCol.Item().Text("Pricing Policy:").Bold().FontSize(8)
                                                                                                                          noteCol.Item().Text("All quoted prices include specialized chemical supplies, industrial equipment wear allocation, roundtrip transport logistics, and complete labour supervision.").FontSize(8).FontColor("#666666")
                                                                                                                      End Sub)
                                                                                  r.RelativeItem(2).Background("#0C4B88").Padding(10).Column(Sub(totalCol)
                                                                                                                                                 totalCol.Item().AlignCenter().Text("TOTAL QUOTATION VALUE").FontSize(10).Bold().FontColor(Colors.White)
                                                                                                                                                 totalCol.Item().AlignCenter().Text(quote.TotalAmount.ToString("#,##0") & " UGX").FontSize(16).Bold().FontColor("#F9A01F")
                                                                                                                                             End Sub)
                                                                              End Sub)

                                                ' TERMS AND ACCEPTANCE SIGNATURE BLOCK
                                                col.Item().PaddingTop(20).Text("TERMS & CONDITIONS").FontSize(10).Bold().FontColor("#0C4B88")
                                                col.Item().Text(settings.DefaultTermsAndConditions).FontSize(8).FontColor("#444444")

                                                col.Item().PaddingTop(25).Row(Sub(sigRow)
                                                                                  sigRow.RelativeItem().Column(Sub(sigLeft)
                                                                                                                   sigLeft.Item().LineHorizontal(1).LineColor("#888888")
                                                                                                                   sigLeft.Item().PaddingTop(3).Text("Authorized Signature (Aura Cleaning Solutions)").FontSize(8).Bold()
                                                                                                                   sigLeft.Item().Text("Date & Official Stamp").FontSize(8).FontColor("#666666")
                                                                                                               End Sub)

                                                                                  sigRow.ConstantItem(40)

                                                                                  sigRow.RelativeItem().Column(Sub(sigRight)
                                                                                                                   sigRight.Item().LineHorizontal(1).LineColor("#888888")
                                                                                                                   sigRight.Item().PaddingTop(3).Text("Client Acceptance Signature & Name").FontSize(8).Bold()
                                                                                                                   sigRight.Item().Text("I hereby accept this quotation and confirm booking").FontSize(8).FontColor("#666666")
                                                                                                               End Sub)
                                                                              End Sub)
                                            End Sub)
        End Sub

        Private Sub ComposeFooter(container As IContainer, settings As SystemSettings)
            container.Column(Sub(col)
                                 col.Item().LineHorizontal(1).LineColor("#0C4B88")
                                 col.Item().PaddingTop(4).Row(Sub(r)
                                                                  r.RelativeItem().Text($"{settings.CompanyName}  •  Professional Cleaning & Facility Services").FontSize(8).FontColor("#666666")
                                                                  r.RelativeItem().AlignRight().Text(Sub(t)
                                                                                                         t.Span("Page ")
                                                                                                         t.CurrentPageNumber()
                                                                                                         t.Span(" of ")
                                                                                                         t.TotalPages()
                                                                                                     End Sub).FontSize(8).FontColor("#666666")
                                                              End Sub)
                             End Sub)
        End Sub
    End Class
End Namespace
