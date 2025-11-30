using System;
using WPFApp_QuanLyLinhKien.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp_QuanLyLinhKien.Services.Session
{
    public static class AppSession
    {
        
            public static int CurrentUserID { get; set; }
            public static string CurrentUserName { get; set; }
            public static UserRole CurrentRole { get; set; }
            public static DateTime LoginTime { get; set; }
        
    }
}
