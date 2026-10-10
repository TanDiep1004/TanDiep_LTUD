# ĐỀ TÀI: NGHIÊN CỨU VÀ HIỆN THỰC HÓA HỆ THỐNG QUẢN LÝ BÁN LẺ VÀ TỒN KHO THEO KIẾN TRÚC CLIENT-SERVER (RESTFUL API & WINFORMS)
### ỨNG DỤNG CHO HỆ THỐNG BÁN LẺ CÔ BA SÀI GÒN

---

## 👨‍💻 Thông tin Tác giả & Học phần
- **Họ và tên sinh viên:** Nguyễn Tấn Điệp
- **Mã số sinh viên (MSSV):** 2123110145
- **Lớp học phần:** CCQ2411C
- **Học phần:** Lập trình Ứng dụng (LTUD)
- **Nền tảng:** .NET 9.0 / C# / Microsoft SQL Server

---

## 🌟 1. Tổng quan Kiến trúc Hệ thống (Architecture Overview)

Dự án được xây dựng theo chuẩn **Kiến trúc Doanh nghiệp phân tầng (N-Tier / Client-Server)** gồm 2 phân hệ độc lập:

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                   HỆ THỐNG BÁN LẺ CÔ BA SÀI GÒN                            │
├─────────────────────────────────────────┬───────────────────────────────────┤
│  MiniSupermarket.WinForms (Frontend)    │  MiniSupermarket.API (Backend)    │
│  - Modern Single-Form Shell Pattern     │  - RESTful Web API (.NET 9)       │
│  - Sidebar Navigation (Width = 230)     │  - JWT Bearer Authentication      │
│  - Dynamic Child Form Embedding         │  - Role-Based Authorization       │
│  - Quầy POS quét mã vạch Barcode        │  - EF Core 9 Code-First ORM       │
│  - Quản lý Tồn kho & Hội viên tích điểm │  - Microsoft SQL Server Database  │
└─────────────────────────────────────────┴───────────────────────────────────┘
```

1. **Phân hệ Backend: `MiniSupermarket.API`**
   - **Nền tảng:** ASP.NET Core Web API (.NET 9.0).
   - **ORM & CSDL:** Entity Framework Core 9.0 Code-First kết nối Microsoft SQL Server (`MiniSupermarketDb`).
   - **Bảo mật:** Xác thực danh tính qua **JSON Web Token (JWT Bearer)** và phân quyền theo vai trò (`[Authorize(Roles = "...")]`).
   - **Tài liệu kiểm thử:** Tích hợp Swagger UI (`https://localhost:7299/swagger`).

2. **Phân hệ Frontend: `MiniSupermarket.WinForms`**
   - **Nền tảng:** Windows Forms (.NET 9.0 Windows).
   - **Mô hình giao diện:** Kiến trúc khung đơn **Single-Form Shell Pattern (`FormMainShell`)** chuẩn HD 1280x720, không bật các cửa sổ con rời rạc.
   - **Nhúng động Form con:** Kỹ thuật `TopLevel = false`, `FormBorderStyle = None`, `Dock = Fill` vào vùng `panelMainContent`.
   - **Giao tiếp API:** Tập trung qua `ApiClientService` sử dụng `HttpClient` hỗ trợ tự động đính kèm Token và xử lý an toàn SSL Development Certificates.

---

## 📋 2. Tiến trình Hiện thực hóa qua các Buổi Thực hành

### Buổi 1: Xây dựng Nền tảng RESTful API & In-Memory Storage
- Xây dựng cấu trúc phân tầng API đầu tiên cho ứng dụng quản lý bán lẻ.
- Định nghĩa các Model nghiệp vụ: `Category` (Nhóm hàng), `Role` (Chức vụ).
- Hiện thực hóa các Endpoints CRUD (Create, Read, Update, Delete) và tìm kiếm chuỗi Query String.

### Buổi 2: Xác thực JWT & Phân quyền Bảo mật (Authorization)
- Tích hợp dịch vụ cấp phát token JWT an toàn tại `AuthController` (`POST /api/auth/login`).
- Phân định quyền truy cập hệ thống qua thuộc tính `[Authorize]`.
- Xây dựng màn hình đăng nhập `FormLogin`, lưu trữ phiên làm việc tĩnh tại `SessionManager`.

### Buổi 3: Tích hợp SQL Server & Entity Framework Core Code-First
- Chuyển đổi toàn diện từ In-Memory sang cơ sở dữ liệu quan hệ **Microsoft SQL Server (`MiniSupermarketDb`)**.
- Áp dụng kỹ thuật EF Core Code-First: Khai báo Data Annotations (`[Table]`, `[Key]`, `[DatabaseGenerated]`, `[Required]`, `[ForeignKey]`).
- Thiết lập quan hệ 1 - N giữa `Category` và `Product`.
- Quản lý phiên bản CSDL qua Migrations (`InitialCreateDatabase`, `SeedProductsData`).
- Tối ưu hóa truy vấn bất đồng bộ LINQ (`async`/`await`, `AsNoTracking`, `ToListAsync`, `SaveChangesAsync`).

### Buổi 4: Kiến trúc Giao diện Shell, Điều hướng Phân quyền RBAC & Quầy POS
- **Giao diện Shell chuẩn hiện đại:** Bố cục thanh điều hướng bên trái (`panelSidebar`), thanh tiêu đề trên (`panelTopHeader`) và không gian làm việc chính (`panelMainContent`).
- **Phân quyền vai trò (RBAC):** Tự động thích ứng giao diện theo 3 vai trò:
  - **Admin (Quản trị viên):** Toàn quyền truy cập tất cả 6 chức năng.
  - **Cashier (Thu ngân):** Chỉ truy cập Quầy POS bán hàng và Quản lý khách hàng thành viên.
  - **Warehouse (Thủ kho):** Chỉ quản lý Danh mục nhóm hàng và Sản phẩm tồn kho.
- **Cơ chế bảo vệ 2 lớp (Two-Layer Security):** Vừa ẩn nút trên giao diện, vừa chặn cứng logic tại Controller/Action.
- **Hệ thống Quầy POS Barcode (`FormPOS`):**
  - Quét mã vạch tự động nhận diện sản phẩm (nhấn Enter) qua API `products/barcode/{barcode}`.
  - Nhập SĐT tra cứu khách hàng thân thiết và hạng thẻ thành viên.
  - Tính tổng tiền, tiền thừa và thanh toán phím tắt **F9** qua API `orders/checkout` trừ tồn kho tức thì trên SQL Server.
- **Màn hình Báo cáo Doanh thu Nhanh (`FormQuickReport`):** Bộ lọc ngày, 3 thẻ tổng quan doanh số và chi tiết hóa đơn ca bán.
- **Quản trị Tài khoản (`FormUserManagement`):** Xem danh sách nhân viên, cấp tài khoản mới, đặt lại mật khẩu và khóa/mở khóa tài khoản.

---

## 👥 3. Bộ Dữ liệu 15 Tài khoản Kiểm thử Phân quyền (RBAC Test Accounts)

| STT | Username | Mật khẩu | Họ và tên nhân sự | Vai trò (Role) | Chức năng được phép | Màn hình khởi chạy |
| :---: | :--- | :---: | :--- | :---: | :--- | :--- |
| **1** | `admin01` | `123456` | Nguyễn Quản Trị | **Admin** | Toàn quyền toàn bộ hệ thống | Quản lý Danh mục |
| **2** | `admin02` | `123456` | Trần Giám Đốc | **Admin** | Toàn quyền toàn bộ hệ thống | Quản lý Danh mục |
| **3** | `cashier01` | `123456` | Lê Thu Ngân | **Cashier** | Quầy POS, Khách hàng tích điểm | Quầy Bán hàng POS |
| **4** | `cashier02` | `123456` | Phạm Bán Hàng | **Cashier** | Quầy POS, Khách hàng tích điểm | Quầy Bán hàng POS |
| **5** | `cashier03` | `123456` | Hoàng Thu Ngân | **Cashier** | Quầy POS, Khách hàng tích điểm | Quầy Bán hàng POS |
| **6** | `cashier04` | `123456` | Vũ Thị Quầy | **Cashier** | Quầy POS, Khách hàng tích điểm | Quầy Bán hàng POS |
| **7** | `cashier05` | `123456` | Đỗ Bán Lẻ | **Cashier** | Quầy POS, Khách hàng tích điểm | Quầy Bán hàng POS |
| **8** | `ware01` | `123456` | Ngô Quản Kho | **Warehouse** | Sản phẩm, Danh mục nhóm hàng | Quản lý Sản phẩm |
| **9** | `ware02` | `123456` | Bùi Kiểm Kê | **Warehouse** | Sản phẩm, Danh mục nhóm hàng | Quản lý Sản phẩm |
| **10** | `ware03` | `123456` | Dương Thủ Kho | **Warehouse** | Sản phẩm, Danh mục nhóm hàng | Quản lý Sản phẩm |
| **11** | `ware04` | `123456` | Lý Nhập Hàng | **Warehouse** | Sản phẩm, Danh mục nhóm hàng | Quản lý Sản phẩm |
| **12** | `admin_backup`| `123456` | Đặng Hỗ Trợ | **Admin** | Toàn quyền toàn bộ hệ thống | Quản lý Danh mục |
| **13** | `cashier06` | `123456` | Hồ Ca Chiều | **Cashier** | Quầy POS, Khách hàng tích điểm | Quầy Bán hàng POS |
| **14** | `ware05` | `123456` | Trương Vận Chuyển | **Warehouse** | Sản phẩm, Danh mục nhóm hàng | Quản lý Sản phẩm |
| **15** | `supervisor`| `123456` | Mai Giám Sát | **Admin** | Toàn quyền toàn bộ hệ thống | Quản lý Danh mục |

*(Hệ thống duy trì thêm 2 tài khoản mặc định `admin` và `cashier` với mật khẩu `123456`)*.

---

## 🛠 4. Hướng dẫn Cài đặt & Khởi chạy Đồ án

### Yêu cầu Môi trường:
- Visual Studio 2022 (hoặc VS Code).
- .NET 9.0 SDK.
- Microsoft SQL Server (LocalDB, SQL Express hoặc SQL Server Standard).

### Các bước Chạy Dự án:
1. Mở file giải pháp `MiniSupermarket.sln` bằng Visual Studio 2022.
2. Thiết lập chạy đồng thời 2 dự án (Multiple Startup Projects):
   - Nhấp chuột phải vào Solution `MiniSupermarket` -> Chọn **Properties**.
   - Chọn mục **Startup Project** -> Chọn **Multiple startup projects**.
   - Cấu hình Action:
     - `MiniSupermarket.API`: **Start** (ở trên).
     - `MiniSupermarket.WinForms`: **Start** (ở dưới).
   - Nhấn **Apply** -> **OK**.
3. Nhấn **F5** để khởi chạy cả Server và Client.
4. Màn hình đăng nhập **FormLogin** xuất hiện:
   - Thử đăng nhập với các tài khoản `admin01`, `cashier01`, hoặc `ware01` để trải nghiệm cơ chế phân quyền giao diện Shell mượt mà.
