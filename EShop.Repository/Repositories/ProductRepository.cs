using EShop.Repository.Domain;
using EShop.Repository.Entities;
using EShop.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly EShopContext _dbContext;
        public ProductRepository(EShopContext eShopContext) : base(eShopContext) => _dbContext = eShopContext;

        //Gets a list of entities from the Products table
        public async Task<List<Product>> GetAllProductsBySeachAsync(string seachString = null)
        {
            if (seachString == null)
            {
                return await _dbContext.Products
                    .AsNoTracking()
                    .Include(p => p.PriceOffer)
                    .OrderByDescending(p => p.PriceOffer)
                    .ThenBy(p => p.Price)
                    .Where(p => p.IsDeleted == false)
                    .ToListAsync();
            }
            else
            {
                return await _dbContext.Products
                    .AsNoTracking()
                    .Include(p => p.PriceOffer)
                    .Where(p => p.Name.Contains(seachString))
                    .OrderByDescending(p => p.PriceOffer)
                    .ThenBy(p => p.Price)
                    .Where(p => p.IsDeleted == false)
                    .ToListAsync();
            }
        }

        //Gets a single entity from the Products table
        public async Task<Product> GetProductByIdWithPriceOffer(int id) => await _dbContext.Products
            .AsNoTracking()
            .Include(p => p.PriceOffer)
            .SingleAsync(p => p.ProductId == id);

        //Soft deletes a specific entity from the Products table
        public async Task SoftDeleteProduct(int productId)
        {
            Product product = await _dbContext.Products.AsNoTracking().SingleAsync(p => p.ProductId == productId);
            product.IsDeleted = true;

            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}