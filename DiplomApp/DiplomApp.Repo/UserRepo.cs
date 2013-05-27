using DiplomApp.Interfaces;
using DiplomApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomApp.Repo
{
    class UserRepo: IUser
    {
        public UserModel GetUserById(int id)
        {
            using (var dbEntities = new DBEntities())
            {
                User user = dbEntities.Users.FirstOrDefault(p => p.Id == id);
                return new UserModel()
                {
                    UserId = user.Id,
                    Address = user.Address,
                    Birthday = user.Birthday,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Mobile = user.Mobile
                };
            }
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public bool Add()
        {
            return false;
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
