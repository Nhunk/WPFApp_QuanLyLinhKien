using System.Collections.ObjectModel;
using WPFApp_QuanLyLinhKien.Models;
using WPFApp_QuanLyLinhKien.Database;
using System.Linq;

public class SanPhamViewModel
{
    public ObservableCollection<SanPham> DanhSachSanPham { get; set; }

    public SanPhamViewModel()
    {
        using (var db = new AppDbContext())
        {
            var list = db.SanPhams.ToList();
            DanhSachSanPham = new ObservableCollection<SanPham>(list);
        }
    }
}
