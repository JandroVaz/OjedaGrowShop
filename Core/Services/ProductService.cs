using Microsoft.EntityFrameworkCore;
using OjedaGrowShop.EF.Models;
using OjedaGrowShop.EF.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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
        public async Task<int> AddProd(ProductoCampo productoCampo)
        {
            __ojedaContext.ProductoCampos.Add(productoCampo);
            return await __ojedaContext.SaveChangesAsync();
        }

        //DELETE
        public async Task<bool> DeleteProd(int id)
        {
            var productoCampo = await __ojedaContext.ProductoCampos.FindAsync(id);
            __ojedaContext.ProductoCampos.Remove(productoCampo);
            return await __ojedaContext.SaveChangesAsync() > 0;
        }

        //GET BY ID
        public async Task<ProductoCampo> GetProdById(int id)
        {
            return await __ojedaContext.ProductoCampos.FindAsync(id);
        }

        //GET ALL
        public async Task<IEnumerable<ProductoCampo>> GetProductoCampos()
        {
            return await __ojedaContext.ProductoCampos.ToListAsync();
        }

        //UPDATE PROD
        public async Task<bool> UpdateProd(ProductoCampo productoCampo)
        {
            __ojedaContext.Entry(productoCampo).State = EntityState.Modified;
            return await __ojedaContext.SaveChangesAsync() > 0;
        }
    }
}
