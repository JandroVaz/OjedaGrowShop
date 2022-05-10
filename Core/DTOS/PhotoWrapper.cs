using System;
using System.Collections.Generic;
using System.Text;

namespace OjedaGrowShop.EF.DTOS
{
    public partial class PhotoWrapper
    {
        public string Base64 { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
