using Service.Entities;
using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IDepartment
    {
        List<Department> GetAllDepartment();
        Department GetDepartmentById(int id);
        int CreateDepartment(Department product);
        int UpdateDepartment(Department product);
        int DeleteDepartment(int Id);
        int DeleteDepartment(Department product);


    }
}
