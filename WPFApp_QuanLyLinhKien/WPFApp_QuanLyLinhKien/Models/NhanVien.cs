using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp_QuanLyLinhKien.Models
{
    public class NhanVien
    {
        [Key]
        public int MaNV { get; set; }

        [Required, StringLength(100)]
        public string TenNV { get; set; }

        public string DiaChi { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();
        public ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
        public ICollection<LichSuHoatDong> LichSuHoatDongs { get; set; } = new List<LichSuHoatDong>();
        public Account Account { get; set; }
    }
}
