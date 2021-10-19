using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.Web.Pages.Checkout
{
    public class ShoppingCartViewModel : PageModel
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartViewModel(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public ShoppingCartDTO ShoppingCart { get; set; }

        public List<ShoppingCartProductDTO> shoppingCartProducts { get; set; }

        public async Task<IActionResult> OnGet(int ShoppingCartId)
        {
            if (HttpContext.Session.GetInt32("_UserId") == null)
            {
                //For Debuging 
                ShoppingCart = await _shoppingCartService.GetShoppingCartByUser(1);
            }
            else
            {
                int tmpId = (int)HttpContext.Session.GetInt32("_UserId");
                await _shoppingCartService.CalculateTotalCartPrice(tmpId);
                ShoppingCart = await _shoppingCartService.GetShoppingCartByUser(tmpId);
            }
            
            return Page();
        }
    }
}
