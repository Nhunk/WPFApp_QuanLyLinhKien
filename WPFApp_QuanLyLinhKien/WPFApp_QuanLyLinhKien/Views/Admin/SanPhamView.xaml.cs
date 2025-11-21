using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;


namespace WPFApp_QuanLyLinhKien.Views.Admin
{
    /// <summary>
    /// Interaction logic for SanPhamView.xaml
    /// </summary>
    public partial class SanPhamView : Window
    {
        public SanPhamView()
        {
            InitializeComponent();
            this.DataContext = new SanPhamViewModel();
        }
    }
}
