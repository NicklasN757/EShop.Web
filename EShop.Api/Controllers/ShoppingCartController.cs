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
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public async Task<List<ShoppingCartDTO>> GetAllShoppingCart() => await _shoppingCartService.GetAllAsync();

        [HttpGet]
        [Route("{id}")]
        public async Task<ShoppingCartDTO> GetShoppingCart(int id) => await _shoppingCartService.GetByIdAsync(id);

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateShoppingCart(ShoppingCartModel shoppingCartModel)
        {
            try
            {
                ShoppingCartDTO updateShoppingCart = new();
                updateShoppingCart.ShoppingCartId = shoppingCartModel.ShoppingCartId;
                updateShoppingCart.TotalPrice = shoppingCartModel.TotalPrice;

                await _shoppingCartService.UpdateAsync(updateShoppingCart);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Create")]
        public async Task<IActionResult> CreateShoppingCart(ShoppingCartModel shoppingCartModel)
        {
            try
            {
                ShoppingCartDTO newShoppingCart = new();
                newShoppingCart.ShoppingCartId = shoppingCartModel.ShoppingCartId;

                await _shoppingCartService.CreateAsync(newShoppingCart);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}