using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OjedaGrowShop.EF.Models;

namespace OjedaGrowShop.EF.Services.Interfaces
{
    public partial interface IProductService
    {
        Task<bool> DeleteProd(int id);
        Task<bool> UpdateProd(Producto producto);
        Task<Producto> GetProdById(int id);
        Task<IEnumerable<Producto>> ListProduct();
        Task<int> AddProd(Producto producto);
    }
}
