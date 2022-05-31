using System.IO;


namespace OjedaGrowShop.EF.DTOS
{
    public partial class PhotoDto
    {
        public MemoryStream MemoryStream { get; set; }
        public string namePhoto { get; set; }
    }
}
