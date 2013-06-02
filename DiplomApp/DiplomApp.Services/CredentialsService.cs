using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomApp.Interfaces;

namespace DiplomApp.Services
{
    public class CredentialsService : DiplomApp.Interfaces.ICredentials
    {
        private ICredentials _iCredentials;
        public CredentialsService(ICredentials iCredentials)
        {
            _iCredentials = iCredentials;
        }

        public DiplomApp.Interfaces.ICredentials ICredentials
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public bool Login(string login, string password)
        {
            return _iCredentials.Login(login, password);
        }

        public bool Add(int userId, string login, string password)
        {
            return _iCredentials.Add(userId, login, password);
        }

        public int GetCurrentUserId(string login)
        {
            return _iCredentials.GetCurrentUserId(login);
        }


        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Models.CredentialsModel credentials)
        {
            throw new NotImplementedException();
        }
    }
}
