using DiplomApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomApp.Services
{
    public class UserService
    {
        IUser _iUser;

        public UserService(IUser iUser)
        {
            _iUser = iUser;
        }


    }
}
