using System.Windows;
using System.Windows.Controls;

using WPFApp_QuanLyLinhKien.Views.Login;

namespace WPFApp_QuanLyLinhKien.Views.Staff
{

    public partial class StaffHomeView : Window
    {
        public StaffHomeView()
        {
            InitializeComponent();
            Loaded += StaffHomeView_Loaded;
        }


        private void StaffHomeView_Loaded(object? sender, RoutedEventArgs e)
        {
            if (MainMenuListBox?.Items.Count > 0)
            {
                MainMenuListBox.SelectedIndex = 0;
                StaffFrame.Navigate(new StaffDashBoardView()); // Mặc định hiển thị Dashboard
            }
        }

        private void bt_DangXuat(object sender, RoutedEventArgs e)
        {
            var loginWindow = new DangNhapView();
            loginWindow.Show();
            this.Close();
        }

        private void lb_Staff(object sender, SelectionChangedEventArgs e)
        {
            if (sender is not ListBox listBox) return;
            if (listBox.SelectedItem is not ListBoxItem selectedItem) return;

            string selectedItemText = (selectedItem.Content ?? string.Empty).ToString();

            switch (selectedItemText)
            {
                case "Sản phẩm":
                    StaffFrame.Navigate(new StaffSanPhamView());
                    break;
                case "Đơn hàng":
                    StaffFrame.Navigate(new StaffDonHangView());
                    break;
                case "Khách hàng":
                    StaffFrame.Navigate(new StaffKhachHangView());
                    break;
                case "Dashboard":
                    StaffFrame.Navigate(new StaffDashBoardView());
                    break;
            }
        }
    }
}
