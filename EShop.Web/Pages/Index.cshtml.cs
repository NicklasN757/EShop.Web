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

        public async Task<IActionResult> OnGetSeach(string SeachString)
        {
            ProductDTOs = await _productService.GetAllProductsBySeachAsync(SeachString);

            return Page();
        }

        public async Task<IActionResult> OnGet()
        {
            ProductDTOs = await _productService.GetAllAsync();

            return Page();
        }
    }
}