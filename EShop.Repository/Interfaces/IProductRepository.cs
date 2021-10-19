using EShop.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Repository.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        /// <summary>
        /// Gets all entitis based on giving seachString
        /// </summary>
        /// <returns>A list of products</returns>
        public Task<List<Product>> GetAllProductsBySeachAsync(string seachString);

        /// <summary>
        /// Get a specefic entity with PriceOffer based on id
        /// </summary>
        /// <returns>A Product</returns>
        public Task<Product> GetProductByIdWithPriceOffer(int id);
    }
}