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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<List<OrderDTO>> GetAllOrders() => await _orderService.GetAllAsync();

        [HttpGet]
        [Route("{id}")]
        public async Task<OrderDTO> GetOrder(int id) => await _orderService.GetByIdAsync(id);

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateOrder(OrderModel orderModel)
        {
            try
            {
                OrderDTO updatedOrder = new();
                updatedOrder.FK_UserId = orderModel.FK_UserId;
                updatedOrder.FK_UserInformationId = orderModel.FK_UserInformationId;

                await _orderService.UpdateAsync(updatedOrder);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Create")]
        public async Task<IActionResult> CreateOrder(OrderModel orderModel)
        {
            try
            {
                OrderDTO newOrder = new();
                newOrder.FK_UserId = orderModel.FK_UserId;
                newOrder.FK_UserInformationId = orderModel.FK_UserInformationId;

                await _orderService.CreateAsync(newOrder);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}