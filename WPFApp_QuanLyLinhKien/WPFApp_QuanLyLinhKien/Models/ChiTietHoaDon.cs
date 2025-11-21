using System.ComponentModel.DataAnnotations.Schema;

namespace WPFApp_QuanLyLinhKien.Models
{
    public class ChiTietHoaDon
    {
        [ForeignKey(nameof(HoaDon))]
        public int MaHD { get; set; }
        public HoaDon HoaDon { get; set; }

        [ForeignKey(nameof(SanPham))]
        public int MaSP { get; set; }
        public SanPham SanPham { get; set; }

        public int SoLuong { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DonGia { get; set; }
    }
}
