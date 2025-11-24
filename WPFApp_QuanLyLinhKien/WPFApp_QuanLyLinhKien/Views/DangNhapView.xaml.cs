using System.Windows;
using WPFApp_QuanLyLinhKien.Database;

namespace WPFApp_QuanLyLinhKien.Views.Login
{ 
    public partial class DangNhapView : Window
    {
        public DangNhapView()
        {
            InitializeComponent();
        }

        private void Bt_Thoat(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Bt_DangNhap(object sender, RoutedEventArgs e)
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
            else
            {
                MessageBox.Show("Không có quyền truy cập!");
            }
        }
    }
    
}
