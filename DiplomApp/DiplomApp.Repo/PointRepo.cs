using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomApp.Models;
using DiplomApp.Interfaces;

namespace DiplomApp.Repo
{
    public class PointRepo : IPoint
    {
        public IEnumerable<PointModel> GetAllPoint(int id)
        {
            using (var dbEntities = new DBEntities())
            {
                return dbEntities.Points.Where(w => w.UserID == id).Select(p => new PointModel()
                                                  {
                                                        //User = p.UserID,
                                                        X = p.X,
                                                        Y = p.Y,
                                                        Z = p.Z,
                                                        Xv = p.vX,
                                                        Yv = p.vY,
                                                        Zv = p.vZ,
                                                        Date = p.Date
                                                  }).ToArray();
            }
        }

        public bool Add(PointModel pointModel)
        {
            using (var dbEntities = new DBEntities())
            {
                try
                {
                    dbEntities.Points.Add(new Point()
                                              {
                                                  UserID = 11,
                                                  X = pointModel.X,
                                                  Y = pointModel.Y,
                                                  Z = pointModel.Z,
                                                  vX = pointModel.Xv,
                                                  vY = pointModel.Yv,
                                                  vZ = pointModel.Zv,
                                                  Date = DateTime.Now
                                              });
                    dbEntities.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Remove()
        {
            throw new NotImplementedException();
        }
    }
}
