using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace EShop.Web.Pages
{
    public class UserLoginModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IUserInformationService _userInformationService;

        public UserLoginModel(IUserService userService, IUserInformationService userInformationService)
        {
            _userService = userService;
            _userInformationService = userInformationService;
        }

        [BindProperty]
        public UserDTO User { get; set; }

        public void OnGet()
        {
            //HttpContext.Session.SetString("_Username", "NicklasN757");

            //Username = HttpContext.Session.GetString("_Username");
        }

        public async Task<IActionResult> OnPostLogin(string username, int pin)
        {
            if (await _userService.UserLoginCheck(username, pin))
            {
                UserDTO tmpUser = await _userService.GetUserByUsername(username);

                string SessionUserUsername = "_Username";
                string SessionUserId = "_UserId";

                HttpContext.Session.SetString(SessionUserUsername, tmpUser.Username);
                HttpContext.Session.SetInt32(SessionUserId, tmpUser.UserId);

                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}