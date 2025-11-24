using System;
using System.Windows;
using System.Windows.Controls;
using WPFApp_QuanLyLinhKien.Views.Login;

namespace WPFApp_QuanLyLinhKien.Views.Admin
{
    public partial class AdminHomeView : Window
    {
        public AdminHomeView()
        {
            InitializeComponent();
            Loaded += AdminHomeView_Loaded;
        }

        private void AdminHomeView_Loaded(object? sender, RoutedEventArgs e)
        {
            if (MainMenuListBox?.Items.Count > 0)
            {
                MainMenuListBox.SelectedIndex = 0;
                AdminFrame.Navigate(new AdminDashBoardView()); // Mặc định hiển thị Dashboard
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
            var listBox = sender as ListBox ?? MainMenuListBox;
            if (listBox?.SelectedItem is not ListBoxItem selectedItem) return;

            string key = (selectedItem.Content ?? string.Empty).ToString();
            switch (key)
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