using EShop.Service.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Service.Interfaces
{
    public interface IOrderService : IGenericService<OrderDTO>
    {
        /// <summary>
        /// Converts ShoppingCartProducts to orderProducts and return the OrderProduct list
        /// </summary>
        public Task<List<OrderProductDTO>> ConvertShoppingCartToOrder(List<ShoppingCartProductDTO> shoppingCartProducts, int orderId);

        /// <summary>
        /// Create a new order and then return its
        /// </summary>
        /// <returns>A Order </returns>
        public Task<OrderDTO> CreateAndReturnOrder(OrderDTO newOrder);

        /// <summary>
        /// Gets all realated orders for a specfic user, based on userId
        /// </summary>
        /// <returns>A list of orders</returns>
        public Task<List<OrderDTO>> GetAllOrdersByUser(int userId);

        /// <summary>
        /// Gets a order with all realated keys base on orderId
        /// </summary>
        /// <returns>A Order</returns>
        public Task<OrderDTO> GetOrderByIdWithAll(int orderId);
    }
}