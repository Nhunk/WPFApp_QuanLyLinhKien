using System;
using System.Windows;
using System.Windows.Controls;
using WPFApp_QuanLyLinhKien.Views;

namespace WPFApp_QuanLyLinhKien.Views.Admin
{
    public partial class AdminHomeView : Window
    {
        public AdminHomeView()
        {
            InitializeComponent();
            Loaded += AdminHomeView_Loaded;
        }

        private void AdminHomeView_Loaded(object sender, RoutedEventArgs e)
        {
            if (AdminListBox != null && AdminListBox.Items.Count > 0)
            {
                AdminListBox.SelectedIndex = 0;               // Chọn mục đầu tiên
                AdminFrame.Navigate(new AdminDashBoardView());    // Hiển thị Dashboard mặc định
            }
        }

        private void Bt_DangXuat(object sender, RoutedEventArgs e)
        {
            var loginWindow = new DangNhapView();

            loginWindow.Show();
            this.Close();
        }

        private void lb_Admin(object sender, SelectionChangedEventArgs e)
        {
            var item = AdminListBox?.SelectedItem as ListBoxItem;
            if (item == null) return;


            string selected = (item.Content ?? "").ToString().Trim();

            switch (selected)
            {
                case "Dashboard":
                    AdminFrame.Navigate(new AdminDashBoardView());
                    break;

                case "Sản phẩm":
                    AdminFrame.Navigate(new QLSanPhamView());
                    break;

                case "Danh mục":
                    AdminFrame.Navigate(new QLDanhMucView());
                    break;

                case "Nhà cung cấp":
                    AdminFrame.Navigate(new QLNhaCungCapView());
                    break;

                case "Đơn hàng":
                    AdminFrame.Navigate(new QLDonHangView());
                    break;

                case "Khách hàng":
                    AdminFrame.Navigate(new QLKhachHangView());
                    break;

                case "Nhân viên":
                    AdminFrame.Navigate(new QLNhanVienView());
                    break;

                case "Báo cáo":
                    AdminFrame.Navigate(new BaoCaoView());
                    break;

                default:
                    break;
            }
        }
    }
}
