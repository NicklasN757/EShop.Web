using EShop.Service.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Service.Interfaces
{
    public interface IProductService : IGenericService<ProductDTO>
    {
        /// <summary>
        /// Gets all entitis based on giving seachString
        /// </summary>
        /// <returns>A list of products</returns>
        public Task<List<ProductDTO>> GetAllProductsBySeachAsync(string seachString);

        /// <summary>
        /// Get a specefic entity with PriceOffer based on id
        /// </summary>
        /// <returns>A Product</returns>
        public Task<ProductDTO> GetProductByIdWithAll(int id);

        /// <summary>
        /// Soft deletes a specific product based on productId 
        /// </summary>
        public Task SoftDeleteProduct(int productId);
    }
}