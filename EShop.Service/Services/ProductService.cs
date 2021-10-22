using EShop.Repository.Entities;
using EShop.Repository.Interfaces;
using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        //Calls and logs the "GetAllProductsBySeachAsync" funtion from the ProductRepository
        public async Task<List<ProductDTO>> GetAllProductsBySeachAsync(string seachString)
        {
            try
            {
                List<ProductDTO> productDTOs = _mappingService._mapper.Map<List<ProductDTO>>(await _productRepository.GetAllProductsBySeachAsync(seachString));

                LogInformation($"Successfully retrieved all Products with the giving seachString - SeachString: {seachString}.");

                return productDTOs;
            }
            catch (Exception ex)
            {
                LogError($"Failed to retrieved all Products with the giving seachString - SeachString: {seachString} - ", ex);

                return null;
            }
        }

        //Calls and logs the "GetProductByIdWithPriceOffer" funtion from the ProductRepository
        public async Task<ProductDTO> GetProductByIdWithPriceOffer(int id)
        {
            try
            {
                ProductDTO productDTO = _mappingService._mapper.Map<ProductDTO>(await _productRepository.GetProductByIdWithPriceOffer(id));

                LogInformation($"Successfully retrieved a Product and its PriceOffer with the giving id - Id: {id}.");

                return productDTO;
            }
            catch (Exception ex)
            {
                LogError($"Failed to retrieved a Product and its PriceOffer with the giving id - Id: {id} - ", ex);

                return null;
            }
        }

        //Calls and logs the "GetProductByIdWithPriceOffer" funtion from the ProductRepository
        public async Task SoftDeleteProduct(int productId)
        {
            try
            {
                await _productRepository.SoftDeleteProduct(productId);

                LogInformation($"Successfully soft deleted a Product with the giving productId - ProductId: {productId}.");
            }
            catch (Exception ex)
            {
                LogError($"Failed to soft delete a Product with the giving productId - ProductId: {productId} - ", ex);
            }
        }
    }
}