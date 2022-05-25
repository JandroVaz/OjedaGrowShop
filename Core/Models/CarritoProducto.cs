using System;
using System.Collections.Generic;

#nullable disable

namespace OjedaGrowShop.EF.Models
{
    public partial class CarritoProducto
    {
        public int IdProducto { get; set; }
        public int IdCarrito { get; set; }
        public int CantidadProducto { get; set; }

        public virtual Carrito IdCarritoNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
