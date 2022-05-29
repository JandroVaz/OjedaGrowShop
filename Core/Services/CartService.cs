using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OjedaGrowShop.EF.Models;
using OjedaGrowShop.EF.Services.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OjedaGrowShop.EF.Services
{
    public class CartService : ICartService
    {

        //region Property
        private readonly OJEDAContext __ojedaContext;

        public CartService(OJEDAContext ojedaContext)
        {
            __ojedaContext = ojedaContext;
        }

        public async Task<bool> AddProduct(int idUser, int idProduct)
        {

            int idCarrito = 0;
            //Comprobamos si el carrito del usuario existe, si existe, en caso contrario lo crea
            bool cartExist = __ojedaContext.Carritos.Any(e => e.Idusuario == idUser); 
            if (cartExist)
            {
                //Guardamos todos los carritos
                List<Carrito> cartList = new List<Carrito>();
                cartList = __ojedaContext.Carritos.ToList();
                foreach (Carrito itemCart in cartList)
                {
                    if(itemCart.Idusuario == idUser)
                    {
                        idCarrito = itemCart.Id;
                    }
                }

                //Comprobamos si el producto ya existe en el carrito, en caso contrario se crea el producto en el carrito
                if (__ojedaContext.CarritoProductos.Any(e => e.IdProducto == idProduct && e.IdCarrito == idCarrito))
                {
               
                    List<CarritoProducto> cartProdList = await __ojedaContext.CarritoProductos.ToListAsync();

                    CarritoProducto cartProd = __ojedaContext.CarritoProductos.FirstOrDefault( e => e.IdCarrito == idCarrito);
                    cartProd.CantidadProducto = cartProd.CantidadProducto + 1;
                    
                    __ojedaContext.Entry(cartProd).State = EntityState.Modified;
                    return await __ojedaContext.SaveChangesAsync() >0 ;

                }
                else
                {
                   

                    CarritoProducto cartProducto = new CarritoProducto()
                    {
                        IdProducto = idProduct,
                        IdCarrito = idCarrito,
                        CantidadProducto = 1
                    };
                    
                    await __ojedaContext.CarritoProductos.AddAsync(cartProducto);
                    return await __ojedaContext.SaveChangesAsync() > 0;
                }

                
                
            }
            else
            {

                Carrito cart = new Carrito();

                cart.Idusuario = idUser;
                await __ojedaContext.Carritos.AddAsync(cart);
                await __ojedaContext.SaveChangesAsync();

                //Guardamos todos los carritos
                List<Carrito> cartList = new List<Carrito>();
                cartList = __ojedaContext.Carritos.ToList();
                foreach (Carrito itemCart in cartList)
                {
                    if (itemCart.Idusuario == idUser)
                    {
                        idCarrito = itemCart.Id;
                    }
                }


                CarritoProducto cartProducto = new CarritoProducto()
                {
                    IdProducto = idProduct,
                    IdCarrito = idCarrito,
                    CantidadProducto = 1
                };

                await __ojedaContext.CarritoProductos.AddAsync(cartProducto);
                return await __ojedaContext.SaveChangesAsync() > 0;
            }
        }

        public async Task<Carrito> GetIdCar(int idusuario)
        {
            return await __ojedaContext.Carritos.FindAsync(idusuario);
        }
    }
}
