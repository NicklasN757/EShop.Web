using EShop.Repository.Domain;
using EShop.Repository.Entities;
using EShop.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Repository.Repositories
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly EShopContext _dbContext;
        public ShoppingCartRepository(EShopContext eShopContext) : base(eShopContext) => _dbContext = eShopContext;

        //Adds a specfic entity to the ShoppingCartProducts table
        public async Task AddProductToShoppingCart(int productId, int shoppingCartId)
        {
            ShoppingCartProduct newShoppingCartProduct = new();
            newShoppingCartProduct.FK_Product = productId;
            newShoppingCartProduct.FK_ShoppingCart = shoppingCartId;

            _dbContext.ShoppingCartProducts.Add(newShoppingCartProduct);
            await _dbContext.SaveChangesAsync();

            await CalculateTotalCartPrice(shoppingCartId);
        }

        //Removes a specfic entity from the ShoppingCartProducts table
        public async Task RemoveProductFromShoppingCart(int shoppingCartProductId)
        {
            ShoppingCartProduct shoppingCartProduct = await _dbContext.ShoppingCartProducts.AsNoTracking().SingleAsync(scp => scp.ShoppingCartProductId == shoppingCartProductId);

            _dbContext.ShoppingCartProducts.Remove(shoppingCartProduct);
            await _dbContext.SaveChangesAsync();

            await CalculateTotalCartPrice(shoppingCartProduct.FK_ShoppingCart);
        }

        //Get a specfic entity from the shoppingCart based on userId
        public async Task<ShoppingCart> GetShoppingCartByUser(int userId) => await _dbContext.ShoppingCarts
            .AsNoTracking()
            .Include(sc => sc.ShoppingCartProducts)
            .ThenInclude(scp => scp.Product)
            .ThenInclude(p => p.PriceOffer)
            .Include(sc => sc.User)
            .SingleAsync(sc => sc.ShoppingCartId == userId);

        //Calulates the total price of a cart when the cart is being updated
        public async Task CalculateTotalCartPrice(int shoppingCartId)
        {
            double totalPrice = 0;

            List<ShoppingCartProduct> shoppingCartProducts = new();
            shoppingCartProducts = await _dbContext.ShoppingCartProducts
                .AsNoTracking()
                .Where(scp => scp.FK_ShoppingCart == shoppingCartId)
                .Include(scp => scp.Product)
                .ThenInclude(p => p.PriceOffer)
                .ToListAsync();

            foreach (ShoppingCartProduct product in shoppingCartProducts)
            {
                if (product.Product.PriceOffer == null)
                {
                    totalPrice += product.Product.Price;
                }
                else
                {
                    totalPrice += product.Product.PriceOffer.NewPrice;
                }
            }

            ShoppingCart shoppingCart = await GetByIdAsync(shoppingCartId);
            shoppingCart.TotalPrice = totalPrice;

            _dbContext.ShoppingCarts.Update(shoppingCart);
            await _dbContext.SaveChangesAsync();
        }

        //Remove all entities thats related to a single ShoppingCart
        public async Task ClearCart(int shoppingCartId)
        {
            List<ShoppingCartProduct> shoppingCartProducts = await _dbContext.ShoppingCartProducts
                .AsNoTracking()
                .Where(scp => scp.FK_ShoppingCart == shoppingCartId)
                .ToListAsync();

            foreach (ShoppingCartProduct shoppingCartProduct in shoppingCartProducts)
            {
                _dbContext.ShoppingCartProducts.Remove(shoppingCartProduct);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}