# AURA CLEANING SOLUTIONS – PRICING & QUOTATION MANAGEMENT SYSTEM
## Capstone Project Academic Defense Document & Viva Preparation Guide

**Author:** Trevor Mubiru  
**Project:** Aura Cleaning Solutions – Pricing and Quotation Management System  
**Framework:** .NET 8 / Visual Studio 2022 / Windows Forms (VB.NET)  
**Database:** SQLite 3 (Microsoft.Data.Sqlite)  
**Libraries:** ClosedXML (Excel OpenXML 4-sheet reporting), QuestPDF (Vector PDF Quotations), PBKDF2 (HMAC-SHA256 Security)

---

## 1. Executive Summary & Problem Statement

### Real-World Business Problem:
In commercial and residential cleaning enterprises across Uganda, pricing is frequently estimated using informal guesswork or fragmented spreadsheets. This leads to:
1. **Under-recovery of hidden overheads:** Failure to allocate office rent, administrative utilities, and equipment depreciation.
2. **Margin erosion:** Actual quotes accepted below the 10% survival floor, leading to operational losses.
3. **Labor cost volatility:** Labor exceeding healthy reference thresholds (45%–60% of price) due to unbudgeted overtime or team size over-allocation.
4. **Historical pricing drift:** Changes to base service rates or daily wages inadvertently altering previously issued client quotes.

### Technical Solution:
The **Aura Pricing and Quotation Management System** is a professional desktop Windows Forms application engineered in **VB.NET (.NET 8)** backed by a relational **SQLite** database. It enforces rigid cost accounting rules derived directly from `Aura_Job_Costing_Calculator.xlsx`, locks pricing snapshots at the exact second a quotation is created, prevents illegal state transitions (such as scheduling jobs for unaccepted quotes), and exports audit-ready ClosedXML Excel workbooks and QuestPDF formal client proposals.

---

## 2. System Architecture & Layered Design

The codebase strictly adheres to an N-Tier Layered Architecture with complete separation of concerns:

```
┌────────────────────────────────────────────────────────┐
│                   Presentation Layer                   │
│   Windows Forms (FrmMain, FrmCalculator, FrmQuotes...) │
└───────────────────────────┬────────────────────────────┘
                            │ (Calls Business Methods Only)
┌───────────────────────────▼────────────────────────────┐
│                  Business Logic Layer                  │
│   PricingEngine.vb, AuthService.vb, ReportService.vb   │
│   ExcelExportService.vb, PdfReportService.vb           │
└───────────────────────────┬────────────────────────────┘
                            │ (Uses Data Transfer Objects)
┌───────────────────────────▼────────────────────────────┐
│                    Data Access Layer                   │
│   Repositories: QuotationRepo, JobRepo, UserRepo...    │
│   DatabaseConnection.vb (Parameterized SQLite)          │
└───────────────────────────┬────────────────────────────┘
                            │ (ACID Transactions & FKs)
┌───────────────────────────▼────────────────────────────┐
│                     Database Layer                     │
│   SQLite Database (aura_pricing.db)                    │
│   12 Normalized Tables in Third Normal Form (3NF)      │
└────────────────────────────────────────────────────────┘
```

### Architectural Guarantees:
- **Zero SQL in UI Forms:** No Form contains inline SQL strings or `SqliteCommand` declarations. Forms interact solely with Services and Repositories.
- **Single Source of Mathematical Truth:** Pricing arithmetic resides exclusively in `PricingEngine.vb`. It is never duplicated in reports, forms, or export routines.
- **Decimal Precision:** All financial calculations utilize the 128-bit `System.Decimal` type to prevent IEEE 754 floating-point rounding inaccuracies.
- **Defensive Data Integrity:** SQLite Foreign Key enforcement (`PRAGMA foreign_keys = ON;`) is enabled on every connection.

---

## 3. Database Schema & Normalization (Third Normal Form)

The database schema is fully normalized into **Third Normal Form (3NF)**:
1. **1NF:** Every column contains atomic values; no repeating groups.
2. **2NF:** All non-key attributes are fully functionally dependent on the entire primary key.
3. **3NF:** No transitive dependencies exist.

### Entity-Relationship (ER) Structure:

```
[Users] ───────────< [ActivityLogs] (Audit Trail)
  │
  ├────────────────< [Quotations] (CreatedBy)
                       │
                       ├── (1:1) ─── [PricingCalculations] (Confidential Snapshot)
                       │
                       └── (1:M) ─── [Jobs]
                                       │
                                       └── (M:N via JobStaff) ─── [Staff]

[Clients] ─────────< [Quotations]
[Services] ────────< [QuotationItems] / [Services Catalog]
[MarginGuide] ───── (Reference Bands for PricingEngine)
[Settings] ──────── (Singleton Company Configuration)
```

### Critical Table Schemas:

1. **`Quotations` Table (Client-Facing Header):**
   - `QuotationID` (PK, INTEGER AUTOINCREMENT)
   - `QuoteNo` (TEXT UNIQUE, e.g., 'QUO-0001')
   - `ClientID` (FK -> Clients.ClientID)
   - `JobName` (TEXT)
   - `JobType` (TEXT)
   - `QuoteDate` (TEXT)
   - `ValidUntil` (TEXT)
   - `TotalAmount` (INTEGER / Decimal UGX)
   - `Status` (TEXT: 'Draft', 'Sent', 'Accepted', 'Rejected')
   - `CreatedBy` (FK -> Users.UserID)

2. **`PricingCalculations` Table (Confidential Historical Snapshot):**
   - `CalculationID` (PK, INTEGER AUTOINCREMENT)
   - `QuotationID` (FK -> Quotations.QuotationID, UNIQUE 1:1)
   - `TeamMembers` (INTEGER), `Days` (REAL), `DayRate` (INTEGER)
   - `LaborCost` (INTEGER)
   - `SuppliesCost` (INTEGER), `TransportCost` (INTEGER), `EquipmentWear` (INTEGER)
   - `MonthlyOverhead` (INTEGER), `AvgJobsPerMonth` (INTEGER), `OverheadAllocation` (INTEGER)
   - `TotalCost` (INTEGER)
   - `TargetMargin` (REAL), `SuggestedPrice` (INTEGER), `ProfitAtSuggested` (INTEGER)
   - `LaborPercent` (REAL)
   - `ActualProfit` (INTEGER), `ActualMargin` (REAL), `Verdict` (TEXT)

3. **`JobStaff` Table (Junction Table for M:N Relationship):**
   - `JobID` (FK -> Jobs.JobID ON DELETE CASCADE)
   - `StaffID` (FK -> Staff.StaffID ON DELETE RESTRICT)
   - Composite Primary Key: `(JobID, StaffID)`

---

## 4. Authoritative Pricing Formulas & Excel Mapping

All calculations are mapped directly from `Aura_Job_Costing_Calculator.xlsx`:

| Parameter | Authoritative Formula | VB.NET Implementation |
|---|---|---|
| **Labor Cost** | $=\text{TeamMembers} \times \text{DayRate} \times \text{Days}$ | `input.TeamMembers * input.DayRate * input.Days` |
| **Overhead Allocation** | $=\text{IF}(\text{AvgJobs}=0, 0, \frac{\text{MonthlyOverhead}}{\text{AvgJobs}})$ | `If(input.AvgJobsPerMonth = 0, 0D, Math.Round(input.MonthlyOverhead / CDec(input.AvgJobsPerMonth), 2))` |
| **Total Cost** | $=\text{Labor} + \text{Supplies} + \text{Transport} + \text{Wear} + \text{Overhead}$ | `result.LaborCost + input.SuppliesCost + input.TransportCost + input.EquipmentWear + result.OverheadAllocation` |
| **Suggested Price** | $=\text{IF}(\text{TargetMargin} \ge 1, \text{Error}, \frac{\text{TotalCost}}{1 - \text{TargetMargin}})$ | `Math.Round(result.TotalCost / (1.0D - input.TargetMargin), 0)` |
| **Profit at Suggested** | $=\text{SuggestedPrice} - \text{TotalCost}$ | `result.SuggestedPrice - result.TotalCost` |
| **Labor Percentage** | $=\text{IF}(\text{SuggestedPrice}=0, 0, \frac{\text{LaborCost}}{\text{SuggestedPrice}})$ | `Math.Round(result.LaborCost / result.SuggestedPrice, 4)` |
| **Actual Profit** | $=\text{ActualQuote} - \text{TotalCost}$ | `input.ActualQuote - result.TotalCost` |
| **Actual Margin** | $=\text{IF}(\text{ActualQuote}=0, 0, \frac{\text{ActualQuote}-\text{TotalCost}}{\text{ActualQuote}})$ | `Math.Round((input.ActualQuote - result.TotalCost) / input.ActualQuote, 4)` |

### Commercial Margin Verdict Matrix:
- $\text{Margin} < 10\%$: **BELOW SURVIVAL FLOOR - reprice** (High risk of insolvency).
- $10\% \le \text{Margin} < 20\%$: **OK, BUT THIN - push toward target** (Low buffer for scope creep).
- $20\% \le \text{Margin} \le 45\%$: **HEALTHY MARGIN** (Optimal commercial zone).
- $\text{Margin} > 45\%$: **CHECK - unusually high, verify costs** (Verify inputs to ensure bid competitiveness).

### Authoritative Benchmark (Bukiika Sample Verification):
- **Inputs:** 7 cleaners, UGX 30,000/day, 2 days, UGX 100,000 supplies, UGX 200,000 transport, UGX 15,000 wear, UGX 100,000 overhead, 8 avg jobs, 35% target margin, UGX 1,200,000 actual quote.
- **Computed Outputs:**
  - Labor Cost: **UGX 420,000**
  - Overhead Allocation: **UGX 12,500**
  - Total Cost: **UGX 747,500**
  - Suggested Price: **UGX 1,150,000**
  - Profit at Suggested: **UGX 402,500**
  - Labor % of Price: **36.5%** (Triggers advisory reference warning: outside 45%–60% band)
  - Actual Profit: **UGX 452,500**
  - Actual Margin: **37.7%**
  - Verdict: **HEALTHY MARGIN**

---

## 5. Top 10 Lecturer Defense Questions & Model Answers

### Q1: Why did you choose Windows Forms and .NET 8 over a web framework or older .NET Framework 4.8?
**Model Answer:**  
Windows Forms on **.NET 8** combines desktop-native speed, zero latency for data entry clerks, and full offline autonomy with the modern, cross-platform performance enhancements of modern .NET. Unlike legacy .NET Framework 4.8 (which is Windows-tied and lacks modern language features), .NET 8 provides high-performance JIT compilation, native support for modern libraries like ClosedXML and QuestPDF, and long-term support (LTS). For university demonstration, desktop applications eliminate web server deployment friction, browser caching anomalies, and network timeouts.

### Q2: How does the application guarantee historical quotation immutability? If a cleaner's daily wage increases from UGX 30,000 to UGX 40,000 next month, will old quotes be recalculated?
**Model Answer:**  
No, old quotes will remain permanently unchanged. We solved this through our **Dual-Table Snapshot Architecture**. When a quotation is created, the system writes the client header to the `Quotations` table and executes an atomic insert into `PricingCalculations`. This secondary table stores the *frozen historical values* of all 20 calculation parameters (team size, day rate, supply cost, overhead allocation, labor percentage, and margin verdict). If a manager updates the daily rate in the `Services` or `Staff` tables, those updates apply exclusively to *new* calculations. Old quotes always load their locked snapshot directly from `PricingCalculations`.

### Q3: Why is Suggested Price calculated as $\frac{\text{TotalCost}}{1 - \text{TargetMargin}}$ instead of $\text{TotalCost} \times (1 + \text{TargetMargin})$?
**Model Answer:**  
This is the fundamental distinction in commercial cost accounting between **Markup** and **Gross Profit Margin**:
- **Markup** calculates profit as a percentage of cost: $\text{Markup} = \frac{\text{Profit}}{\text{Cost}}$.
- **Margin** calculates profit as a percentage of revenue (the price paid by the client): $\text{Margin} = \frac{\text{Profit}}{\text{Price}} = \frac{\text{Price} - \text{Cost}}{\text{Price}}$.
Solving for Price gives:
$$\text{Price} \times (1 - \text{Margin}) = \text{Cost} \implies \text{Price} = \frac{\text{Cost}}{1 - \text{Margin}}$$
If we used cost-plus markup for a 35% target margin on a UGX 747,500 cost, the price would be UGX 1,009,125, which yields an actual profit margin of only $25.9\%$—falling severely short of the company's 35% target. Our `PricingEngine` implements rigorous margin mathematics as defined in `Aura_Job_Costing_Calculator.xlsx`.

### Q4: How do you prevent SQL Injection and database corruption in SQLite?
**Model Answer:**  
1. **Parameterized Queries Only:** Every SQL command in our repositories uses explicit parameter objects (e.g., `cmd.Parameters.AddWithValue("@quoteNo", quote.QuoteNo)`). Raw strings are never concatenated into SQL statements.
2. **ACID Transactions:** Complex multi-step operations (such as saving a Quotation and its Calculation snapshot, or creating a Job and inserting into `JobStaff`) are wrapped in `SqliteTransaction`. If any step fails, `tx.Rollback()` is invoked, leaving the database completely clean.
3. **Foreign Key Enforcement:** SQLite defaults to disabling foreign keys. Our `DatabaseConnection.GetConnection()` method explicitly executes `PRAGMA foreign_keys = ON;` upon opening every database connection.

### Q5: How is password security implemented? Why not store plain text or MD5 hashes?
**Model Answer:**  
MD5 and SHA1 are cryptographically broken, and plain text violates modern data protection principles. We implemented the industry standard **PBKDF2 (Password-Based Key Derivation Function 2)** using `Rfc2898DeriveBytes` with HMAC-SHA256:
- A unique, cryptographically random **16-byte salt** is generated using `RandomNumberGenerator` for each password.
- The password and salt are hashed through **100,000 iterations**.
- The resulting salt and hash are formatted as `{salt_hex}:{hash_hex}`.
- Verification re-hashes the input password against the extracted salt using constant-time comparison to prevent timing attacks.

### Q6: How does the system enforce business workflow rules between Quotations and Job Bookings?
**Model Answer:**  
In cleaning operations, dispatching staff to a client site before commercial acceptance leads to non-payment. We enforce a two-tier guard:
1. **Presentation Layer:** In `FrmQuotes.vb`, the "Schedule Job" button remains strictly disabled unless the quote's status is `Accepted`.
2. **Repository Layer:** In `JobRepository.vb` within `CreateJobFromQuotation`, the method queries the database:
   ```vb
   If Not quoteStatus.ToString().Equals("Accepted", StringComparison.OrdinalIgnoreCase) Then
       Throw New InvalidOperationException("A Job Booking can only be created for an Accepted Quotation.")
   End If
   ```
This defense-in-depth prevents illegal state transitions even if someone attempts to bypass the UI.

### Q7: Explain the ClosedXML Excel export. Does it export static values or live formulas?
**Model Answer:**  
In `ExcelExportService.vb`, we use **ClosedXML** to create an executive 4-sheet OpenXML `.xlsx` workbook. Most importantly, on **Sheet 4 (Costing Calculator Template)**, we write live OpenXML formula syntax:
- `wsCalc.Cell("E4").FormulaA1 = "=B6*B7*B8"` (Labor Cost)
- `wsCalc.Cell("E8").FormulaA1 = "=IF(B13=0, 0, B12/B13)"` (Overhead)
- `wsCalc.Cell("E9").FormulaA1 = "=SUM(E4:E8)"` (Total Cost)
- `wsCalc.Cell("E11").FormulaA1 = "=E9/(1-B14)"` (Suggested Price)
- `wsCalc.Cell("E18").FormulaA1 = "=IF(E16=0, 0, (E16-E9)/E16)"` (Actual Margin)
When opened in Microsoft Excel or LibreOffice, the spreadsheet calculates dynamically in real-time, matching the original Excel workbook.

### Q8: What PDF generation technology was chosen, and how did you verify license compatibility?
**Model Answer:**  
We evaluated several PDF tools and selected **QuestPDF** (`QuestPDF.Fluent`). Legacy libraries like iText 7 require paid commercial licenses (AGPL/commercial), while PDFSharp has limited high-level layout support. QuestPDF provides a dedicated **Community License** for university, open-source, and small business software under $1M annual revenue. We explicitly configure this at service initialization:
```vb
QuestPDF.Settings.License = LicenseType.Community
```
QuestPDF compiles document layouts into pure vector PDFs with page numbering, tables, headers, and signature acceptance blocks.

### Q9: How is Role-Based Access Control (RBAC) enforced across the 12 modules?
**Model Answer:**  
We maintain a session-aware `AuthService` with three roles: `Admin`, `Manager`, and `Staff`:
- `Admin`: Full access to all 12 modules, including User Management and System Settings.
- `Manager`: Access to Dashboard, Clients, Services, Staff, Calculator, Quotes, Jobs, and Reports. Blocked from User Management.
- `Staff`: Operational access only (Calculator, Quotes, Jobs, Clients, Staff). Blocked from Financial Reports, System Settings, and User Management.
The sidebar navigation (`FrmMain.vb`) dynamically hides restricted navigation buttons during the `FrmMain_Load` event and re-validates permissions before opening any form.

### Q10: How are automated tests structured, and what scenarios are covered?
**Model Answer:**  
We built a dedicated test project (`AuraPricingSystem.Tests.vbproj`) using `MSTest` containing **30 automated tests**:
- **Tests 1–8:** PricingEngine mathematical proofs (Bukiika sample, zero division guards, negative input guards, 100% margin exceptions).
- **Tests 9–14:** Security, PBKDF2 hashing verification, role retrieval, and UI permission enforcement.
- **Tests 15–20:** Historical integrity, immutable snapshot preservation, auto-increment sequence formats, and last-admin deletion guards.
- **Tests 21–25:** Quotation status transitions, Draft job rejection guards, and multi-staff junction table assignments.
- **Tests 26–30:** Financial aggregation math, category profitability breakdowns, ClosedXML binary export, QuestPDF `%PDF-` header verification, and reporting RBAC.

---

## 6. Deployment & Visual Studio 2022 Setup Instructions

To open, build, and run the complete desktop application on any Windows machine:
1. Ensure **Visual Studio 2022** (version 17.8 or later) is installed with the **.NET Desktop Development** workload.
2. Open the solution file: `/vbnet/AuraPricingSystem.sln`.
3. In Solution Explorer, ensure `AuraPricingSystem` is set as the StartUp Project.
4. Open the **Package Manager Console** or run `dotnet restore` to restore the 3 NuGet dependencies:
   - `Microsoft.Data.Sqlite` (v8.0.10)
   - `ClosedXML` (v0.102.3)
   - `QuestPDF` (v2024.3.5)
5. Press **F5** to compile and run. On initial startup, `DatabaseInitializer.vb` automatically creates `aura_pricing.db` in `Application.StartupPath` and seeds all default users, services, staff, margin guides, and the Bukiika reference quotation.
6. To run the automated unit test suite, press **Ctrl+R, A** in Visual Studio Test Explorer. All 30 tests will run and pass green.
