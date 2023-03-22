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
    public class DepartmentManager : IDepartment
    {
        HelpdeskEntities db1 = new HelpdeskEntities();

        public Department GetDepartmentById(int id)
        {
            var row = db1.Departments.Where(model => model.Dep_ID== id).FirstOrDefault();
            return row;
        }

        public int UpdateDepartment(Department newDepartment)
        {
            db1.Entry(newDepartment).State = EntityState.Modified;
            return db1.SaveChanges();
        }

        public int CreateDepartment(Department newDepartment)
        {
            db1.Departments.Add(newDepartment);
            return db1.SaveChanges();
        }

        public int DeleteDepartment(int Id)
        {
            Department product = db1.Departments.Find(Id);
            db1.Departments.Remove(product);
            return db1.SaveChanges();
        }
        public int DeleteDepartment(Department product)
        {
            db1.Departments.Remove(product);
            return db1.SaveChanges();
        }


        public List<Department> GetAllDepartment()
        {
            var data = db1.Departments.ToList();

            return data;
        }

    }
}
