Namespace Models
    ''' <summary>
    ''' System configuration settings.
    ''' </summary>
    Public Class SystemSettings
        Public Property CompanyName As String = "Aura Cleaning Solutions"
        Public Property DefaultMargin As Decimal = 0.30D ' 30%
        Public Property Currency As String = "UGX"
        Public Property QuotePrefix As String = "Q-"
        Public Property JobPrefix As String = "J-"
        Public Property ClientPrefix As String = "CL"
        Public Property StaffPrefix As String = "ST"
        Public Property CompanyPhone As String = "+256 700 000 000"
        Public Property CompanyEmail As String = "info@auracleaningsolutions.com"
        Public Property CompanyAddress As String = "Kampala, Uganda"
    End Class

    ''' <summary>
    ''' Editable margin guide records per job type.
    ''' </summary>
    Public Class MarginGuideItem
        Public Property GuideID As Integer
        Public Property JobType As String = String.Empty
        Public Property MinMargin As Decimal ' e.g., 0.25 (25%)
        Public Property MaxMargin As Decimal ' e.g., 0.35 (35%)
        Public Property DisplayRange As String = String.Empty ' e.g., "25%–35%"

        Public Overrides Function ToString() As String
            Return $"{JobType}: {DisplayRange}"
        End Function
    End Class

    ''' <summary>
    ''' Audit trail record for Recent Activities on Dashboard.
    ''' </summary>
    Public Class ActivityLog
        Public Property LogID As Integer
        Public Property Activity As String = String.Empty
        Public Property Username As String = "System"
        Public Property LogTimestamp As DateTime = DateTime.Now
    End Class
End Namespace
