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
using WPFApp_QuanLyLinhKien.Database;

namespace WPFApp_QuanLyLinhKien.Views.Login
{ 
    public partial class DangNhapView : Window
    {
        public DangNhapView()
        {
            InitializeComponent();
        }

        private void Button_Thoat(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_DangNhap(object sender, RoutedEventArgs e)
        {

            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Password.Trim();
            var db = new AppDbContext();
            var account = db.Accounts
                    .FirstOrDefault(a => a.Username == txtUsername.Text &&
                                         a.PasswordHash == txtPassword.Password);

            if (account == null)
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                return;
            }

            // Nếu đăng nhập đúng → kiểm tra role
            if (account.Role == "Admin")
            {
                var adminWindow = new Views.Admin.AdminDashboardView();
                adminWindow.Show();
                this.Close();
            }
            else if (account.Role == "Staff")
            {
                var staffWindow = new Views.Staff.StaffDashboardView();
                staffWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Không có quyền truy cập!");
            }
        }
    }
    
}
