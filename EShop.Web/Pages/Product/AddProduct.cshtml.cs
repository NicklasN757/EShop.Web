using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
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

        #region Properties
        [BindProperty, Required]
        public string Name { get; set; }
        [BindProperty, Required]
        public double Price { get; set; }
        [BindProperty, Required]
        public int TotalStock { get; set; }
        [BindProperty, Required]
        public string Description { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }
        #endregion

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
                    return RedirectToPage("../Index");
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostCreateProduct()
        {
            if (ModelState.IsValid)
            {
                ProductDTO productDTO = new();
                productDTO.Name = Name;
                productDTO.Price = Price;
                productDTO.TotalStock = TotalStock;
                productDTO.Description = Description;
                productDTO.ImgUrl = "product_0.jpg";

                await _productService.CreateAsync(productDTO);

                return RedirectToPage("../Index");
            }
            else
            {
                return Page();
            }
        }
    }
}