using EShop.Service.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Service.Interfaces
{
    public interface IProductService : IGenericService<ProductDTO>
    {
        public Task<List<ProductDTO>> GetAllProductsBySeachAsync(string seachString);
    }
}