using EShop.Repository.Entities;
using System.Threading.Tasks;

namespace EShop.Repository.Interfaces
{
    public interface IShoppingCartRepository : IGenericRepository<ShoppingCart>
    {
        ///// <summary>
        ///// Add a Product to the ShoppingCart, both base on id.
        ///// </summary>
        //public Task AddProductToShoppingCartByProductId(int productId, int shoppingCartId);

        /// <summary>
        /// Gets the shoppingCart for a specfic user
        /// </summary>
        /// <returns>ShoppingCart</returns>
        public Task<ShoppingCart> GetShoppingCartByUser(int userId);
    }
}