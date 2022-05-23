using OjedaGrowShop.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OjedaGrowShop.EF.Services.Interfaces
{
    public partial interface IProductMascService
    {
        Task<bool> DeleteProd(int id);
        Task<bool> UpdateProd(ProductoMascotum productoMascotum);
        Task<ProductoMascotum> GetProdById(int id);
        Task<IEnumerable<ProductoMascotum>> GetProductoMascotas();
        Task<int> AddProd(ProductoMascotum productoMascotum);
    }
}
