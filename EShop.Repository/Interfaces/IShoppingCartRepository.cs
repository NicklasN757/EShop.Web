using EShop.Repository.Entities;
using System.Threading.Tasks;

namespace EShop.Repository.Interfaces
{
    public interface IShoppingCartRepository : IGenericRepository<ShoppingCart>
    {
        /// <summary>
        /// Gets the shoppingCart for a specfic user
        /// </summary>
        /// <returns>ShoppingCart</returns>
        public Task<ShoppingCart> GetShoppingCartByUser(int userId);

        /// <summary>
        /// Adds a new Product to the giving ShoppingCart
        /// </summary>
        public Task AddProductToShoppingCart(int productId, int shoppingCartId);

        /// <summary>
        /// Removes a Product from the giving ShoppingCart
        /// </summary>
        public Task RemoveProductFromShoppingCart(int shoppingCartProductId);

        /// <summary>
        /// Updates the giving ShoppingCarts total price base on shoppingCartId
        /// </summary>
        public Task CalculateTotalCartPrice(int shoppingCartId);
    }
}