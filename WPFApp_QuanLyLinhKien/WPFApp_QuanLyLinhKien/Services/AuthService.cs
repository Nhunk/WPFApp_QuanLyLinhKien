using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp_QuanLyLinhKien.Models;
using WPFApp_QuanLyLinhKien.Services.Session;

namespace WPFApp_QuanLyLinhKien.Services
{
    public class AuthService
    {
        QLLKEntities _db = new QLLKEntities();

        public bool Login(string username, string password)
        {
            var user = _db.Accounts
                          .FirstOrDefault(x => x.Username == username
                                            && x.Password == password);

            if (user == null)
                return false;

            AppSession.CurrentUserID = user.AccountID;
            AppSession.CurrentUserName = user.Username;

            AppSession.CurrentRole = user.Role == "Admin"
                                    ? UserRole.Admin
                                    : UserRole.Staff;

            AppSession.LoginTime = DateTime.Now;

            return true;
        }
    }

}
