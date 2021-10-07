using EShop.Repository.Entities;
using EShop.Repository.Interfaces;
using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Service.Services;

namespace EShop.Service.Services
{
    public class ProductService : GenericService<ProductDTO, IProductRepository, Product>, IProductService
    {
        private readonly MappingService _mappingService;
        private readonly IProductRepository _productRepository;

        public ProductService(MappingService mappingService, IProductRepository productRepository) : base(mappingService, productRepository)
        {
            _mappingService = mappingService;
            _productRepository = productRepository;
        }
    }
}