using DiplomApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomApp.Repo
{
    class UserRepo
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
    }
}
