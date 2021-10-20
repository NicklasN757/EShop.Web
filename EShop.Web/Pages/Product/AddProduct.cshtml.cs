using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace EShop.Web.Pages.Product
{
    public class AddProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public AddProductModel(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }

        [BindProperty]
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
            }

            return Page();
        }
    }
}