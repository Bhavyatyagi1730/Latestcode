using Model;
using Service.Entities;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Class
{
    public class Login : ILogin
    {
        HelpdeskEntities db1 = new HelpdeskEntities();  
        public LoginViewModel GetinfoByUserCredentials(string Email, string Password)
        {
            LoginViewModel user = new LoginViewModel();
              UserTable roledata = db1.UserTables.Where(m => m.Email == Email && m.Password == Password).FirstOrDefault();
            if (roledata != null)
            {
                user.Id = roledata.Id;
                user.Email = roledata.Email;
                user.Password = roledata.Password;
                user.RoleType = roledata.Roletype;
                user.UserName = roledata.UserName;
            }
            return user;

        }
   


    }
}
