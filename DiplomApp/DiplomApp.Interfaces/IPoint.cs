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
        IEnumerable<PointModel> GetAllPoint();
        bool Add();
        bool Update();
        bool Remove();
    }
}
