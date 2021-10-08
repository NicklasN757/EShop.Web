using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace EShop.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IUserInformationService _userInformationService;

        public IndexModel(
            IUserService userService, 
            IOrderService orderService, 
            IProductService productService, 
            IShoppingCartService shoppingCartService, 
            IUserInformationService userInformationService)
        {
            _userService = userService;
            _orderService = orderService;
            _productService = productService;
            _shoppingCartService = shoppingCartService;
            _userInformationService = userInformationService;
        }

        [BindProperty]
        public UserDTO TestUser { get; set; }

        public async Task<IActionResult> OnGet()
        {
            TestUser = await _userService.GetByIdAsync(1);

            return Page();
        }
    }
}