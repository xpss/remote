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
using System.Web.Helpers;

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

        public ActionResult DrawChart()
        {
            List<int> Xs = new List<int>();
            List<int> Ys = new List<int>();
            List<int> Zs = new List<int>();
            List<DateTime> Dates = new List<DateTime>();
            var data = ConvertModel(pointService.GetAllPoint(credentialsService.GetCurrentUserId(User.Identity.Name)));
            foreach (var item in data)
            {
                Xs.Add(item.X);
                Ys.Add(item.Y);
                Zs.Add(item.Z);
                Dates.Add(item.Date.Date);
            }
            string myTheme =
          @"<Chart BackColor=""#018bc1"" BackGradientStyle=""TopBottom"" BorderColor=""181, 64, 1"" BorderWidth=""2"" BorderlineDashStyle=""Solid"" Palette=""BrightPastel"">
              <ChartAreas>
                <ChartArea Name=""Default"" _Template_=""All"" BackColor=""Transparent"" BackSecondaryColor=""Red"" BorderColor=""64, 64, 64, 64"" BorderDashStyle=""Solid"" ShadowColor=""Transparent"">
                  <AxisY LineColor=""64, 64, 64, 64"">
                    <MajorGrid Interval=""Auto"" LineColor=""64, 64, 64, 64"" />
                    <LabelStyle Font=""Trebuchet MS, 8.25pt, style=Bold"" />
                  </AxisY>

                  <AxisX LineColor=""64, 64, 64, 64"">
                    <MajorGrid LineColor=""64, 64, 64, 64"" />
                    <LabelStyle Font=""Trebuchet MS, 8.25pt, style=Bold"" />
                  </AxisX>
                  <Area3DStyle Inclination=""15"" IsClustered=""False"" IsRightAngleAxes=""False"" Perspective=""10"" Rotation=""10"" WallWidth=""0"" />
                </ChartArea>
              </ChartAreas>
              <Legends>
                <Legend _Template_=""All"" Alignment=""Center"" BackColor=""Transparent"" Docking=""Bottom"" Font=""Trebuchet MS, 8.25pt, style=Bold"" IsTextAutoFit =""False"" LegendStyle=""Row"">
                </Legend>
              </Legends>
            </Chart>";
            var model = new Chart(width: 500, height: 300, theme: myTheme)
             .AddTitle("Chart")
             .AddSeries(
                name: "X",
                chartType: "Line",
                yValues: Xs)
             .AddSeries(
                name: "Y",
                chartType: "Line",
                yValues: Ys)
             .AddSeries(
                name: "Z",
                chartType: "Line",
                yValues: Zs)
             .AddLegend(
                title: "Legend")
             .Write();
            return null;
        }

        public JsonResult GetPoints()
        {
            return Json(pointService.GetAllPoint(credentialsService.GetCurrentUserId(User.Identity.Name)), JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<ChartModel> ConvertModel(IEnumerable<PointModel> points)
        {
            var chartModel = new List<ChartModel>();
            foreach (var item in points)
            {
                chartModel.Add(new ChartModel()
                {
                    X = item.X,
                    Y = item.Y,
                    Z = item.Z,
                    Date = item.Date
                });
            }
            return chartModel;
        }
    }
}
