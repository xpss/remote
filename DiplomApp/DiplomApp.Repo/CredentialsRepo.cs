using System.Linq;

namespace DiplomApp.Repo
{
    public class CredentialsRepo
    {
        public bool Login(string login, string password)
        {
            using (var dbEntities = new DBEntities())
            {
                return dbEntities.Credentials.FirstOrDefault(p => p.Login == login && p.Password == password) != null;
            }
        }
    }
}
