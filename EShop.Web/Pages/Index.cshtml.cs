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

        public IndexModel(IUserService userService)
        {
            _userService = userService;
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
