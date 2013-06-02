using DiplomApp.Interfaces;
using DiplomApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomApp.Services
{
    public class UserService : DiplomApp.Interfaces.IUser
    {
        IUser _iUser;

        public UserService(IUser iUser)
        {
            _iUser = iUser;
        }

        public DiplomApp.Interfaces.IUser IUser
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Add(UserModel userModel)
        {
            return _iUser.Add(userModel);
        }

        public UserModel GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            throw new NotImplementedException();
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
