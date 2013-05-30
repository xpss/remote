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

        public int Add(UserModel userModel)
        {
            using (var dbEntities = new DBEntities())
            {
                try
                {
                    dbEntities.Users.Add(new User()
                                             {
                                                 FirstName = userModel.FirstName,
                                                 LastName = userModel.LastName,
                                                 Mobile = userModel.Mobile,
                                                 Address = userModel.Address,
                                                 Birthday = userModel.Birthday
                                             });
                    dbEntities.SaveChanges();
                    return GetUserIdByName(userModel.FirstName, userModel.LastName);
                }
                catch (Exception e)
                {
                    return 0;
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

        public int GetUserIdByName(string firstName, string lastName)
        {
            using (var dbEntities = new DBEntities())
            {
                return dbEntities.Users.First(p => p.FirstName == firstName && p.LastName == lastName).Id;
            }
        }
    }
}
