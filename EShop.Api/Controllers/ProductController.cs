using EShop.Api.Models;
using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<ProductDTO>> GetAllProducts() => await _productService.GetAllAsync();

        [HttpGet]
        [Route("{id}")]
        public async Task<ProductDTO> GetProduct(int id) => await _productService.GetByIdAsync(id);

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateProduct(ProductModel productModel)
        {
            try
            {
                ProductDTO updatedProduct = new();
                updatedProduct.ProductId = productModel.ProductId;
                updatedProduct.Name = productModel.Name;
                updatedProduct.Description = productModel.Description;
                updatedProduct.Price = productModel.Price;
                updatedProduct.InStock = productModel.InStock;
                updatedProduct.TotalStock = productModel.TotalStock;
                updatedProduct.IsDeleted = productModel.IsDeleted;

                await _productService.UpdateAsync(updatedProduct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Create")]
        public async Task<IActionResult> CreateProduct(ProductModel productModel)
        {
            try
            {
                ProductDTO newProduct = new();
                newProduct.Name = productModel.Name;
                newProduct.Description = productModel.Description;
                newProduct.Price = productModel.Price;
                newProduct.InStock = productModel.InStock;
                newProduct.TotalStock = productModel.TotalStock;

                await _productService.CreateAsync(newProduct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}