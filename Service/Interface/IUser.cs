using Service.Entities;
using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUser
    {
        List<UserTable> GetAllUser();
        UserTable GetUserById(int id);
        int CreateUser(UserTable product);
        int UpdateUser(UserTable product);
        int DeleteUser(int Id);
        int DeleteUser(UserTable product);


    }
}
