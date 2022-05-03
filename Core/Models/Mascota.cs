using System;
using System.Collections.Generic;

#nullable disable

namespace OjedaGrowShop.EF.Models
{
    public partial class Mascota
    {
        public string Id { get; set; }
        public string Fecha { get; set; }
        public string Raza { get; set; }
        public string Tipomascota { get; set; }
    }
}
