using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using DiplomApp.Models;

namespace DiplomApp.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult LogOn()
        {
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
        [HttpPost]
        public ActionResult LogOn(LogOnModel logOnModel)
        {
            if (Membership.ValidateUser(logOnModel.Login, logOnModel.Password))
            {
                FormsAuthentication.SetAuthCookie(logOnModel.Login, logOnModel.RememberMe);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
