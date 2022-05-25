using Microsoft.EntityFrameworkCore;
using OjedaGrowShop.EF.Models;
using OjedaGrowShop.EF.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OjedaGrowShop.EF.Services
{
    public partial class ProductService : IProductService
    {
        //region Property
        private readonly OJEDAContext __ojedaContext;
        //endregion

        public ProductService(OJEDAContext ojedaContext)
        {
            __ojedaContext = ojedaContext;
        }

        //ADD USER
        public async Task<int> AddProd(Producto producto)
        {
            __ojedaContext.Productos.Add(producto);
            return await __ojedaContext.SaveChangesAsync();
        }

        //DELETE
        public async Task<bool> DeleteProd(int id)
        {
            var producto = await __ojedaContext.Productos.FindAsync(id);
            __ojedaContext.Productos.Remove(producto);
            return await __ojedaContext.SaveChangesAsync() > 0;
        }

        //GET BY ID
        public async Task<Producto> GetProdById(int id)
        {
            return await __ojedaContext.Productos.FindAsync(id);
        }

        //GET ALL
        public async Task<IEnumerable<Producto>> ListProduct()
        {
            return await __ojedaContext.Productos.ToListAsync();
        }

        //UPDATE PROD
        public async Task<bool> UpdateProd(Producto producto)
        {
            __ojedaContext.Entry(producto).State = EntityState.Modified;
            return await __ojedaContext.SaveChangesAsync() > 0;
        }
    }
}
