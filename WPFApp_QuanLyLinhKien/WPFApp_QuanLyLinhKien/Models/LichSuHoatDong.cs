using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFApp_QuanLyLinhKien.Models
{
    public class LichSuHoatDong
    {
        [Key]
        public int ID { get; set; }

        public string LoaiHoatDong { get; set; }

        [ForeignKey(nameof(NhanVien))]
        public int? MaNV { get; set; }
        public NhanVien NhanVien { get; set; }

        public DateTime ThoiGian { get; set; } = DateTime.Now;

        public string ChiTiet { get; set; }
    }
}
