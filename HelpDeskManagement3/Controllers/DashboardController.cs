using Model;
using Service.Class;
using Service.Entities;
using Service.Interface;
using Service.Manager;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace HelpDeskManagement3.Controllers
{
    public class DashboardController : Controller
    {
        IUser _UserManager = null;
        ITicket _TicketManager = null;
        IDepartment _DepartmentManager = null;
        public DashboardController()
        {
            _UserManager = new UserManager();
            _DepartmentManager=new DepartmentManager();
            _TicketManager = new TicketManager();
        }
        // GET: Dashboard
        HelpdeskEntities admin = new HelpdeskEntities();

        public ActionResult ShowAdminDashboard()
        {
            return View();
        }

        public ActionResult Showticketstable()
        {
            var data =_TicketManager.GetAllTicket();
            return View(data);
        }

        public ActionResult EditTickets(int id)
        {
            ViewBag.dptdata =_DepartmentManager.GetAllDepartment();
            var ticketdata = _TicketManager.GetTicketById(id);
            return View(ticketdata);
        }

        [HttpPost]

        public ActionResult EditTickets(TicketTable t)
        {
            int deptId = 0;
            if (!t.Dept_List.Contains("Select a Department"))
                deptId = Convert.ToInt32(t.Dept_List);
            var department = _DepartmentManager.GetDepartmentById(deptId);
            if (department!=null)
            {
                t.Dept_List = department.Dept_Desc;
                t.Dep_ID = department.Dep_ID;
            }

          
            int a = _TicketManager.UpdateTicket(t);
            if (a > 0)
            {
                TempData["UpdateMessage"] = "<script>alert('Updated !!)</script>";
                return RedirectToAction("Showticketstable");
            }
            else if (a <= 0)
            {
                TempData["UpdateMessage"] = "<script>alert('Not Updated !!)</script>";
            }
            return View();
        }

        public ActionResult ShowUser()
        {
            string message = TempData["Notification"] as string;
            ViewBag.Message = message;

            var data = _UserManager.GetAllUser();
            return View(data);
            //var people = _CreateUser.GetAllUser();
            //return View(people);
        }
        public ActionResult Create()
        {

            ViewBag.dpt = admin.Departments.ToList();
            ViewBag.role = admin.RoleTypes.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserTable newUser)
        {

            var roleType = admin.RoleTypes.Where(m => m.RoleTypeID == newUser.RoleTypeID).FirstOrDefault();
            if (roleType!=null)
            {

                newUser.Roletype = roleType.RoleType_Disc;

                int a = _UserManager.CreateUser(newUser);
                if (a > 0)
                {
                    TempData["Notification"] ="New Ticket Created";
                    Session["InsertMessage"] = "<script>alert('Inserted !!)</script>";
                    //ViewBag.Message = "Action submitted successfully!";
                    return RedirectToAction("ShowAdminDashboard");
                }
                else
                {
                    Session["InsertMessage"] = "<script>alert('not inserted !!)</script>";

                }
            }
            else
            {
                return View("Select Role");
            }
            return View();




        }
        public ActionResult Edit(int id)
        {
            ViewBag.role = admin.RoleTypes.ToList();
            var row = _UserManager.GetUserById(id);


            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(UserTable newUser)
        {
            var roleType = admin.RoleTypes.Where(m => m.RoleTypeID == newUser.RoleTypeID).FirstOrDefault();
            newUser.Roletype = roleType.RoleType_Disc;

            int a = _UserManager.UpdateUser(newUser);
            if (a > 0)
            {
                TempData["UpdateMessage"] = "<script>alert('Updated !!)</script>";
                return RedirectToAction("ShowUser");
            }
            else
            {
                TempData["UpdateMessage"] = "<script>alert('Not Updated !!)</script>";
            }

            return View();
        }
        public ActionResult Delete(int id)
        {
            var Deleterow = admin.UserTables.Where(model => model.Id == id).FirstOrDefault();

            return View(Deleterow);
        }
        [HttpPost]
        public ActionResult Delete(UserTable deleteUser)
        {
           // admin.Entry(deleteUser).State = EntityState.Deleted;
            int a = _UserManager.DeleteUser(deleteUser.Id);
            if (a > 0)
            {
                TempData["DeleteMessage"] = "<script>alert('Data is Deleted !!)</script>";
                return RedirectToAction("ShowUser");
            }
            else
            {
                TempData["DeleteMessage"] = "<script>alert('Not Deleted !!)</script>";
            }


            return View();
        }




        public ActionResult TicketDelete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TicketDelete(int id)
        {
           
            int a = _TicketManager.DeleteTicket(id);
            if (a > 0)
            {
                TempData["DeleteMessage"] = "<script>alert('Data is Deleted !!)</script>";
                return RedirectToAction("Showticketstable");
            }
            else
            {
                TempData["DeleteMessage"] = "<script>alert('Not Deleted !!)</script>";
            }


            return View();
        }


    }
}