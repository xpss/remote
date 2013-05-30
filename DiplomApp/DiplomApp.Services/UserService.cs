using DiplomApp.Interfaces;
using DiplomApp.Models;
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

        public int Add(UserModel userModel)
        {
            return _iUser.Add(userModel);
        }
    }
}
