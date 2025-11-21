using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp_QuanLyLinhKien.Models
{
    public class HoaDon
    {

        [Key]
        public int MaHD { get; set; }

        [ForeignKey(nameof(KhachHang))]
        public int? MaKH { get; set; }
        public KhachHang KhachHang { get; set; }

        [ForeignKey(nameof(NhanVien))]
        public int? MaNV { get; set; }
        public NhanVien NhanVien { get; set; }

        public DateTime NgayLap { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TongTien { get; set; }

        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    }
}
