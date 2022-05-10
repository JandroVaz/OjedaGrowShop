using OjedaGrowShop.EF.DTOS;
using OjedaGrowShop.EF.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OjedaGrowShop.EF.Services
{
  

    public partial class PhotoService : IPhotoService
    {

        private readonly string originalPath;

        public PhotoService()
        {
            originalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/");
        }


        public IList<PhotoWrapper> ListImgCarousel(string folder)
        {
            List<PhotoWrapper> files = new List<PhotoWrapper>();

            foreach (string filePath in Directory.GetFiles(Path.Combine(originalPath, folder)))
            {
                using var fileStream = File.OpenRead(Path.Combine(originalPath,filePath));
                string fileName = Path.GetFileName(filePath);
                files.Add(new PhotoWrapper() { 
                    Base64 = Path.Combine(originalPath,filePath).Split("wwwroot/")[1],
                    Name = fileName.Split(".")[0],
                    Type = fileName.Split(".")[1]
                
                });
            }

                return files;
        }
    }
}
