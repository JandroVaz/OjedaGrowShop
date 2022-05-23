using Microsoft.EntityFrameworkCore;
using OjedaGrowShop.EF.Models;
using OjedaGrowShop.EF.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OjedaGrowShop.EF.Services
{
    public partial class ProductMascService : IProductMascService
    {

        //region Property
        private readonly OJEDAContext __ojedaContext;
        //endregion

        public ProductMascService(OJEDAContext ojedaContext)
        {
            __ojedaContext = ojedaContext;
        }

        //Añade producto
        public async Task<int> AddProd(ProductoMascotum productoMascotum)
        {
            __ojedaContext.ProductoMascota.Add(productoMascotum);
            return await __ojedaContext.SaveChangesAsync();
        }

        //Borrar
        public async Task<bool> DeleteProd(int id)
        {
            var productoMasco= await __ojedaContext.ProductoMascota.FindAsync(id);
            __ojedaContext.ProductoMascota.Remove(productoMasco);
            return await __ojedaContext.SaveChangesAsync() > 0;
        }

        //Get By Id
        public async Task<ProductoMascotum> GetProdById(int id)
        {
            return await __ojedaContext.ProductoMascota.FindAsync(id);
        }

        //Listar prod
        public async Task<IEnumerable<ProductoMascotum>> GetProductoMascotas()
        {
            return await __ojedaContext.ProductoMascota.ToListAsync();
        }

        //Actualizar
        public async Task<bool> UpdateProd(ProductoMascotum productoMascotum)
        {
            __ojedaContext.Entry(productoMascotum).State = EntityState.Modified;
            return await __ojedaContext.SaveChangesAsync() > 0;
        }
    }
}
