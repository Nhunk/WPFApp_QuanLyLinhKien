using System.Configuration;
using System.Data;
using System.Windows;
using WPF_LINHKIEN_PC.CoSoDuLieu;
using WPFApp_QuanLyLinhKien.Database;

namespace WPFApp_QuanLyLinhKien
{

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using var db = new AppDbContext();
            Input_Sample.Seed(db); 
        }
    }

}
