using System.ComponentModel.DataAnnotations;

namespace WPFApp_QuanLyLinhKien.Models
{
    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }

        [Required, StringLength(100)]
        public string TenKH { get; set; }

        public string DiaChi { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    }
}
