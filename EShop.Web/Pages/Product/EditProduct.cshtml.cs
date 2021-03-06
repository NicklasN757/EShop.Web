using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace EShop.Web.Pages.Product
{
    public class EditProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public EditProductModel(IProductService productService, IUserService userService)
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

                Product = await _productService.GetProductByIdWithAll(ProductId);

            }

            return Page();
        }

        //Updates the product
        public async Task<IActionResult> OnPostUpdateProduct(int ProductId)
        {
            ProductDTO productDTO = await _productService.GetProductByIdWithAll(ProductId);
            productDTO.Name = Product.Name;
            productDTO.Description = Product.Description;
            productDTO.Price = Product.Price;
            productDTO.TotalStock = Product.TotalStock;

            await _productService.UpdateAsync(productDTO);

            return RedirectToPage("ProductDetails", new { ProductId = ProductId });
        }
    }
}