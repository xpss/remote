using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DiplomApp.Helpers;
using DiplomApp.Interfaces;
using DiplomApp.Models;
using DiplomApp.Services;
using Ninject;

namespace DiplomApp.Controllers
{
    public class HomeController : Controller
    {
        PointService pointService = new PointService(BinderHelper.iKernel.Get<IPoint>());
        CredentialsService credentialsService = new CredentialsService(BinderHelper.iKernel.Get<ICredentials>());
        UserService userService = new UserService(BinderHelper.iKernel.Get<IUser>());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [Authorize]
        public ActionResult Position()
        {
            return View();
        }

        [HttpPost]
        public Action SetData(Point p)
        {
            PointList.SetNew(p);
            pointService.Add(new PointModel()
                                 {
                                     X = p.X,
                                     Y = p.Y,
                                     Z = p.Z,
                                     Xv = 0,
                                     Yv = 0,
                                     Zv = 0
                                 });
            return null;
        }

        public JsonResult GetData()
        {
            return Json(PointList.Point, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult History()
        {
            IEnumerable<PointModel> points = pointService.GetAllPoint(credentialsService.GetCurrentUserId(User.Identity.Name));
            return View(points);
        }

        [Authorize]
        public ActionResult Chart()
        {
            return View();
        }

        public JsonResult GetPoints()
        {
            return Json(pointService.GetAllPoint(credentialsService.GetCurrentUserId(User.Identity.Name)), JsonRequestBehavior.AllowGet);
        } 

    }
}
