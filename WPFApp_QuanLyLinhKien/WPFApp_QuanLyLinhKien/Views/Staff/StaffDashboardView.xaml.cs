using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFApp_QuanLyLinhKien.Views.Login;

namespace WPFApp_QuanLyLinhKien.Views.Staff
{

    public partial class StaffDashboardView : Window
    {
        public StaffDashboardView()
        {
            InitializeComponent();
        }

        private void bt_DangXuat(object sender, RoutedEventArgs e)
        {
            var loginWindow = new DangNhapView();
            loginWindow.Show();
            this.Close();
        }
    }
}
