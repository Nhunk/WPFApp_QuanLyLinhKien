using System.Windows;
using System.Windows.Controls;
using WPFApp_QuanLyLinhKien.Views;

namespace WPFApp_QuanLyLinhKien.Views.Staff
{
    public partial class StaffHomeView : Window
    {
        public StaffHomeView()
        {
            InitializeComponent();
            Loaded += StaffHomeView_Loaded;
        }

        private void StaffHomeView_Loaded(object sender, RoutedEventArgs e)
        {
            if (StaffListBox != null && StaffListBox.Items.Count > 0)
            {
                StaffListBox.SelectedIndex = 0;
                StaffFrame.Navigate(new StaffDashBoardView());
            }
        }

        private void bt_DangXuat(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
            "Bạn có chắc muốn đăng xuất không?",
            "Xác nhận đăng xuất",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question
            );

            // Nếu chọn Yes → đăng xuất
            if (result == MessageBoxResult.Yes)
            {
                var loginWindow = new DangNhapView();
                loginWindow.Show();
                this.Close();
            }
        }

        private void lb_Staff(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox == null) return;

            var selectedItem = listBox.SelectedItem as ListBoxItem;
            if (selectedItem == null) return;

            string selected = (selectedItem.Content ?? "").ToString().Trim();

            switch (selected)
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
