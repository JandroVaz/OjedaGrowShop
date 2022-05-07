using OjedaGrowShop.EF.Models;
using OjedaGrowShop.EF.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.ProtectedBrowserStorage;

namespace OjedaGrowShop.EF.Services
{
    public class UserService : IUserService
    {
        //region Property
        private readonly OJEDAContext __ojedaContext;
        //endregion

        public UserService(OJEDAContext ojedaContext)
        {
            __ojedaContext = ojedaContext;
        }

        //Añadir usuario
        public async Task<int> AddUser(User user)
        { 
            user.Password = Encriptar(user.Password);
            __ojedaContext.Users.Add(user);
            return await __ojedaContext.SaveChangesAsync();
        }

        //Login
        public bool Login(string username, string password)
        {
            password = Encriptar(password);
            return __ojedaContext.Users.Any(u => u.Name.Trim().ToLower().Equals(username.Trim().ToLower()) &&
             u.Password.Trim().ToLower().Equals(password.Trim().ToLower()));
        }
        /// Encripta una cadena
        public string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        //Comprobamos que el correo exista
        public async Task<bool> Exist(string correo)
        {
            return await Task.Run(() => __ojedaContext.Users.AsNoTracking().Any(e =>
               e.Correo.ToLower().Equals(correo.ToLower()))
            );
        }

        public bool getRolUser(string user)
        {
            return __ojedaContext.Users.Any(u => u.Rol == "admin");
        }

        //Recogemos la ID del usuario actual
        public int getUserId(string user)
        {
            int userId = 0;
            foreach (var u in __ojedaContext.Users)
            {
                if (u.Name == user)
                {
                    userId= u.Id;
                }
            }

            return userId;
        }
    }
}
