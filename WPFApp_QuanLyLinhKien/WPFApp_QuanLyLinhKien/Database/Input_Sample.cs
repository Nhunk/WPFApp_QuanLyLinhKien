using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_LINHKIEN_PC.CoSoDuLieu;
using WPFApp_QuanLyLinhKien.Models;

namespace WPFApp_QuanLyLinhKien.Database
{
    public class Input_Sample
    {
        public static void Seed(AppDbContext db)
        {
            db.Database.EnsureCreated();

            if (!db.NhanViens.Any())
            {
                var nv1 = new NhanVien { TenNV = "Admin Hệ Thống", Email = "admin@example.com" };
                db.NhanViens.Add(nv1);
                db.SaveChanges();

                db.Accounts.Add(new Account
                {
                    Username = "admin",
                    PasswordHash = "123", // production: lưu hash thật
                    Role = "Admin",
                    MaNV = nv1.MaNV
                });

                var nv2 = new NhanVien { TenNV = "Nhan Vien 1", Email = "staff@example.com" };
                db.NhanViens.Add(nv2);
                db.SaveChanges();

                db.Accounts.Add(new Account
                {
                    Username = "staff",
                    PasswordHash = "123",
                    Role = "Staff",
                    MaNV = nv2.MaNV
                });

                db.SaveChanges();
            }

            if (!db.LoaiSanPhams.Any())
            {
                var loai1 = new LoaiSanPham { TenLoai = "RAM" };
                var loai2 = new LoaiSanPham { TenLoai = "CPU" };
                db.LoaiSanPhams.AddRange(loai1, loai2);
                db.SaveChanges();

                var sp1 = new SanPham { TenSP = "Kingston DDR4 8GB", GiaBan = 350000, MaLoai = loai1.MaLoai };
                var sp2 = new SanPham { TenSP = "Intel Core i5", GiaBan = 4200000, MaLoai = loai2.MaLoai };
                db.SanPhams.AddRange(sp1, sp2);
                db.SaveChanges();

                db.Khos.Add(new Kho { MaSP = sp1.MaSP, TonKho = 10, TonToiThieu = 3 });
                db.Khos.Add(new Kho { MaSP = sp2.MaSP, TonKho = 5, TonToiThieu = 2 });
                db.SaveChanges();
            }
        }
    }
}
