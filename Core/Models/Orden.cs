using System;
using System.Collections.Generic;

#nullable disable

namespace OjedaGrowShop.EF.Models
{
    public partial class Orden
    {
        public Orden()
        {
            OrdenDetalles = new HashSet<OrdenDetalle>();
        }

        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdMetodoPago { get; set; }
        public double? Total { get; set; }

        public virtual MetodoPago IdMetodoPagoNavigation { get; set; }
        public virtual User IdUsuarioNavigation { get; set; }
        public virtual ICollection<OrdenDetalle> OrdenDetalles { get; set; }
    }
}
