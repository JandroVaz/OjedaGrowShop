using System;
using System.Collections.Generic;

#nullable disable

namespace OjedaGrowShop.EF.Models
{
    public partial class Orden
    {
        public string Id { get; set; }
        public string Idusuario { get; set; }
        public string Idmetodopago { get; set; }
        public string Total { get; set; }
    }
}
