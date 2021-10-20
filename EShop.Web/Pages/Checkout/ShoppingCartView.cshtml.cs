using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        //Runs when the site loads
        public async Task<IActionResult> OnGet(int ShoppingCartId)
        {
            if (HttpContext.Session.GetInt32("_UserId") == null)
            {
                return RedirectToPage("../User/UserLogin");
            }
            else
            {
                int tmpId = (int)HttpContext.Session.GetInt32("_UserId");
                ShoppingCart = await _shoppingCartService.GetShoppingCartByUser(tmpId);
            }
            return Page();
        }

        //Clears the cart for all products
        public async Task<IActionResult> OnPostClearCart()
        {
            int tmpId = (int)HttpContext.Session.GetInt32("_UserId");

            await _shoppingCartService.ClearCart(tmpId);
            return RedirectToPage("../Index");
        }

        //Remove a single product from the cart
        public async Task<IActionResult> OnPostRemoveProduct(int shoppingCartProductId)
        {
            await _shoppingCartService.RemoveProductFromShoppingCart(shoppingCartProductId);
            return RedirectToPage();
        }
    }
}