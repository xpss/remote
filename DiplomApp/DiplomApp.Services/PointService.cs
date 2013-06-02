using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiplomApp.Interfaces;
using DiplomApp.Models;

namespace DiplomApp.Services
{
    public class PointService : DiplomApp.Interfaces.IPoint
    {
        private IPoint _iPoint;

        public PointService(IPoint iPoint)
        {
            _iPoint = iPoint;
        }

        public DiplomApp.Interfaces.IPoint IPoint
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public IEnumerable<PointModel> GetAllPoint(int id)
        {
            return _iPoint.GetAllPoint(id);
        }

        public bool Add(PointModel pointModel)
        {
            return _iPoint.Add(pointModel);
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
