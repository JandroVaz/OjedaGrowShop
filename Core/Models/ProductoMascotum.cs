using System;
using System.Collections.Generic;

#nullable disable

namespace OjedaGrowShop.EF.Models
{
    public partial class ProductoMascotum
    {
        public ProductoMascotum()
        {
            OrdenDetalles = new HashSet<OrdenDetalle>();
        }

        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public double? Precio { get; set; }
        public string Categoria { get; set; }
        public string Imagen { get; set; }

        public virtual ICollection<OrdenDetalle> OrdenDetalles { get; set; }
    }
}
