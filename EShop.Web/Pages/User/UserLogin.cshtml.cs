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

        //User
        public UserDTO AppUser { get; set; }
        public UserInformationDTO UserInformation { get; set; }

        //Other
        public bool LoggedIn { get; set; }

        //Runs when the site loads
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetInt32("_UserId") == null)
            {
                LoggedIn = false;
            }
            else
            {
                LoggedIn = true;

                int tmpId = (int)HttpContext.Session.GetInt32("_UserId");

                UserInformation = await _userInformationService.GetByIdAsync(tmpId);
                AppUser = await _userService.GetByIdAsync(tmpId);
            }
            return Page();
        }

        //Runs when the user is clicking on the login button
        public async Task<IActionResult> OnPostLogin(string username, int pin)
        {
            if (await _userService.UserLoginCheck(username, pin))
            {
                UserDTO tmpUser = await _userService.GetUserByUsername(username);

                const string SessionUserUsername = "_Username";
                const string SessionUserId = "_UserId";

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