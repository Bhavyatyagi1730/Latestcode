using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDeskManagement3.Controllers
{

    public class TicketController : Controller
    {
        // GET: Ticket
        HelpdeskEntities userData = new HelpdeskEntities();
        public ActionResult ShowTicket()
        {
            var data = userData.TicketTables.ToList();
            return View(data);
        }

        public ActionResult TicketCreate()
        {
            return View();
        }

        [HttpPost]

   
  
        public ActionResult AdminEditStatus(int id)
        {
            var row = userData.TicketTables.Where(model => model.Ticket_Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult AdminEditStatus(UserTable newTicket)
        {
            if (ModelState.IsValid == true)
            {
                userData.Entry(newTicket).State = EntityState.Modified;
                int a = userData.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Updated !!)</script>";
                    return RedirectToAction("Showticketstable");
                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('Not Updated !!)</script>";
                }
            }
            return View();
        }
        public ActionResult AdminDeleteTask(int id)
        {
            var Deleterow = userData.TicketTables.Where(model => model.Ticket_Id == id).FirstOrDefault();
            return View(Deleterow);
        }
        [HttpPost]
        public ActionResult AdminDeleteTask(UserTable deleteUser)
        {
           userData.Entry(deleteUser).State = EntityState.Deleted;
            int a = userData.SaveChanges();
            if (a > 0)
            {
                TempData["DeleteMessage"] = "<script>alert('Data is Deleted !!)</script>";
                return RedirectToAction("ShowTicket");
            }
            else
            {
                TempData["DeleteMessage"] = "<script>alert('Not Deleted !!)</script>";
            }


            return View();
        }
        public ActionResult AdminShowDetails(int id)
        {
            var row = userData.TicketTables.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

        public ActionResult OpenTicket()
        {
            int statusId = 0;
            var openticketview = userData.TicketTables.Where(model => model.Status == statusId).ToList();
            return View(openticketview);
        }
        public ActionResult ProgressTicket()
        {
            int statusId = 1;
            var tickets = userData.TicketTables.Where(model => model.Status == statusId).ToList();
            return View(tickets);

        }
        public ActionResult CloseTicket()
        {
            int statusId = 2;
            var ticketview = userData.TicketTables.Where(model => model.Status == statusId).ToList();
            return View(ticketview);
        }
    }
    
}