# Hệ thống Quản lý Bán lẻ & Tồn kho Siêu thị Mini (MiniSupermarket System)

Đây là đồ án thực hành môn học Lập trình Ứng dụng (LTUD) - Xây dựng mô hình Client - Server bằng nền tảng .NET.

## 🌟 Tổng quan kiến trúc
Dự án được chia làm 2 phân hệ (Projects) hoạt động độc lập và giao tiếp với nhau qua giao thức HTTP (RESTful API):

1. **MiniSupermarket.API (Backend / Server)**
   - **Công nghệ:** ASP.NET Core Web API (.NET 8/9), C#.
   - **Chức năng:** Cung cấp các điểm cuối (Endpoints) để thao tác dữ liệu (CRUD).
   - **Cơ sở dữ liệu tạm:** Sử dụng `In-Memory List` (Danh sách lưu trên RAM) phục vụ cho giai đoạn phát triển ban đầu.
   - **Tài liệu API:** Tích hợp sẵn Swagger UI (`Swashbuckle.AspNetCore`) để kiểm thử trực quan.

2. **MiniSupermarket.WinForms (Frontend / Client)**
   - **Công nghệ:** Windows Forms App (.NET 8/9), C#.
   - **Chức năng:** Giao diện người dùng trực quan giúp thao tác quản lý dữ liệu.
   - **Giao tiếp API:** Sử dụng thư viện `System.Net.Http.Json` và `HttpClient` để gửi/nhận dữ liệu JSON từ Server.

## 🚀 Các chức năng đã hoàn thành (Buổi 1)
- **Quản lý Nhóm hàng (Categories):** Thêm, sửa, xóa, lấy danh sách, và tìm kiếm nhóm hàng hóa.
- **Quản lý Chức vụ (Roles):** Thêm, sửa, xóa, lấy danh sách, và tìm kiếm chức vụ nhân sự (Admin, Manager, Cashier,...).

## 🛠 Cách cài đặt và chạy ứng dụng

1. **Yêu cầu hệ thống:** 
   - Visual Studio 2022.
   - .NET SDK 8.0 hoặc 9.0.

2. **Khởi chạy (Chế độ 2 Projects cùng lúc):**
   - Mở file `MiniSupermarket.sln` bằng Visual Studio.
   - Click chuột phải vào thẻ Solution `MiniSupermarket` ở cửa sổ Solution Explorer -> Chọn **Set Startup Projects...**
   - Chọn **Multiple startup projects**.
   - Đặt cột Action của cả 2 dự án `MiniSupermarket.API` và `MiniSupermarket.WinForms` thành **Start** (Đảm bảo API nằm ở dòng trên).
   - Bấm **Apply** -> **OK**.
   - Ấn **F5** để chạy phần mềm.

*(Lưu ý: Không tắt cửa sổ Console màu đen của API Server trong quá trình sử dụng phần mềm WinForms).*

---

## 👨‍💻 5. Tác giả
- **Họ tên sinh viên:** Nguyễn Tấn Điệp
- **Mã sinh viên:** 2123110145
- **Lớp học phần:** CCQ2411C
