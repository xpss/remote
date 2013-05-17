using DiplomApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiplomApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Position()
        {
            return View();
        }

        [HttpPost]
        public Action SetData(Point p)
        {
            PointList.SetNew(p);
            return null;
        }

        public JsonResult GetData()
        {
            return Json(PointList.Point, JsonRequestBehavior.AllowGet);
        }

    }
}
