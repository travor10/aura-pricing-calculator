Namespace Models
    ''' <summary>
    ''' Represents an active, scheduled, or completed cleaning job booking.
    ''' </summary>
    Public Class JobBooking
        Public Property JobID As Integer
        Public Property JobNo As String = String.Empty ' e.g., J-0001
        Public Property QuotationID As Integer
        Public Property JobDate As DateTime = DateTime.Today
        Public Property Status As String = "Scheduled" ' Scheduled, In Progress, Completed
        Public Property Notes As String = String.Empty
        Public Property CreatedAt As DateTime = DateTime.Now

        ' Joined display properties
        Public Property QuoteNo As String = String.Empty
        Public Property ClientName As String = String.Empty
        Public Property ServiceName As String = String.Empty
        Public Property TotalAmount As Decimal
        Public Property AssignedStaffList As New List(Of StaffMember)
    End Class

    ''' <summary>
    ''' Represents the assignment of a staff member to a scheduled job.
    ''' </summary>
    Public Class JobStaffAssignment
        Public Property JobID As Integer
        Public Property StaffID As Integer
        Public Property AssignedDate As DateTime = DateTime.Now
    End Class
End Namespace
