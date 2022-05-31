using System;
using System.Collections.Generic;

#nullable disable

namespace OjedaGrowShop.EF.Models
{
    public partial class Carrito
    {
        public Carrito()
        {
            CarritoProductos = new HashSet<CarritoProducto>();
        }

        public int Id { get; set; }
        public int Idusuario { get; set; }

        public virtual User IdusuarioNavigation { get; set; }
        public virtual ICollection<CarritoProducto> CarritoProductos { get; set; }
    }
}
