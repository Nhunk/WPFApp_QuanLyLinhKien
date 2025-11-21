using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WPFApp_QuanLyLinhKien.Models;

namespace WPFApp_QuanLyLinhKien.Models
{
    public class LoaiSanPham
    {
        [Key]
        public int MaLoai { get; set; }

        [Required, StringLength(100)]
        public string TenLoai { get; set; }

        public ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
    }
}