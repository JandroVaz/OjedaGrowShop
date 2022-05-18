using System;
using System.Collections.Generic;

#nullable disable

namespace OjedaGrowShop.EF.Models
{
    public partial class User
    {
        public User()
        {
            Carritos = new HashSet<Carrito>();
            Ordens = new HashSet<Orden>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }

        public virtual ICollection<Carrito> Carritos { get; set; }
        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
