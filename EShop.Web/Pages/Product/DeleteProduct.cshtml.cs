using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace EShop.Web.Pages.Product
{
    public class DeleteProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public DeleteProductModel(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }

        public ProductDTO Product { get; set; }

        //Runs when the site loads
        public async Task<IActionResult> OnGet(int ProductId)
        {
            if (HttpContext.Session.GetInt32("_UserId") == null)
            {
                return RedirectToPage("../User/UserLogin");
            }
            else
            {
                UserDTO tmpUser = await _userService.GetByIdAsync((int)HttpContext.Session.GetInt32("_UserId"));
                if (!tmpUser.IsAdmin)
                {
                    return RedirectToPage("../Product/ProductDetails");
                }

                Product = await _productService.GetByIdAsync(ProductId);
            }

            return Page();
        }

        //Deletes the Product
        public async Task<IActionResult> OnPostConfirmProductDelete(int ProductId)
        {
            await _productService.SoftDeleteProduct(ProductId);

            return RedirectToPage("../Index");
        }
    }
}