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
        public Task<Product> GetProductByIdWithAll(int id);

        /// <summary>
        /// Soft deletes a specific product based on productId 
        /// </summary>
        public Task SoftDeleteProduct(int productId);

        /// <summary>
        /// Gets all entitis based on the giving seach criteria
        /// </summary>
        /// <param name="seachString">The freetext seachstring</param>
        /// <param name="seachTag">The Tag dropdown seach</param>
        /// <param name="sortOrder">The sort order seach</param>
        /// <returns>A list of Products</returns>
        public Task<List<Product>> GetAllProductsWithSeach(int seachTag, int sortOrder, string seachString = null);
    }
}