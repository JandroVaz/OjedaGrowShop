using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using OjedaGrowShop.EF.DTOS;


namespace OjedaGrowShop.EF.Services.Interfaces
{
    public partial interface IPhotoService
    {
        public IList<PhotoWrapper> ListImgCarousel(string folder);
        PhotoCreationResult CreateImage(MemoryStream ms, string photoFolder, string category);
        int DeletePhoto(string path, string namePhoto);
        PhotoStreamWrapper GetImageStream(string path, string namePhoto);

        public IList<PhotoWrapper> ListWatermarkPhotos(string folder);
    }
}
