using System.Linq;
using DiplomApp.Helpers;
using System;
using DiplomApp.Models;

namespace DiplomApp.Repo
{
    public class CredentialsRepo
    {
        public bool Login(string login, string password)
        {
            using (var dbEntities = new DBEntities())
            {
                string encryptedPassword = CryptoHelper.Encrypt(password);
                return dbEntities.Credentials.FirstOrDefault(p => p.Login == login && p.Password == encryptedPassword) != null;
            }
        }

        public bool Add(int userId, string login, string password)
        {
            using (var dbEntities = new DBEntities())
            {
                try
                {
                    dbEntities.Credentials.Add(new Credential() { Login = login, Password = CryptoHelper.Encrypt(password), UserID = userId });
                    dbEntities.SaveChanges();
                    return true;
                }
                catch (Exception exception)
                {
                    return false;
                }
            }
        }

        public bool Delete(CredentialsModel credentials)
        {
            using (var dbEntities = new DBEntities())
            {
                try
                {
                    dbEntities.Credentials.Remove(new Credential() {Id = credentials.Id, UserID = credentials.UserId, Login = credentials.Login, Password = credentials.Password });
                    dbEntities.SaveChanges();
                    return true;
                }
                catch (Exception exception)
                {
                    return false;
                }
            }
        }

        public string Test()
        {
            using (var dbEntities = new DBEntities())
            {
                return dbEntities.Credentials.First(p => p.UserID == 1).User.LastName;
            }
        }
    }
}
