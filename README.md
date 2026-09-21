# HIS+ — Operating Room Report Generator

A Windows desktop application (C#, WinForms, .NET Framework 4.8) built for a hospital's operating room department. It integrates the hospital's SQL Server database with Microsoft Word to automate the creation, editing, and archival of operation report sheets.

## What it does

- **Connects to the hospital's Operating Room database** (SQL Server) to look up patient reception records, surgeons, anesthesiologists, nurses, and technicians by their staff codes.
- **Generates a Word document automatically** from a `.docx`/`.dotx` template stored in the database, using Word's Content Controls API (via Office Interop) to pre-fill patient/staff/procedure fields — patient name, unit number, surgeon, anesthesia type, operation date/time, etc.
- **Lets the surgical staff complete the remaining fields** directly in Word (diagnosis, procedure findings, specimen info) using the familiar Word editing experience, compatible with Office 2010.
- **Persists the finished report back into the database** as binary document data when the user saves, so each operation report is versioned and retrievable per patient encounter (matched by serial/date/time).

## Why it exists

Operating rooms previously filled out this report on a printed paper form (see `Docs/IMAG0026.JPG` / `Docs/IMAG0038.JPG` for the original paper form this replaced). This app digitizes that workflow end-to-end: pulling structured data from the hospital information system straight into the document, and storing the completed report back in the same database instead of a paper archive.

## Tech stack

- C# / WinForms, .NET Framework 4.8
- SQL Server (ADO.NET) for both the OR scheduling database and the application's own database
- Microsoft Office (Word) Interop for document generation via Content Controls
- AES-encrypted application settings for stored connection strings

## Project structure

- `HIS+App/` — main WinForms application source
  - `OpRoomDbHelper.cs`, `HisPlusDbHelper.cs` — data access for the two databases
  - `WordHelper.cs`, `OperationReportFileManager.cs`, `OpReportDocContentControlsManager.cs` — Word document lifecycle (open template, fill fields, save back to DB)
  - `DefaultOpProcedureEditForm.cs`, `DefaultOpProceduresForm.cs` — per-surgeon default procedure text management
- `Docs/` — the original paper form (reference scans) and internal spec notes

> Note: this project links against a small shared internal utilities library (`DBHelper`, AES encryption helpers, app settings) that lives outside this repository, so it will not build standalone without that library present at the expected relative path.

## Privacy note

Earlier revisions of this repository's history included real patient report files used during development/testing. Those have been removed from the current tree. If you are cloning this repository, be aware that older commits may still reference that history.
