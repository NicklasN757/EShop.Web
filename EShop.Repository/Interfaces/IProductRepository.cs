using EShop.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Repository.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task<List<Product>> GetAllProductsBySeachAsync(string seachString);
    }
}