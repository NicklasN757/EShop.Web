using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Web.Pages.User
{
    public class UserOrderViewModel : PageModel
    {
        private readonly IOrderService _orderService;

        public UserOrderViewModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public List<OrderDTO> UserOrders { get; set; }

        //Runs when the site loads
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetInt32("_UserId") == null)
            {
                return RedirectToPage("UserLogin");
            }
            else
            {
                int tmpId = (int)HttpContext.Session.GetInt32("_UserId");
                UserOrders = await _orderService.GetAllOrdersByUser(tmpId);
            }
            return Page();
        }
    }
}
