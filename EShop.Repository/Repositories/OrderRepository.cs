using EShop.Repository.Domain;
using EShop.Repository.Entities;
using EShop.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Repository.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly EShopContext _dbContext;
        public OrderRepository(EShopContext eShopContext) : base(eShopContext) => _dbContext = eShopContext;

        //Converts a list of ShoppingCartProduct entities into ProductOrder entities
        public async Task<List<OrderProduct>> ConvertShoppingCartToOrder(List<ShoppingCartProduct> shoppingCartProducts, int orderId)
        {
            List<OrderProduct> orderProducts = new();
            foreach (ShoppingCartProduct shoppingCartProduct in shoppingCartProducts)
            {
                OrderProduct newOrderProduct = new();
                newOrderProduct.FK_Order = orderId;
                newOrderProduct.FK_Product = shoppingCartProduct.FK_Product;

                orderProducts.Add(newOrderProduct);
            }

            _dbContext.AddRange(orderProducts);
            await _dbContext.SaveChangesAsync();

            return orderProducts;
        }

        //Creates a new entity and then returns it again
        public async Task<Order> CreateAndReturnOrder(Order newOrder)
        {
            _dbContext.Add(newOrder);
            await _dbContext.SaveChangesAsync();
            return newOrder;
        }

        //Gets all order realated to a single user
        public async Task<List<Order>> GetAllOrdersByUser(int userId) => await _dbContext.Orders
            .AsNoTracking()
            .Where(o => o.FK_UserId == userId)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();

        public async Task<Order> GetOrderByIdWithAll(int orderId) => await _dbContext.Orders
            .AsNoTracking()
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .SingleAsync(o => o.OrderId == orderId);
    }
}