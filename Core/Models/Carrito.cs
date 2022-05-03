using System;
using System.Collections.Generic;

#nullable disable

namespace OjedaGrowShop.EF.Models
{
    public partial class Carrito
    {
        public string Id { get; set; }
        public string Idiusuario { get; set; }
        public string Idproducto { get; set; }
        public string Cantidad { get; set; }
    }
}
