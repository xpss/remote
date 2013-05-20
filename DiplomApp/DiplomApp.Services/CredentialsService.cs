using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomApp.Interfaces;

namespace DiplomApp.Services
{
    public class CredentialsService
    {
        private ICredentials _iCredentials;
        public CredentialsService(ICredentials iCredentials)
        {
            _iCredentials = iCredentials;
        }

        public bool Login(string login, string password)
        {
            return _iCredentials.Login(login, password);
        }
    }
}
