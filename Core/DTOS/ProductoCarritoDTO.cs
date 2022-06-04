using System;
using System.Collections.Generic;
using System.Text;

namespace OjedaGrowShop.EF.DTOS
{
    public partial class ProductoCarritoDTO
    {
        public int IdProducto { get; set; }
        public string  Nombre { get; set; }
        public double PrecioTotal { get; set; }
        public double Precio { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
    }
}
