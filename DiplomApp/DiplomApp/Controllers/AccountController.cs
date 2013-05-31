using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

using DiplomApp.Models;
using DiplomApp.Services;
using DiplomApp.Helpers;
using DiplomApp.Interfaces;
using Ninject;
using DiplomApp.Converters;

namespace DiplomApp.Controllers
{
    public class AccountController : Controller
    {
        CredentialsService credentialsService = new CredentialsService(BinderHelper.iKernel.Get<ICredentials>());
        UserService userService = new UserService(BinderHelper.iKernel.Get<IUser>());

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegisterModel registerModel)
        {
            try
            {
                int userId = userService.Add(ModelConverters.RegisterModelToUserModel(registerModel));
                credentialsService.Add(userId, registerModel.Login, registerModel.Password);
                return RedirectToAction("LogOn", "Account");
            }
            catch (Exception)
            {
                ModelState.AddModelError("Error", "Hello");
                return View();
            }
            
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
            ModelState.AddModelError("Error", "Hello");
            return View();
        }
    }
}
