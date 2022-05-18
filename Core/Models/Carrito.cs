using System;
using System.Collections.Generic;

#nullable disable

namespace OjedaGrowShop.EF.Models
{
    public partial class Carrito
    {
        public int Id { get; set; }
        public int Idusuario { get; set; }
        public int Idproducto { get; set; }
        public int Cantidad { get; set; }

        public virtual ProductoMascotum Idproducto1 { get; set; }
        public virtual ProductoCampo IdproductoNavigation { get; set; }
        public virtual User IdusuarioNavigation { get; set; }
    }
}
