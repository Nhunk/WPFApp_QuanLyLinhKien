# Ứng Dụng WPF Quản Lý Bán Linh Kiện (Tích Hợp AI - Database First)

Ứng dụng Desktop được xây dựng bằng **WPF (.NET)** nhằm quản lý toàn bộ quy trình bán hàng linh kiện điện tử.  
Dự án sử dụng kiến trúc **Database First** với **Entity Framework 6 (EF6)**, kết hợp xử lý dữ liệu thông minh qua **mô hình AI dạng ONNX**.

---

## Tính Năng Nổi Bật

- **Quản lý CRUD đầy đủ**: Sản phẩm, Khách hàng, Nhà cung cấp, Nhân viên, Đơn hàng, Kho hàng.
- **Truy xuất dữ liệu mạnh mẽ**: Sử dụng **Entity Framework 6 (Database First)** + LINQ để thao tác dữ liệu.
- **Tích hợp AI/ONNX**: Đọc mô hình ONNX để dự đoán tồn kho, gợi ý mua hàng, phân loại sản phẩm,...
- **Giao diện đẹp với WPF**: Dễ sử dụng, điều hướng rõ ràng, hỗ trợ phân quyền (Admin/Staff).
- **Kiến trúc tách lớp**: View – ViewModel – Services – Models.
- **Phân quyền người dùng**: Dựa trên bảng Account trong database.

---

## Công Nghệ Sử Dụng

| Lĩnh vực | Công nghệ | Ghi chú |
|--------|------------|---------|
| UI | WPF (.NET Framework) | Ứng dụng Desktop Windows |
| ORM | Entity Framework 6 | **Database First** |
| Database | SQL Server / LocalDB | Chứa toàn bộ dữ liệu |
| AI | ONNX Runtime | Chạy mô hình AI |
| Ngôn ngữ | C# | .NET |

## Các Gói NuGet Cần Thiết

### 1. **Entity Framework 6 (Database First)**

- `EntityFramework`
- `Microsoft.Data.SqlClient` (nếu cần)
- `System.Configuration.ConfigurationManager`

### 2. **AI/ML (ONNX Runtime)**

- `Microsoft.ML.OnnxRuntime`
- `Microsoft.ML.OnnxRuntime.Managed`

---

## 🗄 Kiến Trúc Dự Án

```text
WPFApp_QuanLyLinhKien
├── Models                # Entity Framework Database First (EDMX + POCO classes)
├── Services              # Xử lý đăng nhập, session, nghiệp vụ
│     └── AuthService.cs
│     └── AppSession.cs
├── ViewModels            # MVVM ViewModel
├── Views                 # XAML UI (Admin + Staff)
├── Data                  # Thư mục chứa ảnh sản phẩm
└── README.md
```
## Hướng Dẫn Cài Đặt Ứng Dụng WPF Quản Lý Bán Linh Kiện (Database First + AI ONNX)

### 1. YÊU CẦU HỆ THỐNG

| Thành phần | Yêu cầu |
|-----------|---------|
| **Hệ điều hành** | Windows 10/11 |
| **IDE** | Visual Studio 2019 hoặc 2022 |
| **.NET Framework** | 4.7.2+ |
| **Cơ sở dữ liệu** | SQL Server Express / LocalDB |
| **ORM** | Entity Framework 6 (Database First) |
| **AI Runtime** | ONNX Runtime |

---

### 2. CÀI ĐẶT PROJECT

## 🔹 2.1. Clone mã nguồn

```bash
git clone https://github.com/Nhunk/WPFApp_QuanLyLinhKien
cd WPFApp_QuanLyLinhKien
