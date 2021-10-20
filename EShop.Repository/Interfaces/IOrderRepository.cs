using EShop.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Repository.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        /// <summary>
        /// Converts ShoppingCartProducts to orderProducts and return the OrderProduct list
        /// </summary>
        public Task<List<OrderProduct>> ConvertShoppingCartToOrder(List<ShoppingCartProduct> shoppingCartProducts, int orderId);

        /// <summary>
        /// Create a new order and then return its
        /// </summary>
        /// <returns>A Order </returns>
        public Task<Order> CreateAndReturnOrder(Order newOrder);

        /// <summary>
        /// Gets all realated orders for a specfic user, based on userId
        /// </summary>
        /// <returns>A list of orders</returns>
        public Task<List<Order>> GetAllOrdersByUser(int userId);
    }
}