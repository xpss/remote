﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomApp.Models;

namespace DiplomApp.Interfaces
{
    public interface IUser
    {
        UserModel GetUserById(int id);
        IEnumerable<UserModel> GetAllUsers();
        int Add(UserModel userModel);
        bool Update();
        bool Remove();
    }
}
