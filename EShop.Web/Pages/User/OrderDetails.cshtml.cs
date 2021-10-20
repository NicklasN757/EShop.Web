using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.Web.Pages.User
{
    public class OrderDetailsModel : PageModel
    {
        private readonly IOrderService _orderService;

        public OrderDetailsModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public OrderDTO Order { get; set; }

        //Runs when the site loads
        public async Task<IActionResult> OnGet(int OrderId)
        {
            Order = await _orderService.GetOrderByIdWithAll(OrderId);

            return Page();
        }
    }
}
