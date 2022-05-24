using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OjedaGrowShop.EF.DTOS
{
    public partial class PhotoStreamWrapper
    {
        public Stream Stream { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
