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
        
        [HttpPost]
        public ActionResult LogOn(LogOnModel logOnModel)
        {
            Membership.ValidateUser(logOnModel.Login, logOnModel.Password);
            return null;
        }
    }
}
