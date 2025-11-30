using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp_QuanLyLinhKien.Models;
using WPFApp_QuanLyLinhKien.Services.Session;

namespace WPFApp_QuanLyLinhKien.ViewModels
{

    public class QLSanPhamViewModel : INotifyPropertyChanged
    {
    public bool CanAdd => AppSession.CurrentRole == UserRole.Admin;
    public bool CanDelete => AppSession.CurrentRole == UserRole.Admin;
    public bool CanEdit => AppSession.CurrentRole == UserRole.Admin;

        public ObservableCollection<SanPham> Products { get; set; }
        public QLSanPhamViewModel()
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            using (var db = new QLLKEntities())
            {
                Products = new ObservableCollection<SanPham>(db.SanPhams.ToList());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
