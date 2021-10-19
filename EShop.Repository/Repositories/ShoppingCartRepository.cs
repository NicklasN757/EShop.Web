using EShop.Repository.Domain;
using EShop.Repository.Entities;
using EShop.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EShop.Repository.Repositories
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly EShopContext _dbContext;
        public ShoppingCartRepository(EShopContext eShopContext) : base(eShopContext) => _dbContext = eShopContext;

        //Add a Product to the Product list that the ShoppingCart is using
        public async Task AddProductToShoppingCartByProductId(int productId, int shoppingCartId)
        {
            ShoppingCart tmpShoppingCard = await _dbContext.ShoppingCarts.AsNoTracking().Include(sc => sc.Products).SingleAsync(sc => sc.ShoppingCartId == shoppingCartId);
            Product tmpProduct = await _dbContext.Products.AsNoTracking().Include(p => p.ShoppingCart).SingleAsync(p => p.ProductId == productId);

            tmpShoppingCard.Products.Add(tmpProduct);

            _dbContext.ShoppingCarts.Update(tmpShoppingCard);
            await _dbContext.SaveChangesAsync();
        }
    }
}