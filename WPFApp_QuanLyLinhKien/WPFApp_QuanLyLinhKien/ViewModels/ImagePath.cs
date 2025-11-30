using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace WPFApp_QuanLyLinhKien.ViewModels
{
    public class ImagePath : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            string relativePath = value.ToString();

            // Lấy đường dẫn tuyệt đối
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            return fullPath;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
