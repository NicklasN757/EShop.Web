using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<ProductDTO> ProductDTOs { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SeachString { get; set; }

        public async Task<IActionResult> OnGet()
        {
            ProductDTOs = await _productService.GetAllProductsBySeachAsync(SeachString);

            return Page();
        }
    }
}