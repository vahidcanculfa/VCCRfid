# VCCRfid
RFID Project
# UHF RFID Desktop Reader – Native C# WinForms Application

A lightweight, high-performance Windows Forms application for UHF RFID desktop readers based on the widely used **Impinj R2000** chipset (common in many Chinese OEM fixed/desktop readers).

Works perfectly with USB Virtual COM Port (VCP) readers — no external DLLs, no SDK licensing, no bloatware.

### Features
- Zero external dependencies (pure `System.IO.Ports`)
- Real-time inventory with duplicate filtering (same tag appears only once)
- Displays EPC (up to 62 hex chars), RSSI (dBm), and precise timestamp
- Full control: Connect / Disconnect / Start / Stop / Clear
- COM port & baud rate selection
- DataGridView + rich log panel + status strip
- Beep sound on every new tag
- Properly parses the reader's native binary protocol (frame header 0xA0)
- Built with .NET 8.0 (Windows) – runs on Windows 10/11 without issues

### Tested & Confirmed Working Readers
- Most Impinj R2000-based desktop USB readers (single-antenna, virtual COM port)
- Typical baud rate: 115200 (also supports 57600, 38400, etc.)

### How to Use
1. Plug in the reader (it appears as a COM port in Device Manager)
2. Run `VCCRfid2.exe`
3. Select correct COM port & baud rate (usually 115200)
4. Click **Connect** → **Scan**
5. Bring tags near the antenna → EPCs appear instantly with RSSI and timestamp

### Why This Project Exists
Many OEM readers ship with broken, outdated, or Chinese-only SDKs/DLLs that crash on modern Windows.  
This app bypasses all of that and talks directly to the hardware using the real underlying protocol — fast, stable, and 100% open source.

### Build Requirements
- Visual Studio 2022/2025
- Target framework: **.NET 8.0-windows** (important!)
- No NuGet packages needed


### License
MIT License – feel free to use, modify, and distribute in commercial or personal projects.

---
Made because sometimes the simplest solution is the most reliable one.
