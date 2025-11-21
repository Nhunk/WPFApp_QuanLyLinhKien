using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WPFApp_QuanLyLinhKien.Models;

namespace WPFApp_QuanLyLinhKien.Models
{
    public class SanPham
    {
        [Key]
        public int MaSP { get; set; }

        [ForeignKey(nameof(LoaiSanPham))]
        public int? MaLoai { get; set; }
        public LoaiSanPham LoaiSanPham { get; set; }

        [Required, StringLength(200)]
        public string TenSP { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal GiaBan { get; set; }

        public string HinhAnh { get; set; }

        public string MoTa { get; set; }

        public Kho Kho { get; set; }

        public ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
    }
}
