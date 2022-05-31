using System;
using System.Collections.Generic;

#nullable disable

namespace OjedaGrowShop.EF.Models
{
    public partial class Producto
    {
        public Producto()
        {
            CarritoProductos = new HashSet<CarritoProducto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int TipoProducto { get; set; }
        public double Precio { get; set; }
        public string Categoria { get; set; }
        public string Imagen { get; set; }

        public virtual TipoProducto TipoProductoNavigation { get; set; }
        public virtual ICollection<CarritoProducto> CarritoProductos { get; set; }
    }
}
