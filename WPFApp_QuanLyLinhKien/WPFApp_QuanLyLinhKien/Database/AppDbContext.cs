using Microsoft.EntityFrameworkCore;
using WPFApp_QuanLyLinhKien.Models;

namespace WPFApp_QuanLyLinhKien.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<Kho> Khos { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<LichSuHoatDong> LichSuHoatDongs { get; set; }

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=QuanLyLinhKien;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // composite keys
            modelBuilder.Entity<ChiTietPhieuNhap>()
                .HasKey(c => new { c.MaPN, c.MaSP });

            modelBuilder.Entity<ChiTietHoaDon>()
                .HasKey(c => new { c.MaHD, c.MaSP });

            // relationships
            modelBuilder.Entity<SanPham>()
                .HasOne(s => s.LoaiSanPham)
                .WithMany(l => l.SanPhams)
                .HasForeignKey(s => s.MaLoai)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Kho>()
                .HasKey(k => k.MaSP);

            modelBuilder.Entity<Kho>()
                .HasOne(k => k.SanPham)
                .WithOne(s => s.Kho)
                .HasForeignKey<Kho>(k => k.MaSP)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PhieuNhap>()
                .HasOne(p => p.NhaCungCap)
                .WithMany(n => n.PhieuNhaps)
                .HasForeignKey(p => p.MaNCC)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<PhieuNhap>()
                .HasOne(p => p.NhanVien)
                .WithMany(nv => nv.PhieuNhaps)
                .HasForeignKey(p => p.MaNV)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<HoaDon>()
                .HasOne(h => h.KhachHang)
                .WithMany(k => k.HoaDons)
                .HasForeignKey(h => h.MaKH)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<HoaDon>()
                .HasOne(h => h.NhanVien)
                .WithMany(nv => nv.HoaDons)
                .HasForeignKey(h => h.MaNV)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.NhanVien)
                .WithOne(nv => nv.Account)
                .HasForeignKey<Account>(a => a.MaNV)
                .OnDelete(DeleteBehavior.SetNull);

            // default values
            modelBuilder.Entity<PhieuNhap>()
                .Property(p => p.NgayNhap)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<HoaDon>()
                .Property(h => h.NgayLap)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<LichSuHoatDong>()
                .Property(l => l.ThoiGian)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
