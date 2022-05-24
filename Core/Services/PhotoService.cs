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
        private readonly string imgCampo;
        private readonly string imgMascota;

        public PhotoService()
        {
            originalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/");
            imgCampo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/imgcampo");
            imgMascota = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/imgmascota");
        }

        //Creacion de la imagen 
        public PhotoCreationResult CreateImage(MemoryStream ms, string photoFolder, string category)
        {
            string photoPath = Path.Combine(category.Equals("campo") ? imgCampo : imgMascota, photoFolder);

            if (!File.Exists(photoPath))
            {
                using FileStream file = new FileStream(photoPath, FileMode.Create, FileAccess.Write);
                ms.WriteTo(file);
                file.Close();
                ms.Close();
                ms.Dispose();
                return new PhotoCreationResult()
                {
                    Name = photoPath,
                    OperationResult = 1
                };
            }
            ms.Dispose();
            return new PhotoCreationResult()
            {
                Name = photoPath,
                OperationResult = -1
            };

        }
        //Borramos imagen
        public int DeletePhoto(string path, string namePhoto)
        {

            try
            {
                if (path.Equals("mascota"))
                {
                    string photoPath = Path.Combine(imgMascota, namePhoto);
                    if (File.Exists(photoPath))
                    {
                        File.Delete(photoPath);
                    }
                }
                else
                {
                    string photoPath = Path.Combine(imgCampo, namePhoto);
                    if (File.Exists(photoPath))
                    {
                        File.Delete(photoPath);
                    }
                }
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //Tomamos imagen
        public PhotoStreamWrapper GetImageStream(string path, string namePhoto)
        {
            string photoPath = "";
            string fileName = "";
            if (path.Equals("mascota"))
            {
                photoPath = Path.Combine(imgMascota, namePhoto);
                fileName = Path.GetFileName(photoPath);

            }
            else
            {
                photoPath = Path.Combine(imgMascota, namePhoto);
                fileName = Path.GetFileName(photoPath);
            }
            if (!File.Exists(photoPath))
            {
                return null;
            }
            return new PhotoStreamWrapper()
            {
                Stream = File.OpenRead(photoPath),
                Name = fileName.Split('.')[0],
                Type = fileName.Split('.')[1]
            };
        }
        //listado de todas las fotos ****CORREGIR
        public IList<PhotoWrapper> ListWatermarkPhotos(string folder)
        {
            List<PhotoWrapper> files = new List<PhotoWrapper>();
            //MASCOTAS
            if (folder != null && folder.Equals("mascotas"))
            {
                foreach (string filePath in Directory.GetFiles(Path.Combine(imgMascota)))
                {
                    using var ms = File.OpenRead(Path.Combine(imgMascota, filePath));
                    string fileName = Path.GetFileName(filePath);
                    files.Add(new PhotoWrapper()
                    {
                        Base64 = Path.Combine(imgMascota, filePath).Split("wwwroot/")[1],
                        Name = fileName.Split('.')[0],
                        Type = fileName.Split('.')[1]
                    });
                }
            }
            else
            {   //CAMPO
                foreach (string filePath in Directory.GetFiles(Path.Combine(imgCampo)))
                {
                    using var ms = File.OpenRead(Path.Combine(imgCampo, filePath));
                    string fileName = Path.GetFileName(filePath);
                    files.Add(new PhotoWrapper()
                    {
                        Base64 = Path.Combine(imgMascota, filePath).Split("wwwroot/")[1],
                        Name = fileName.Split('.')[0],
                        Type = fileName.Split('.')[1]
                    });
                }
            }



            return files;
        }
        //listado del carrusel
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
