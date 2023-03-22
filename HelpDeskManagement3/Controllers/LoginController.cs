using Model;
using Service.Class;
using Service.Entities;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HelpDeskManagement3.Controllers
{

    public class LoginController : Controller
    {

        ILogin _login = null;
        public LoginController()
        {
            _login = new Login();
        }
        public ActionResult Index()
        {
       
            return View();
        } 
        [HttpPost]
        public ActionResult Index(LoginViewModel user)
        {
            if (ModelState.IsValid == true)
            {
                LoginViewModel obj = new LoginViewModel();
              
                obj = _login.GetinfoByUserCredentials(user.Email, user.Password);
          
                if (obj == null)
                {
                    ViewBag.ErrorMessage = "Login Failed!";
                    return View();
                }
                else
                {
                    Session["Id"] = obj.Id;
                    Session["username"] = obj.UserName;
                    Session["email"] = user.Email;
                    if (obj.RoleType == "admin" && obj.Email==user.Email && obj.Password==user.Password)
                    {  
                        return RedirectToAction("ShowAdminDashboard", "Dashboard");
                    }
                    else if(obj.RoleType == "user" && obj.Email == user.Email && obj.Password == user.Password)
                    {                    
                        return RedirectToAction("ShowUserDashboard", "UserDashboard");                    
                    }
                    else
                    {
                        return View("Error");
                    }
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}