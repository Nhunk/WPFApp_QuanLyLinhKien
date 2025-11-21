using System.Windows;
using WPFApp_QuanLyLinhKien.Database;

namespace WPFApp_QuanLyLinhKien
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var db = new AppDbContext())
            {
                // Tạo database và nhập dữ liệu mẫu
                Input.Seed(db);
            }
        }
    }
}
