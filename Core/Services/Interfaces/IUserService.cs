using OjedaGrowShop.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OjedaGrowShop.EF.Services.Interfaces
{
    public partial interface IUserService
    {
        Task <int> AddUser(User user);
        bool Login(string username, string password);

        Task<bool> Exist(string correo);
        public int getUserId(string user);
        public bool getRolUser(string user);

    }
}
