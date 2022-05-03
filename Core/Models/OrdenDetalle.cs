using System;
using System.Collections.Generic;

#nullable disable

namespace OjedaGrowShop.EF.Models
{
    public partial class OrdenDetalle
    {
        public string Id { get; set; }
        public string Idorden { get; set; }
        public string Idproducto { get; set; }
        public string Cantidad { get; set; }
        public string Precio { get; set; }
    }
}
