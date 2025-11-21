using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFApp_QuanLyLinhKien.Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(255)]
        public string PasswordHash { get; set; }

        [Required, StringLength(20)]
        public string Role { get; set; } // "Admin" or "Staff"

        [ForeignKey(nameof(NhanVien))]
        public int? MaNV { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
