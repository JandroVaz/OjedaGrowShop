using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using OjedaGrowShop.EF.DTOS;

namespace OjedaGrowShop.EF.Services.Interfaces
{
    public partial interface IPhotoService
    {
    
        IList<PhotoWrapper> ListImgCarousel(string folder);
    }
}
