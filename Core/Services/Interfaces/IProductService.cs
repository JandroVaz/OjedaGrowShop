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
        Task<bool> UpdateProd(ProductoCampo productoCampo);
        Task<ProductoCampo> GetProdById(int id);
        Task<IEnumerable<ProductoCampo>> GetProductoCampos();
        Task<int> AddProd(ProductoCampo productoCampo);
    }
}
