using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IUserInformationService _userInformationService;
        private readonly IShoppingCartService _shoppingCartService;

        public IndexModel(IProductService productService, IUserService userService, IUserInformationService userInformationService, IShoppingCartService shoppingCartService)
        {
            _productService = productService;
            _userService = userService;
            _userInformationService = userInformationService;
            _shoppingCartService = shoppingCartService;
        }

        public List<ProductDTO> ProductDTOs { get; set; }

        public string WelcomeMeassage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SeachString { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public int OrderBy { get; set; }

        //Runs when the site loads
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetInt32("_UserId") == null)
            {
                WelcomeMeassage = "Hello and welcome to my shop please make a account or login to buy.";
            }
            else
            {
                int tmpId = (int)HttpContext.Session.GetInt32("_UserId");
                UserInformationDTO tmpUserInfo = await _userInformationService.GetByIdAsync(tmpId);

                WelcomeMeassage = "Hello " + tmpUserInfo.FullName + " and welcome back to my shop.";
            }

            ProductDTOs = await _productService.GetAllProductsBySeachAsync(SeachString);

            //if (OrderBy == 1)
            //{
            //    ProductDTOs.OrderBy(p => p.Price);
            //}
            //else if(OrderBy == 2)
            //{
            //    ProductDTOs.OrderByDescending(p => p.Price);
            //}

            return Page();
        }

        //Add a product to the shopping cart and then redirect to it the shopping cart view 
        public async Task<IActionResult> OnPostBuyNow(int productId)
        {
            if (HttpContext.Session.GetInt32("_UserId") == null)
            {
                return RedirectToPage("User/UserLogin");
            }
            else
            {
                int tmpId = (int)HttpContext.Session.GetInt32("_UserId");

                await _shoppingCartService.AddProductToShoppingCart(productId, tmpId);
                
                return RedirectToPage("Checkout/ShoppingCartView");
            }
        }

    }
}