using System;
using System.Collections.Generic;

#nullable disable

namespace OjedaGrowShop.EF.Models
{
    public partial class MetodoPago
    {
        public MetodoPago()
        {
            Ordens = new HashSet<Orden>();
        }

        public int Id { get; set; }
        public string NombreMetodo { get; set; }

        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
