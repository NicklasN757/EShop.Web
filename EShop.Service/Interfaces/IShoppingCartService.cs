using EShop.Service.DataTransferObjects;
using System.Threading.Tasks;

namespace EShop.Service.Interfaces
{
    public interface IShoppingCartService : IGenericService<ShoppingCartDTO>
    {
        /// <summary>
        /// Gets the shoppingCart for a specfic user
        /// </summary>
        /// <returns>ShoppingCart</returns>
        public Task<ShoppingCartDTO> GetShoppingCartByUser(int userId);

        /// <summary>
        /// Adds a new Product to the ShoppingCart
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

        /// <summary>
        /// Removes all products from a shoppingcart
        /// </summary>
        public Task ClearCart(int shoppingCartId);
    }
}