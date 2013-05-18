using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomApp.Models;

namespace DiplomApp.Repo
{
    public class PointRepo
    {
        public IEnumerable<PointModel> GetAllPoint()
        {
            using (var dbEntities = new DBEntities())
            {
                return dbEntities.Points.Select(p => new PointModel()
                                                  {
                                                        //User = p.UserID,
                                                        X = p.X,
                                                        Y = p.Y,
                                                        Z = p.Z,
                                                        Xv = p.vX,
                                                        Yv = p.vY,
                                                        Zv = p.vZ,
                                                        Date = p.Date
                                                  });
            }
        }
    }
}
