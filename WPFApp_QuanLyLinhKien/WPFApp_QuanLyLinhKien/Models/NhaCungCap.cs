using System.ComponentModel.DataAnnotations;

namespace WPFApp_QuanLyLinhKien.Models
{
    public class NhaCungCap
    {
        [Key]
        public int MaNCC { get; set; }

        [Required, StringLength(200)]
        public string TenNCC { get; set; }

        public string DiaChi { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();
    }
}
