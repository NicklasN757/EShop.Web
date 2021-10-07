using EShop.Repository.Entities;
using EShop.Repository.Interfaces;
using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Service.Services;

namespace EShop.Service.Services
{
    public class OrderService : GenericService<OrderDTO, IOrderRepository, Order>, IOrderServices
    {
        private readonly MappingService _mappingService;
        private readonly IOrderRepository _orderRepository;

        public OrderService(MappingService mappingService, IOrderRepository orderRepository) : base(mappingService, orderRepository)
        {
            _mappingService = mappingService;
            _orderRepository = orderRepository;
        }
    }
}