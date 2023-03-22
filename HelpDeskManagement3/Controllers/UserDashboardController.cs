using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Net.Mail;
using System.Web.Mail;
using System.Net;
using Service.Interface;
using Service.Class;
using System.Net.Sockets;

namespace HelpDeskManagement3.Controllers
{
    public class UserDashboardController : Controller
    {
        // GET: UserDashboard
        HelpdeskEntities userData = new HelpdeskEntities();

        IEmail _email = null;

        public UserDashboardController()
        {
            _email = new Email();
        }

        public ActionResult ShowUserDashboard()
        {
            return View();
        }

        public ActionResult UserDeatils()
        {
            //if (Session["email"] == null)
            //{
            //    return RedirectToAction("Index","Login");
            //}
            int value = Convert.ToInt32(Session["Id"]);
            var data = userData.TicketTables.Where(t => t.Id == value).ToList();
           
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Create(TicketTable newUser)
        {
            if (ModelState.IsValid == true)
            {
                int value = Convert.ToInt32(Session["Id"]);
                string name = (string)Session["username"];
                newUser.Id = value;
                newUser.CreatedBy = name;
                userData.TicketTables.Add(newUser);
                _email.SendEmail("abhishek.gautam@credextechnology.com", "A new ticket with ID has been created !", "A new ticket with ID has been created.");
                int a = userData.SaveChanges();
                TempData["AdminUpdate"] = "New Ticket Created by User";
                
                if (a > 0)
                {
                    TempData["Message"] = "Ticket Created Successfully";

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "No Ticket Created";
                }

            }
            return View();
        }


        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var product = userData.TicketTables.Find(id);
            userData.TicketTables.Remove(product);
            int a = userData.SaveChanges();
            if (a > 0)
            {
                TempData["DeleteMessage"] = "<script>alert('Data is Deleted !!)</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["DeleteMessage"] = "<script>alert('Not Deleted !!)</script>";
            }
            return View();
        }
    }
}