using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OjedaGrowShop.EF.Models;
using OjedaGrowShop.EF.Services.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OjedaGrowShop.EF.DTOS;

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

        public async Task<IEnumerable<CarritoProducto>> ListProductCar(int idUser)
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
                    if (itemCart.Idusuario == idUser)
                    {
                        idCarrito = itemCart.Id;
                    }
                }
                List<CarritoProducto> productCartList = await __ojedaContext.CarritoProductos.Where(e => e.IdCarrito == idCarrito).ToListAsync();
                return productCartList;
            }
            else
            {
                return null;
            }
        }
        //Listamos los productos del cliente
        public async Task<IEnumerable<ProductoCarritoDTO>> ListProduct(int idUser)
        {
            //Comprobamos si el carrito del usuario existe, si existe, en caso contrario lo crea
            if (__ojedaContext.Carritos.Any(e => e.Idusuario == idUser))
            {
                //Guardamos todos los carritos
                int idCarrito = __ojedaContext.Carritos.Where(c => c.Idusuario == idUser).FirstOrDefault().Id;

                return idCarrito > 0 ?
                    await __ojedaContext.Productos
                    .Where(p => p.CarritoProductos
                        .Any(cp => cp.IdCarrito == idCarrito))
                            .Select(s =>
                                new ProductoCarritoDTO()
                                {
                                    IdProducto = s.Id,
                                    Nombre = s.Nombre,
                                    Categoria = s.Categoria,
                                    Cantidad = s.CarritoProductos.FirstOrDefault(p => p.IdCarrito == idCarrito).CantidadProducto,
                                    Precio = s.Precio,
                                    PrecioTotal = s.Precio * s.CarritoProductos.FirstOrDefault(p => p.IdCarrito == idCarrito).CantidadProducto

                                }
                        ).ToListAsync() : null;
            }
            else
            {
                return null;
            }
        }


        //GET BY ID
        public async Task<Producto> GetProdById(int id)
        {
            return await __ojedaContext.Productos.FindAsync(id);
        }

        public async Task<bool> DeleteProdById(int id)
        {

            var prod = await __ojedaContext.Productos.FindAsync(id);
            var carProd = await __ojedaContext.CarritoProductos.FirstOrDefaultAsync(cp => cp.IdProducto == prod.Id);
            __ojedaContext.CarritoProductos.Remove(carProd);
            return await __ojedaContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCartById(int id)
        {
            Carrito cart = await __ojedaContext.Carritos.FindAsync(id);
            List<CarritoProducto> carritoProds = await __ojedaContext.CarritoProductos.Where(p => p.IdCarrito == cart.Id).ToListAsync();
            __ojedaContext.RemoveRange(carritoProds);
            if (await __ojedaContext.SaveChangesAsync() > 0) 
            {
                __ojedaContext.Carritos.Remove(cart);
                return await __ojedaContext.SaveChangesAsync() > 0;
            }
            return false;
            
        }

        public async Task<Carrito> GetCartById(int id)
        {
            return await __ojedaContext.Carritos.FirstOrDefaultAsync(e => e.Idusuario == id);
        }
    }
}
