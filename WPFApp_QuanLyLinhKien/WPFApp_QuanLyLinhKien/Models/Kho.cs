using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFApp_QuanLyLinhKien.Models
{
    public class Kho
    {
        [Key, ForeignKey(nameof(SanPham))]
        public int MaSP { get; set; }

        public int TonKho { get; set; } = 0;

        public int TonToiThieu { get; set; } = 5;

        public SanPham SanPham { get; set; }
    }
}
