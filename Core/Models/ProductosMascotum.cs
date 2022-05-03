using System;
using System.Collections.Generic;

#nullable disable

namespace OjedaGrowShop.EF.Models
{
    public partial class ProductosMascotum
    {
        public string Id { get; set; }
        public string Nombrepro { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
        public string Categoria { get; set; }
        public string Imagen { get; set; }
    }
}
