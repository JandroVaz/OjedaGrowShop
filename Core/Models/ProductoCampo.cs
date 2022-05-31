using System;
using System.Collections.Generic;

#nullable disable

namespace OjedaGrowShop.EF.Models
{
    public partial class ProductoCampo
    {
        public ProductoCampo()
        {
            OrdenDetalles = new HashSet<OrdenDetalle>();
        }

        public int Id { get; set; }
        public string NombrePro { get; set; }
        public string Descripcion { get; set; }
        public double? Precio { get; set; }
        public string Categoria { get; set; }
        public string Imagen { get; set; }

        public virtual ICollection<OrdenDetalle> OrdenDetalles { get; set; }
    }
}
