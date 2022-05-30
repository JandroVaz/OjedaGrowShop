using OjedaGrowShop.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OjedaGrowShop.EF.Services.Interfaces
{
    public partial interface ICartService
    {
        Task<bool> AddProduct(int idUser, int idProduct);
        Task<Carrito> GetIdCar(int idUser);
        Task<IEnumerable<CarritoProducto>> ListProductCar(int idUser);
        Task<IEnumerable<Producto>> ListProduct(int idUser);
        Task<Producto> GetProdById(int id);
    }
}
