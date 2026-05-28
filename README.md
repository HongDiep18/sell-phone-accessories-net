# Cửa Hàng Phụ Kiện Điện Thoại — Phone Accessories Store Management

Desktop application for managing a phone accessories retail store: sales, inventory import, customers, employees, suppliers, statistics, and Crystal Reports printing.

**Course project:** Nhóm 7 — Quản lý cửa hàng phụ kiện điện thoại.

---

## Table of contents

- [Features](#features)
- [Tech stack](#tech-stack)
- [Architecture](#architecture)
- [Project structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Database setup](#database-setup)
- [Configure connection string](#configure-connection-string)
- [Build and run](#build-and-run)
- [Usage guide](#usage-guide)
- [Roles and permissions](#roles-and-permissions)
- [Database schema](#database-schema)
- [Reports](#reports)
- [Troubleshooting](#troubleshooting)
- [License](#license)

---

## Features

| Module | Description |
|--------|-------------|
| **Đăng nhập / Đăng xuất** | Employee login; change password |
| **Bán sản phẩm** | Point-of-sale: select products, create invoices (`HOADON`), print invoice report |
| **Nhập sản phẩm** | Stock import via purchase receipts (`PHIEUNHAP`), print import slip |
| **Danh mục sản phẩm** | CRUD product categories (`DANHMUC`) |
| **Chi tiết sản phẩm** | Product catalog with images (`SANPHAM`) |
| **Khách hàng** | Customer management (`KHACHANG`) |
| **Nhà cung cấp** | Supplier management (`NHACC`) |
| **Nhân viên** | Employee management (`NHANVIEN`) — manager only |
| **Thống kê** | Revenue / import cost by month or year; open management reports |

---

## Tech stack

| Layer | Technology |
|-------|------------|
| **Language** | C# |
| **UI** | Windows Forms (WinForms) |
| **Framework** | .NET Framework **4.8** |
| **IDE** | Visual Studio 2017+ (solution targets VS 2022) |
| **Database** | Microsoft **SQL Server** |
| **Data access** | ADO.NET (`System.Data.SqlClient`) |
| **Reporting** | **SAP Crystal Reports** 13.0.4000.0 |
| **Pattern** | 3-tier: **GUI → BLL → DAL → SQL Server**, plus **DTO** entities |

---

## Architecture

```
┌─────────────────────────────────────────────────────────┐
│  GUI (WinForms)                                         │
│  frmMain, frmSanPham, frmNhapKho, Crystal Reports…      │
└──────────────────────────┬──────────────────────────────┘
                           │
┌──────────────────────────▼──────────────────────────────┐
│  BLL (Business Logic Layer)                             │
│  SanPhamBLL, HoaDonBLL, NhanVienBLL, ThongKeBLL…        │
└──────────────────────────┬──────────────────────────────┘
                           │
┌──────────────────────────▼──────────────────────────────┐
│  DAL (Data Access Layer)                                │
│  SanPhamDAL, HoaDonDAL… (SqlConnection + SQL)           │
└──────────────────────────┬──────────────────────────────┘
                           │
┌──────────────────────────▼──────────────────────────────┐
│  SQL Server — Database: Nhom7_CuaHangPhuKienDienThoai   │
└─────────────────────────────────────────────────────────┘

        DTO — shared entity classes (referenced by BLL/DAL/GUI)
```

**Startup:** `GUI/Program.cs` launches `frmMain`, which embeds `frmDangNhap` until the user signs in.

---

## Project structure

```
sell-phone-accessories-net/
├── README.md
├── database5.bacpac          # Full database backup (schema + sample data) — recommended
├── database5.sql             # Schema + foreign keys only (no seed data)
├── Nhom7_QLPKDT.docx         # Project documentation (Word)
└── Nhom7_CuaHangPhuKienDienThoai/
    └── CuaHangPhuKienDienThoai/
        ├── CuaHangPhuKienDienThoai.sln
        ├── GUI/                # Presentation — executable project
        │   ├── Program.cs
        │   ├── frm*.cs         # Forms
        │   ├── *.rpt           # Crystal report templates
        │   └── Imgs/           # Product images (SP001.jpg …)
        ├── BLL/                # Business logic
        ├── DAL/                # SQL Server access
        └── DTO/                # Data transfer objects
```

**Solution projects**

| Project | Output | References |
|---------|--------|------------|
| `GUI` | `GUI.exe` (WinExe) | BLL, DTO, Crystal Reports |
| `BLL` | `BLL.dll` | DAL, DTO |
| `DAL` | `DAL.dll` | DTO |
| `DTO` | `DTO.dll` | — |

--------

## Prerequisites

Install on **Windows**:

1. **[.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)** (Developer Pack if building from CLI)
2. **[Visual Studio 2022](https://visualstudio.microsoft.com/)** (or 2019) with workload:
   - **.NET desktop development**
3. **SQL Server** (one of):
   - SQL Server Express / Developer / LocalDB
   - Named instance example from repo: `DESKTOP-JARJMT7\SA`
4. **SAP Crystal Reports runtime** for .NET Framework (version **13.x**, matching project references)
   - Install the runtime that matches your Crystal Reports SP; without it, report forms fail at runtime.

Optional: **SQL Server Management Studio (SSMS)** for importing `.bacpac` and running scripts.

---

## Database setup

Database name: **`Nhom7_CuaHangPhuKienDienThoai`**

### Option A — Import `.bacpac` (recommended)

Includes tables, relationships, and sample data.

1. Open **SSMS** → connect to your SQL Server instance.
2. Right-click **Databases** → **Import Data-tier Application…**
3. Select `database5.bacpac` from the repository root.
4. Set the target database name to `Nhom7_CuaHangPhuKienDienThoai` (or keep the default if it matches).
5. Complete the wizard.

### Option B — Run `database5.sql` (schema only)

1. Create an empty database named `Nhom7_CuaHangPhuKienDienThoai`.
2. Open `database5.sql` in SSMS and execute against that database.
3. Manually insert employees, products, and other master data (the script does not include `INSERT` statements).

### SQL Server authentication

The application connection strings use **SQL authentication**:

- User: `sa`
- Password: `123` (as in DAL and Crystal report logon)

Enable mixed mode on SQL Server if you use `sa`, or create a dedicated login and update the connection strings (see below).

---

## Configure connection string

Connection strings are **hard-coded** in every file under `DAL/` (same value in all 10 DAL classes).

Default (from repository):

```
Data Source=DESKTOP-JARJMT7\SA;
Initial Catalog=Nhom7_CuaHangPhuKienDienThoai;
Persist Security Info=True;
User ID=sa;
Password=123
```

**Update for your machine** — edit `conStr` in each of these files:

- `DAL/SanPhamDAL.cs`
- `DAL/HoaDonDAL.cs`
- `DAL/ChiTietHoaDonDAL.cs`
- `DAL/PhieuNhapDAL.cs`
- `DAL/ChiTietPN_DAL.cs`
- `DAL/DanhMucDAL.cs`
- `DAL/KhachHangDAL.cs`
- `DAL/NhanVienDAL.cs`
- `DAL/NhaCungCapDAL.cs`
- `DAL/ThongKeDAL.cs`

Example for **LocalDB**:

```
Data Source=(localdb)\MSSQLLocalDB;
Initial Catalog=Nhom7_CuaHangPhuKienDienThoai;
Integrated Security=True
```

Crystal Reports also use database logon in code (e.g. `frmBao_Cao1`: `SetDatabaseLogon("sa", "123")`). Update those if you change SQL credentials.

> **Tip:** For production or team development, consider moving the connection string to `App.config` and a single `DataProvider` class instead of duplicating it in every DAL file.

---

## Build and run

### Visual Studio

1. Clone or download the repository.
2. Open:

   ```
   Nhom7_CuaHangPhuKienDienThoai/CuaHangPhuKienDienThoai/CuaHangPhuKienDienThoai.sln
   ```

3. Set **GUI** as the startup project (right-click → **Set as Startup Project**).
4. Restore/build: **Build → Build Solution** (`Ctrl+Shift+B`).
5. Run: **Debug → Start Debugging** (`F5`) or **Start Without Debugging** (`Ctrl+F5`).

Output executable (Debug):

```
Nhom7_CuaHangPhuKienDienThoai/CuaHangPhuKienDienThoai/GUI/bin/Debug/GUI.exe
```

Copy the entire `bin/Debug` folder (including `Imgs/`, `.rpt` dependencies, and Crystal runtime DLLs) when deploying to another PC.

### MSBuild (command line)

From **Developer Command Prompt for VS** or PowerShell with MSBuild on `PATH`:

```powershell
cd "Nhom7_CuaHangPhuKienDienThoai\CuaHangPhuKienDienThoai"
msbuild CuaHangPhuKienDienThoai.sln /p:Configuration=Debug
.\GUI\bin\Debug\GUI.exe
```

---

## Usage guide

### 1. Start the application

Run `GUI.exe`. The main window opens with the login form embedded in the center panel.

### 2. Sign in

- Enter **Mã nhân viên** (employee ID) and **Mật khẩu**.
- Use accounts from your imported database (`NHANVIEN` table: `MANV`, `MATKHAU`).
- On success, menus unlock according to **Chức vụ** (`CHUCVU`).

### 3. Main menu (after login)

| Menu | Form | Notes |
|------|------|--------|
| Bán sản phẩm | `frmSanPham` | Sales / invoicing |
| Nhập sản phẩm | `frmNhapKho` | Stock import |
| Danh mục sản phẩm | `frmDanhMuc` | Categories |
| Chi tiết sản phẩm | `frmChiTietSanPham` | Product details & images |
| Khách hàng | `frmKhachHang` | Customers |
| Nhà cung cấp | `frmNhaCungCap` | Suppliers |
| Nhân viên | `frmNhanVien` | Employees (manager) |
| Thống kê | `frmThongKe` | Stats + report shortcuts |
| Đổi mật khẩu | `frmDoiMatKhau` | Change password |
| Đăng xuất | — | Returns to login screen |

Product images are loaded from `GUI/Imgs/` (e.g. `SP001.jpg`) and additional files under `ProductImages/`.

---

## Roles and permissions

Permissions are applied in `frmMain.loadMaNV()` based on `NHANVIEN.CHUCVU`:

| Role code | Typical meaning | Access |
|-----------|-----------------|--------|
| **QL** | Quản lý (manager) | All menus: sales, import, categories, products, customers, statistics, employees, suppliers |
| **NVBH** | Nhân viên bán hàng | Sales, categories, product details, customers |
| **Other** | e.g. warehouse staff | Import, categories, product details, suppliers |

Exact menu enable/disable logic is in `GUI/frmMain.cs`.

---

## Database schema

| Table | Purpose |
|-------|---------|
| `DANHMUC` | Product categories |
| `SANPHAM` | Products (price, stock, category) |
| `KHACHANG` | Customers |
| `NHANVIEN` | Employees (login, role, salary) |
| `NHACC` | Suppliers |
| `HOADON` | Sales invoices |
| `CHITIETHOADON` | Invoice line items |
| `PHIEUNHAP` | Purchase / import receipts |
| `CHITIETPN` | Import receipt line items |

Entity relationships (foreign keys) are defined in `database5.sql`.

**DTO mapping (examples)**

| DTO | Table |
|-----|--------|
| `SanPhamDTO` | `SANPHAM` |
| `HoaDonDTO` | `HOADON` |
| `ChiTietHoaDonDTO` | `CHITIETHOADON` |
| `NhanVienDTO` | `NHANVIEN` |
| `KhachHangDTO` | `KHACHANG` |
| `PhieuNhapDTO` | `PHIEUNHAP` |

---

## Reports

Crystal Reports (`.rpt`) in the `GUI` project:

| Report file | Usage |
|-------------|--------|
| `HoaDon.rpt` | Sales invoice |
| `PhieuNhap.rpt` | Import slip |
| `BaoCao_DoanhThu_NV.rpt` | Revenue by employee (`frmBao_Cao1`) |
| `Bao_Cao_DoanhThu_Time.rpt` | Revenue by time (`frmBao_Cao2`) |
| `Bao_Cao_SanPham.rpt` | Product report (`frmBao_Cao3`) |
| `Bao_Cao_NhapHang.rpt` | Import report (`frmBao_Cao4`) |
| `Bao_Ca0_NhapHang_SP.rpt` | Import by product (`frmBao_Cao5`) |

Open reports from **Thống kê** via buttons `btn1` … `btn5`, or from sales/import flows where invoice/slip preview is implemented.

---

## Troubleshooting

| Problem | What to check |
|---------|----------------|
| **Cannot connect to database** | SQL Server running; database imported; `conStr` in all DAL files matches your server name, catalog, and credentials |
| **Login always fails** | `NHANVIEN` rows exist; `MANV` / `MATKHAU` match (comparison is plain text, trimmed) |
| **Crystal Reports error / blank report** | Crystal Reports **13** runtime installed; `SetDatabaseLogon` user/password matches SQL; report data source points to correct server |
| **Missing product images** | Image file exists under `GUI/Imgs/` or `ProductImages/` with the name expected by the form |
| **Build errors on Crystal** | Install Crystal Reports for Visual Studio integration or ensure referenced assemblies (13.0.4000.0) are available |
| **Menus disabled after login** | User `CHUCVU` must be `QL`, `NVBH`, or another configured role in `frmMain` |

---

## Development notes

- **Entry point:** `GUI/Program.cs` → `Application.Run(new frmMain())`.
- **Child forms:** Opened inside `panel_body` via `OpenChildForm()` (MDI-like, single child at a time).
- **BLL ↔ DAL:** One BLL class per domain area (e.g. `SanPhamBLL` → `SanPhamDAL`).
- **Security:** Passwords are stored and compared in plain text in the current design — not suitable for production without hashing and centralized auth.

---

## License

Academic / educational project (Nhóm 7). Use and distribute according to your course or team agreement.

---

## Quick start checklist

- [ ] Install .NET Framework 4.8, Visual Studio, SQL Server, Crystal Reports runtime  
- [ ] Import `database5.bacpac`  
- [ ] Update connection strings in all `DAL/*.cs` files (and Crystal logon if needed)  
- [ ] Open `CuaHangPhuKienDienThoai.sln`, build, run **GUI**  
- [ ] Sign in with an employee account from `NHANVIEN`  

If you need sample logins, query after import:

```sql
SELECT MANV, TENNV, CHUCVU, MATKHAU FROM NHANVIEN;
```
