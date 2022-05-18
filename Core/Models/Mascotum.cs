using System;
using System.Collections.Generic;

#nullable disable

namespace OjedaGrowShop.EF.Models
{
    public partial class Mascotum
    {
        public int Id { get; set; }
        public string Genero { get; set; }
        public string Raza { get; set; }
        public int? TipoMascota { get; set; }
    }
}
