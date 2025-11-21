using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp_QuanLyLinhKien.Models
{
    public class ChiTietPhieuNhap
    {
        [ForeignKey(nameof(PhieuNhap))]
        public int MaPN { get; set; }
        public PhieuNhap PhieuNhap { get; set; }

        [ForeignKey(nameof(SanPham))]
        public int MaSP { get; set; }
        public SanPham SanPham { get; set; }

        public int SoLuong { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal GiaNhap { get; set; }
    }
}
