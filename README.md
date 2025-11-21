# Ứng Dụng WPF Quản Lý Bán Linh Kiện (Tích Hợp AI)

Một ứng dụng Desktop hiện đại được xây dựng bằng **WPF (.NET)**, nhằm quản lý toàn bộ quy trình bán hàng linh kiện điện tử. Dự án tích hợp các công nghệ truy xuất dữ liệu mạnh mẽ (**EF Core/LINQ**) và khả năng dự đoán/xử lý thông minh thông qua mô hình **AI/ONNX**.

## Tính Năng Nổi Bật

* **Quản lý CRUD Đầy Đủ:** Quản lý danh mục Sản phẩm, Khách hàng, Đơn hàng, và Kho hàng.
* **Truy vấn Hiệu quả:** Sử dụng **Entity Framework Core** kết hợp với **LINQ** để truy xuất dữ liệu nhanh chóng và an toàn.
* **Tích hợp AI/ONNX:** Sử dụng mô hình Machine Learning định dạng **ONNX** để [Ví dụ: dự đoán nhu cầu tồn kho, phân loại sản phẩm, hoặc gợi ý mua hàng].
* **Giao diện WPF:** Giao diện người dùng trực quan, được xây dựng trên Windows Presentation Foundation.
* **Tích hợp API:** Giao tiếp với các dịch vụ bên ngoài (hoặc mô hình AI) qua các lệnh gọi API.

## 🛠️ Công Nghệ Sử Dụng

| Lĩnh vực | Công nghệ | Phiên bản | Ghi chú |
| :--- | :--- | :--- | :--- |
| **Giao diện** | WPF (Windows Presentation Foundation) | .NET 8 | Ứng dụng Desktop chạy trên Windows |
| **ORM** | Entity Framework Core (EF Core) | 8.0.4 | Quản lý Database |
| **Database** | SQL Server (LocalDB/Express) | N/A | Cơ sở dữ liệu quan hệ |
| **Truy vấn** | LINQ (Language Integrated Query) | C# | Thao tác dữ liệu mạnh mẽ |
| **AI/ML** | ONNX Runtime | N/A | Tích hợp mô hình AI đã huấn luyện |

### Các Gói NuGet Cần Thiết (EF Core 8.0.4)

* `Microsoft.EntityFrameworkCore`
* `Microsoft.EntityFrameworkCore.SqlServer`
* `Microsoft.EntityFrameworkCore.Design`
* `Microsoft.EntityFrameworkCore.Tools`
* **[Gói ONNX của bạn]** Ví dụ: `Microsoft.ML.OnnxRuntime`

## 🚀 Cài Đặt và Khởi Chạy

### 1. Yêu cầu Hệ thống

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (Bắt buộc)
* Visual Studio 2022 (Khuyến nghị)
* SQL Server LocalDB (Mặc định được cài cùng Visual Studio)

### 2. Tải Mã Nguồn

```bash
git clone https://github.com/Nhunk/WPFApp_QuanLyLinhKien
cd WPFApp_QuanLyLinhKien
