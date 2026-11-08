Imports Microsoft.Data.Sqlite
Imports AuraPricingSystem.Helpers

Namespace Data
    ''' <summary>
    ''' Automatically initializes the SQLite database schema on first run.
    ''' Manages versioning, table creation, and initial seeding.
    ''' </summary>
    Public Class DatabaseInitializer
        Public Shared Sub InitializeDatabase()
            Using conn As SqliteConnection = DatabaseConnection.CreateAndOpenConnection()
                Using trans As SqliteTransaction = conn.BeginTransaction()
                    Try
                        CreateTables(conn, trans)
                        SeedInitialData(conn, trans)
                        trans.Commit()
                    Catch ex As Exception
                        trans.Rollback()
                        Throw New InvalidOperationException($"Failed to initialize database: {ex.Message}", ex)
                    End Try
                End Using
            End Using
        End Sub

        Private Shared Sub CreateTables(conn As SqliteConnection, trans As SqliteTransaction)
            Dim ddlScript As String = "
                CREATE TABLE IF NOT EXISTS Users (
                    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE COLLATE NOCASE,
                    PasswordHash TEXT NOT NULL,
                    Salt TEXT NOT NULL,
                    Role TEXT NOT NULL CHECK(Role IN ('Admin', 'Manager', 'Staff')),
                    Status TEXT NOT NULL DEFAULT 'Active' CHECK(Status IN ('Active', 'Inactive')),
                    CreatedAt TEXT NOT NULL DEFAULT (datetime('now'))
                );

                CREATE TABLE IF NOT EXISTS Clients (
                    ClientID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ClientNo TEXT NOT NULL UNIQUE,
                    FullName TEXT NOT NULL,
                    Phone TEXT NOT NULL,
                    Location TEXT NOT NULL,
                    ClientType TEXT NOT NULL CHECK(ClientType IN ('Residential', 'Commercial')),
                    CreatedAt TEXT NOT NULL DEFAULT (datetime('now'))
                );

                CREATE TABLE IF NOT EXISTS Services (
                    ServiceID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ServiceCode TEXT NOT NULL UNIQUE,
                    ServiceName TEXT NOT NULL,
                    LaborRate INTEGER NOT NULL CHECK(LaborRate >= 0),
                    Unit TEXT NOT NULL CHECK(Unit IN ('Per day', 'Per room', 'Per sqm', 'Per item', 'Per site')),
                    CreatedAt TEXT NOT NULL DEFAULT (datetime('now'))
                );

                CREATE TABLE IF NOT EXISTS Staff (
                    StaffID INTEGER PRIMARY KEY AUTOINCREMENT,
                    StaffNo TEXT NOT NULL UNIQUE,
                    FullName TEXT NOT NULL,
                    Phone TEXT NOT NULL,
                    Role TEXT NOT NULL CHECK(Role IN ('Cleaner', 'Supervisor', 'Fumigator')),
                    DailyRate INTEGER NOT NULL CHECK(DailyRate >= 0),
                    Status TEXT NOT NULL DEFAULT 'Active' CHECK(Status IN ('Active', 'Inactive')),
                    CreatedAt TEXT NOT NULL DEFAULT (datetime('now'))
                );

                CREATE TABLE IF NOT EXISTS Quotations (
                    QuotationID INTEGER PRIMARY KEY AUTOINCREMENT,
                    QuoteNo TEXT NOT NULL UNIQUE,
                    ClientID INTEGER NOT NULL,
                    ServiceID INTEGER NOT NULL,
                    JobName TEXT NOT NULL,
                    JobType TEXT NOT NULL,
                    QuoteDate TEXT NOT NULL,
                    TotalAmount INTEGER NOT NULL,
                    Status TEXT NOT NULL DEFAULT 'Pending' CHECK(Status IN ('Pending', 'Accepted', 'Rejected')),
                    CreatedByUserID INTEGER NOT NULL,
                    CreatedAt TEXT NOT NULL DEFAULT (datetime('now')),
                    FOREIGN KEY (ClientID) REFERENCES Clients(ClientID) ON DELETE RESTRICT,
                    FOREIGN KEY (ServiceID) REFERENCES Services(ServiceID) ON DELETE RESTRICT,
                    FOREIGN KEY (CreatedByUserID) REFERENCES Users(UserID)
                );

                CREATE TABLE IF NOT EXISTS PricingCalculations (
                    CalculationID INTEGER PRIMARY KEY AUTOINCREMENT,
                    QuotationID INTEGER NOT NULL UNIQUE,
                    TeamMembers INTEGER NOT NULL,
                    DayRate INTEGER NOT NULL,
                    Days REAL NOT NULL,
                    SuppliesCost INTEGER NOT NULL,
                    TransportCost INTEGER NOT NULL,
                    EquipmentWear INTEGER NOT NULL,
                    MonthlyOverhead INTEGER NOT NULL,
                    AvgJobsPerMonth INTEGER NOT NULL,
                    TargetMargin REAL NOT NULL,
                    LaborCost INTEGER NOT NULL,
                    OverheadAllocation INTEGER NOT NULL,
                    TotalCost INTEGER NOT NULL,
                    SuggestedPrice INTEGER NOT NULL,
                    ProfitAtSuggested INTEGER NOT NULL,
                    LaborPercent REAL NOT NULL,
                    ActualQuote INTEGER NOT NULL,
                    ActualProfit INTEGER NOT NULL,
                    ActualMargin REAL NOT NULL,
                    Verdict TEXT NOT NULL,
                    FOREIGN KEY (QuotationID) REFERENCES Quotations(QuotationID) ON DELETE CASCADE
                );

                CREATE TABLE IF NOT EXISTS Jobs (
                    JobID INTEGER PRIMARY KEY AUTOINCREMENT,
                    JobNo TEXT NOT NULL UNIQUE,
                    QuotationID INTEGER NOT NULL UNIQUE,
                    JobDate TEXT NOT NULL,
                    Status TEXT NOT NULL DEFAULT 'Scheduled' CHECK(Status IN ('Scheduled', 'In Progress', 'Completed')),
                    Notes TEXT,
                    CreatedAt TEXT NOT NULL DEFAULT (datetime('now')),
                    FOREIGN KEY (QuotationID) REFERENCES Quotations(QuotationID) ON DELETE RESTRICT
                );

                CREATE TABLE IF NOT EXISTS JobStaff (
                    JobID INTEGER NOT NULL,
                    StaffID INTEGER NOT NULL,
                    AssignedDate TEXT NOT NULL DEFAULT (datetime('now')),
                    PRIMARY KEY (JobID, StaffID),
                    FOREIGN KEY (JobID) REFERENCES Jobs(JobID) ON DELETE CASCADE,
                    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID) ON DELETE RESTRICT
                );

                CREATE TABLE IF NOT EXISTS Settings (
                    SettingKey TEXT PRIMARY KEY,
                    SettingValue TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS MarginGuide (
                    GuideID INTEGER PRIMARY KEY AUTOINCREMENT,
                    JobType TEXT NOT NULL UNIQUE,
                    MinMargin REAL NOT NULL,
                    MaxMargin REAL NOT NULL,
                    DisplayRange TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS ActivityLogs (
                    LogID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Activity TEXT NOT NULL,
                    Username TEXT NOT NULL,
                    LogTimestamp TEXT NOT NULL DEFAULT (datetime('now'))
                );
            "

            Using cmd As New SqliteCommand(ddlScript, conn, trans)
                cmd.ExecuteNonQuery()
            End Using
        End Sub

        Private Shared Sub SeedInitialData(conn As SqliteConnection, trans As SqliteTransaction)
            ' 1. Seed Administrator User if no users exist
            Dim userCount As Long
            Using cmdCount As New SqliteCommand("SELECT COUNT(*) FROM Users;", conn, trans)
                userCount = CLng(cmdCount.ExecuteScalar())
            End Using

            If userCount = 0 Then
                Dim hash As String = String.Empty
                Dim salt As String = String.Empty
                PasswordHasher.HashPassword("admin123", hash, salt)

                Dim seedUserSql As String = "
                    INSERT INTO Users (Username, PasswordHash, Salt, Role, Status)
                    VALUES (@u, @h, @s, 'Admin', 'Active');"

                Using cmdUser As New SqliteCommand(seedUserSql, conn, trans)
                    cmdUser.Parameters.AddWithValue("@u", "admin")
                    cmdUser.Parameters.AddWithValue("@h", hash)
                    cmdUser.Parameters.AddWithValue("@s", salt)
                    cmdUser.ExecuteNonQuery()
                End Using

                ' Also seed a standard staff user for testing role-based security
                Dim staffHash As String = String.Empty
                Dim staffSalt As String = String.Empty
                PasswordHasher.HashPassword("staff123", staffHash, staffSalt)

                Using cmdStaffUser As New SqliteCommand(seedUserSql, conn, trans)
                    cmdStaffUser.Parameters.AddWithValue("@u", "staff1")
                    cmdStaffUser.Parameters.AddWithValue("@h", staffHash)
                    cmdStaffUser.Parameters.AddWithValue("@s", staffSalt)
                    cmdStaffUser.ExecuteNonQuery()
                End Using
            End If

            ' 2. Seed Default Services if empty
            Dim serviceCount As Long
            Using cmdCount As New SqliteCommand("SELECT COUNT(*) FROM Services;", conn, trans)
                serviceCount = CLng(cmdCount.ExecuteScalar())
            End Using

            If serviceCount = 0 Then
                Dim seedServicesSql As String = "
                    INSERT INTO Services (ServiceCode, ServiceName, LaborRate, Unit) VALUES
                    ('PC01', 'Post-Construction Cleaning', 30000, 'Per day'),
                    ('RS01', 'Residential Cleaning', 25000, 'Per room'),
                    ('CP01', 'Carpet Cleaning', 15000, 'Per sqm'),
                    ('UP01', 'Upholstery Cleaning', 20000, 'Per item'),
                    ('FM01', 'Fumigation', 50000, 'Per site');"

                Using cmdSvc As New SqliteCommand(seedServicesSql, conn, trans)
                    cmdSvc.ExecuteNonQuery()
                End Using
            End If

            ' 3. Seed Default Staff if empty
            Dim staffCount As Long
            Using cmdCount As New SqliteCommand("SELECT COUNT(*) FROM Staff;", conn, trans)
                staffCount = CLng(cmdCount.ExecuteScalar())
            End Using

            If staffCount = 0 Then
                Dim seedStaffSql As String = "
                    INSERT INTO Staff (StaffNo, FullName, Phone, Role, DailyRate, Status) VALUES
                    ('ST001', 'Staff A', '0700 111 001', 'Supervisor', 35000, 'Active'),
                    ('ST002', 'Staff B', '0700 111 002', 'Cleaner', 30000, 'Active'),
                    ('ST003', 'Staff C', '0700 111 003', 'Fumigator', 30000, 'Active');"

                Using cmdStf As New SqliteCommand(seedStaffSql, conn, trans)
                    cmdStf.ExecuteNonQuery()
                End Using
            End If

            ' 4. Seed Margin Guide if empty
            Dim guideCount As Long
            Using cmdCount As New SqliteCommand("SELECT COUNT(*) FROM MarginGuide;", conn, trans)
                guideCount = CLng(cmdCount.ExecuteScalar())
            End Using

            If guideCount = 0 Then
                Dim seedGuideSql As String = "
                    INSERT INTO MarginGuide (JobType, MinMargin, MaxMargin, DisplayRange) VALUES
                    ('Residential - Standard', 0.10, 0.15, '10%–15%'),
                    ('Residential - Deep/Move-in', 0.20, 0.28, '20%–28%'),
                    ('Residential - Post-Construction', 0.25, 0.35, '25%–35%'),
                    ('Commercial', 0.15, 0.20, '15%–20%'),
                    ('Specialty (Carpet/Upholstery/Fumigation)', 0.25, 0.45, '25%–45%'),
                    ('Survival floor (any job)', 0.10, 0.10, '10%');"

                Using cmdG As New SqliteCommand(seedGuideSql, conn, trans)
                    cmdG.ExecuteNonQuery()
                End Using
            End If

            ' 5. Seed Default Settings if empty
            Dim settingsCount As Long
            Using cmdCount As New SqliteCommand("SELECT COUNT(*) FROM Settings;", conn, trans)
                settingsCount = CLng(cmdCount.ExecuteScalar())
            End Using

            If settingsCount = 0 Then
                Dim seedSettingsSql As String = "
                    INSERT INTO Settings (SettingKey, SettingValue) VALUES
                    ('CompanyName', 'Aura Cleaning Solutions'),
                    ('DefaultMargin', '0.30'),
                    ('Currency', 'UGX'),
                    ('QuotePrefix', 'Q-'),
                    ('JobPrefix', 'J-'),
                    ('ClientPrefix', 'CL'),
                    ('StaffPrefix', 'ST'),
                    ('CompanyPhone', '+256 700 000 000'),
                    ('CompanyEmail', 'info@auracleaningsolutions.com'),
                    ('CompanyAddress', 'Muyenga, Kampala, Uganda');"

                Using cmdSet As New SqliteCommand(seedSettingsSql, conn, trans)
                    cmdSet.ExecuteNonQuery()
                End Using
            End If
        End Sub
    End Class
End Namespace
