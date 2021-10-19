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

        public ProductDetailsModel(IProductService productService, IShoppingCartService shoppingCartService)
        {
            _productService = productService;
            _shoppingCartService = shoppingCartService;
        }

        public ProductDTO Product { get; set; }

        public async Task<IActionResult> OnGet(int ProductId)
        {
            Product = await _productService.GetProductByIdWithPriceOffer(ProductId);

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCart(int ProductId)
        {
            int tmpId = (int)HttpContext.Session.GetInt32("_UserId");

            await _shoppingCartService.AddProductToShoppingCart(ProductId, tmpId);

            return RedirectToPage();
        }
    }
}