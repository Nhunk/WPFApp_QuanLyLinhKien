using System.Windows;
using WPFApp_QuanLyLinhKien.Models;
using WPFApp_QuanLyLinhKien.Services;
using WPFApp_QuanLyLinhKien.Services.Session;
using WPFApp_QuanLyLinhKien.Views.Admin;
using WPFApp_QuanLyLinhKien.Views.Staff;

namespace WPFApp_QuanLyLinhKien.Views
{
    public partial class DangNhapView : Window
    {

        public DangNhapView()
        {
            InitializeComponent();
        }

        private void Bt_DangNhap(object sender, RoutedEventArgs e)
        {
            var auth = new AuthService();

            bool success = auth.Login(txtUsername.Text, txtPassword.Password);

            if (!success)
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                return;
            }

            if (AppSession.CurrentRole == UserRole.Admin)
                new AdminHomeView().Show();
            else
                new StaffHomeView().Show();

            this.Close();
        }
        private void Bt_Thoat(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
