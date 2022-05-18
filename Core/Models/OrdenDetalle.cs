using System;
using System.Collections.Generic;

#nullable disable

namespace OjedaGrowShop.EF.Models
{
    public partial class OrdenDetalle
    {
        public int Id { get; set; }
        public int IdOrden { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public double? Precio { get; set; }

        public virtual Orden IdOrdenNavigation { get; set; }
        public virtual ProductoMascotum IdProducto1 { get; set; }
        public virtual ProductoCampo IdProductoNavigation { get; set; }
    }
}
