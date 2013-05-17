using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomApp.Models
{
    public class PointList
    {
        public static Point Point = new Point();

        public static void SetNew(Point p)
        {
            Point = p;
        }
    }
}