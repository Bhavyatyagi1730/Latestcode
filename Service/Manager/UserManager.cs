using Model;
using Service.Entities;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Service.Manager
{
   public  class UserManager : IUser
    {
         HelpdeskEntities db1 = new HelpdeskEntities();
        
            LoginViewModel user = new LoginViewModel();
        public UserTable GetUserById(int id)
        {
           // LoginViewModel user = new LoginViewModel();
            var row = db1.UserTables.Where(model=>model.Id== id).FirstOrDefault();
           // user.Id= row.Id;
            return row;
        }

        public int UpdateUser(UserTable newUser)
        {
            db1.Entry(newUser).State = EntityState.Modified;
          return  db1.SaveChanges();
        }

       public int CreateUser(UserTable newUser)
        {
            db1.UserTables.Add(newUser);
          return  db1.SaveChanges();
        }

       public int DeleteUser(int Id)
        {
            UserTable product = db1.UserTables.Find(Id);
            db1.UserTables.Remove(product);
           return db1.SaveChanges();
        }
        public int DeleteUser(UserTable product)
        {
            db1.UserTables.Remove(product);
           return db1.SaveChanges();
        }


        public List<UserTable> GetAllUser()
        {
            var data = db1.UserTables.ToList();
            return data;
        }


        //public void DeleteProduct(int id)
        //{
        //    LoginViewModel product = db1.HelpDesks.Find(Id);
        //    _context.Products.Remove(product);
        //    _context.SaveChanges();
        //}





    }
}
