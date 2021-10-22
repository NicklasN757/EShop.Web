using EShop.Repository.Entities;
using EShop.Repository.Interfaces;
using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Service.Services
{
    public class OrderService : GenericService<OrderDTO, IOrderRepository, Order>, IOrderService
    {
        private readonly MappingService _mappingService;
        private readonly IOrderRepository _orderRepository;

        public OrderService(MappingService mappingService, IOrderRepository orderRepository) : base(mappingService, orderRepository)
        {
            _mappingService = mappingService;
            _orderRepository = orderRepository;
        }

        //Calls and logs the "ConvertShoppingCartToOrder" funtion from the OrderRepository
        public async Task<List<OrderProductDTO>> ConvertShoppingCartToOrder(List<ShoppingCartProductDTO> shoppingCartProducts, int orderId)
        {
            try
            {
                List<OrderProductDTO> orderProductDTOs = _mappingService._mapper.Map<List<OrderProductDTO>>(
                    await _orderRepository.ConvertShoppingCartToOrder(_mappingService._mapper.Map<List<ShoppingCartProduct>>(shoppingCartProducts), orderId));

                LogInformation("Successfully converted the ShoppingCart to a Order.");

                return orderProductDTOs;
            }
            catch (Exception ex)
            {
                LogError("Failed to convert the ShoppingCart to a Order - ", ex);
                return null;
            }
        }

        //Calls and logs the "ConvertShoppingCartToOrder" funtion from the OrderRepository
        public async Task<OrderDTO> CreateAndReturnOrder(OrderDTO newOrder)
        {
            try
            {
                OrderDTO orderDTO = _mappingService._mapper.Map<OrderDTO>(await _orderRepository.CreateAndReturnOrder(_mappingService._mapper.Map<Order>(newOrder)));

                LogInformation($"Successfully created and returned a new Order - Order: {newOrder}");

                return orderDTO;
            }
            catch (Exception ex)
            {
                LogError($"Failed to create and return a new Order - Order: {newOrder} - ", ex);

                return null;
            }
        }

        //Calls and logs the "GetAllOrdersByUser" funtion from the OrderRepository
        public async Task<List<OrderDTO>> GetAllOrdersByUser(int userId)
        {
            try
            {
                List<OrderDTO> orderDTOs = _mappingService._mapper.Map<List<OrderDTO>>(await _orderRepository.GetAllOrdersByUser(userId));

                LogInformation($"Successfully retrieved all orders with the giving userId - UserId: {userId}.");

                return orderDTOs;
            }
            catch (Exception ex)
            {
                LogError($"Failed to retrieved all orders with the giving userId - UserId: {userId} - ", ex);

                return null;
            }
        }

        //Calls and logs the "GetAllOrdersByUser" funtion from the OrderRepository
        public async Task<OrderDTO> GetOrderByIdWithAll(int orderId)
        {
            try
            {
                OrderDTO orderDTO = _mappingService._mapper.Map<OrderDTO>(await _orderRepository.GetOrderByIdWithAll(orderId));

                LogInformation($"Successfully retrieved a order and all its realations with the giving OrderId - OrderId: {orderId}.");

                return orderDTO;
            }
            catch (Exception ex)
            {
                LogError($"Failed to retrieved a order and all its realations with the giving OrderId - OrderId: {orderId} - ", ex);

                return null;
            }
        }
    }
}