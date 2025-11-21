using WPFApp_QuanLyLinhKien.Models;

namespace WPFApp_QuanLyLinhKien.Database
{
    public class Input
    {
        public static void Seed(AppDbContext db)
        {
            // Tạo DB nếu chưa có
            db.Database.EnsureCreated();

            // ======= NHÂN VIÊN & ACCOUNT =======
            if (!db.NhanViens.Any())
            {
                var nv1 = new NhanVien
                {
                    TenNV = "Admin",
                    DiaChi = "123 Đường ABC, Hà Nội",
                    SDT = "0123456789",
                    Email = "admin@example.com"
                };
                var nv2 = new NhanVien
                {
                    TenNV = "Nhân Viên 1",
                    DiaChi = "456 Đường XYZ, Hà Nội",
                    SDT = "0987654321",
                    Email = "staff1@example.com"
                };
                var nv3 = new NhanVien
                {
                    TenNV = "Nhân Viên 2",
                    DiaChi = "789 Đường LMN, Hà Nội",
                    SDT = "0912345678",
                    Email = "staff2@example.com"
                };

                db.NhanViens.AddRange(nv1, nv2, nv3);
                db.SaveChanges();

                db.Accounts.AddRange(
                    new Account { Username = "admin", PasswordHash = "123", Role = "Admin", MaNV = nv1.MaNV },
                    new Account { Username = "staff1", PasswordHash = "123", Role = "Staff", MaNV = nv2.MaNV },
                    new Account { Username = "staff2", PasswordHash = "123", Role = "Staff", MaNV = nv3.MaNV }
                );
                db.SaveChanges();
            }

            // ======= LOẠI SẢN PHẨM =======
            if (!db.LoaiSanPhams.Any())
            {
                var loaiCpu = new LoaiSanPham { TenLoai = "CPU" };
                var loaiGpu = new LoaiSanPham { TenLoai = "GPU" };
                var loaiHdd = new LoaiSanPham { TenLoai = "HDD" };
                var loaiMb = new LoaiSanPham { TenLoai = "MAINBOARD" };
                var loaiRam = new LoaiSanPham { TenLoai = "RAM" };
                var loaiSsd = new LoaiSanPham { TenLoai = "SSD" };
                db.LoaiSanPhams.AddRange(loaiCpu, loaiGpu, loaiHdd, loaiMb, loaiRam, loaiSsd);
                db.SaveChanges();
            }

            // ======= SẢN PHẨM =======
            if (!db.SanPhams.Any())
            {
                var loaiDict = db.LoaiSanPhams.ToDictionary(l => l.TenLoai, l => l.MaLoai);

                // CPU
                for (int i = 1; i <= 8; i++)
                {
                    db.SanPhams.Add(new SanPham
                    {
                        TenSP = $"CPU {i}",
                        GiaBan = 4000000 + i * 100000,
                        MaLoai = loaiDict["CPU"],
                        HinhAnh = $"Database/Images/cpu{i}.jpg",
                        MoTa = $"CPU mô tả {i}"
                    });
                }

                // GPU
                for (int i = 1; i <= 8; i++)
                {
                    db.SanPhams.Add(new SanPham
                    {
                        TenSP = $"GPU {i}",
                        GiaBan = 10000000 + i * 500000,
                        MaLoai = loaiDict["GPU"],
                        HinhAnh = $"Database/Images/gpu{i}.jpg",
                        MoTa = $"GPU mô tả {i}"
                    });
                }

                // HDD
                for (int i = 1; i <= 8; i++)
                {
                    db.SanPhams.Add(new SanPham
                    {
                        TenSP = $"HDD {i}",
                        GiaBan = 1500000 + i * 100000,
                        MaLoai = loaiDict["HDD"],
                        HinhAnh = $"Database/Images/hdd{i}.jpg",
                        MoTa = $"HDD mô tả {i}"
                    });
                }

                // MAINBOARD
                for (int i = 1; i <= 8; i++)
                {
                    db.SanPhams.Add(new SanPham
                    {
                        TenSP = $"Mainboard {i}",
                        GiaBan = 3000000 + i * 200000,
                        MaLoai = loaiDict["MAINBOARD"],
                        HinhAnh = $"Database/Images/mb{i}.jpg",
                        MoTa = $"Mainboard mô tả {i}"
                    });
                }

                // RAM
                for (int i = 1; i <= 8; i++)
                {
                    db.SanPhams.Add(new SanPham
                    {
                        TenSP = $"RAM {i}",
                        GiaBan = 800000 + i * 50000,
                        MaLoai = loaiDict["RAM"],
                        HinhAnh = $"Database/Images/ram{i}.jpg",
                        MoTa = $"RAM mô tả {i}"
                    });
                }

                // SSD
                for (int i = 1; i <= 8; i++)
                {
                    db.SanPhams.Add(new SanPham
                    {
                        TenSP = $"SSD {i}",
                        GiaBan = 1200000 + i * 80000,
                        MaLoai = loaiDict["SSD"],
                        HinhAnh = $"Database/Images/ssd{i}.jpg",
                        MoTa = $"SSD mô tả {i}"
                    });
                }

                db.SaveChanges();
            }

            // ======= KHO =======
            if (!db.Khos.Any())
            {
                foreach (var sp in db.SanPhams)
                {
                    db.Khos.Add(new Kho
                    {
                        MaSP = sp.MaSP,
                        TonKho = 10,
                        TonToiThieu = 3
                    });
                }
                db.SaveChanges();
            }

            // ======= NHÀ CUNG CẤP =======
            if (!db.NhaCungCaps.Any())
            {
                db.NhaCungCaps.AddRange(
                    new NhaCungCap { TenNCC = "FPT Shop", DiaChi = "Hà Nội", SDT = "0123456789", Email = "fpt@example.com" },
                    new NhaCungCap { TenNCC = "Nguyễn Kim", DiaChi = "TP HCM", SDT = "0987654321", Email = "nguyenkim@example.com" }
                );
                db.SaveChanges();
            }

            // ======= PHIẾU NHẬP & CHI TIẾT PHIẾU NHẬP =======
            if (!db.PhieuNhaps.Any())
            {
                var nv = db.NhanViens.First();
                var ncc = db.NhaCungCaps.First();

                var pn = new PhieuNhap
                {
                    MaNCC = ncc.MaNCC,
                    MaNV = nv.MaNV,
                    TongTien = 0
                };
                db.PhieuNhaps.Add(pn);
                db.SaveChanges();

                // Chi tiết phiếu nhập
                var spList = db.SanPhams.Take(5).ToList();
                foreach (var sp in spList)
                {
                    db.ChiTietPhieuNhaps.Add(new ChiTietPhieuNhap
                    {
                        MaPN = pn.MaPN,
                        MaSP = sp.MaSP,
                        SoLuong = 5,
                        GiaNhap = sp.GiaBan * 0.8m
                    });
                    pn.TongTien += 5 * sp.GiaBan * 0.8m;
                }
                db.SaveChanges();
            }

            // ======= KHÁCH HÀNG =======
            if (!db.KhachHangs.Any())
            {
                db.KhachHangs.AddRange(
                    new KhachHang { TenKH = "Nguyễn Văn A", DiaChi = "Hà Nội", SDT = "0123456789", Email = "a@example.com" },
                    new KhachHang { TenKH = "Trần Thị B", DiaChi = "TP HCM", SDT = "0987654321", Email = "b@example.com" }
                );
                db.SaveChanges();
            }

            // ======= HÓA ĐƠN & CHI TIẾT HÓA ĐƠN =======
            if (!db.HoaDons.Any())
            {
                var kh = db.KhachHangs.First();
                var nvHD = db.NhanViens.First();
                var hd = new HoaDon
                {
                    MaKH = kh.MaKH,
                    MaNV = nvHD.MaNV,
                    TongTien = 0
                };
                db.HoaDons.Add(hd);
                db.SaveChanges();

                var spList = db.SanPhams.Take(5).ToList();
                foreach (var sp in spList)
                {
                    db.ChiTietHoaDons.Add(new ChiTietHoaDon
                    {
                        MaHD = hd.MaHD,
                        MaSP = sp.MaSP,
                        SoLuong = 2,
                        DonGia = sp.GiaBan
                    });
                    hd.TongTien += 2 * sp.GiaBan;
                }
                db.SaveChanges();
            }

            // ======= LỊCH SỬ HOẠT ĐỘNG =======
            if (!db.LichSuHoatDongs.Any())
            {
                var nv = db.NhanViens.First();
                db.LichSuHoatDongs.Add(new LichSuHoatDong
                {
                    LoaiHoatDong = "Khởi tạo dữ liệu mẫu",
                    MaNV = nv.MaNV,
                    ChiTiet = "Thêm dữ liệu mẫu cho tất cả bảng"
                });
                db.SaveChanges();
            }

        }
    }
}
