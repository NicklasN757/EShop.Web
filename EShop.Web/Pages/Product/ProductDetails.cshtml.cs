using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace EShop.Web.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IUserService _userService;

        public ProductDetailsModel(IProductService productService, IShoppingCartService shoppingCartService, IUserService userService)
        {
            _productService = productService;
            _shoppingCartService = shoppingCartService;
            _userService = userService;
        }

        public ProductDTO Product { get; set; }
        public UserDTO AppUser { get; set; }

        //Runs when the site loads
        public async Task<IActionResult> OnGet(int ProductId)
        {
            if (HttpContext.Session.GetInt32("_UserId") != null)
            {
                int tmpId = (int)HttpContext.Session.GetInt32("_UserId");
                AppUser = await _userService.GetByIdAsync(tmpId);
            }

            Product = await _productService.GetProductByIdWithAll(ProductId);

            return Page();
        }

        //Adds a product to the shopping cart
        public async Task<IActionResult> OnPostAddToCart(int productId)
        {
            int tmpId = (int)HttpContext.Session.GetInt32("_UserId");

            await _shoppingCartService.AddProductToShoppingCart(productId, tmpId);

            return RedirectToPage();
        }
    }
}