using DiplomApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomApp.Interfaces
{
    public interface IPoint
    {
        IEnumerable<PointModel> GetAllPoint(int id);
        bool Add(PointModel pointModel);
        bool Update();
        bool Remove();
    }
}
