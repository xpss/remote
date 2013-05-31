using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomApp.Models;

namespace DiplomApp.Interfaces
{
    public interface ICredentials
    {
        bool Login(string login, string password);
        bool Add(int userId, string login, string password);
        bool Update();
        bool Remove(CredentialsModel credentials);
        int GetCurrentUserId(string login);
    }
}
