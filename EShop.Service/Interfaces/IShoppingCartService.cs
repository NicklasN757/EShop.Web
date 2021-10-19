using EShop.Service.DataTransferObjects;
using System.Threading.Tasks;

namespace EShop.Service.Interfaces
{
    public interface IShoppingCartService : IGenericService<ShoppingCartDTO>
    {
        /// <summary>
        /// Add a Product to the ShoppingCart, both base on id.
        /// </summary>
        public Task AddProductToShoppingCartByProductId(int productId, int shoppingCartId);
    }
}