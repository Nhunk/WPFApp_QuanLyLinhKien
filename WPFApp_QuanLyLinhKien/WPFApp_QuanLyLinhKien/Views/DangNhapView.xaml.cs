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
            string user = txtUsername.Text.Trim().ToLower();
            string pass = txtPassword.Password.Trim().ToLower();

            var db = new QLLKEntities();
            var account = db.Accounts
                    .FirstOrDefault(a => a.Username == txtUsername.Text &&
                                         a.Password == txtPassword.Password);
            if (account == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(account.Role == "Admin")
            {
                var adminWindow = new Views.Admin.AdminHomeView();
                adminWindow.Show();
                this.Close();
            }
            else if (account.Role == "Staff")
            {
                var staffWindow = new Views.Staff.StaffHomeView();
                staffWindow.Show();
                this.Close();
            }
        }

        private void Bt_Thoat(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
