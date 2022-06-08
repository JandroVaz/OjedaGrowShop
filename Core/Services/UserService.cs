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
            return __ojedaContext.Users.Any(u => u.Name.Trim().ToLower().Equals(user.Trim().ToLower()) && u.Rol.Equals("admin"));
        }

        //Recogemos la ID del usuario actual
        public int getUserId(string user)
        {
            return __ojedaContext.Users
                .FirstOrDefault(u => u.Name.Trim().ToLower()
                    .Equals(user.Trim().ToLower())).Id;
        }

        //Recogemos todos los usuarios de la base de datos
        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await __ojedaContext.Users.ToListAsync();
        }

        //Borramos el usuario indicado por id
        public async Task<bool> DeleteUser(int id)
        {
            var user = await __ojedaContext.Users.FindAsync(id);
            __ojedaContext.Users.Remove(user);
            return await __ojedaContext.SaveChangesAsync() > 0;
        }

        //Modificamos
        public async Task<bool> UpdateUser(User user)
        {
            __ojedaContext.Entry(user).State = EntityState.Modified;
            return await __ojedaContext.SaveChangesAsync() > 0;
        }

        public async Task<User> GetUserById(int id)
        {
            return await __ojedaContext.Users.FindAsync(id);
        }
    }
}
