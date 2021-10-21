using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.Web.Pages.User
{
    public class CreateUserModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IUserInformationService _userInformationService;
        private readonly IShoppingCartService _shoppingCartService;

        public CreateUserModel(IUserService userService, IUserInformationService userInformationService, IShoppingCartService shoppingCartService)
        {
            _userService = userService;
            _userInformationService = userInformationService;
            _shoppingCartService = shoppingCartService;
        }

        #region Properties
        [BindProperty, Required]
        public string Username { get; set; }
        [BindProperty, Required]
        public int Pin { get; set; }
        [BindProperty, Required, Compare(nameof(Pin))]
        public int PinRepeat { get; set; }
        [BindProperty, Required]
        public string FullName { get; set; }
        [BindProperty, Required]
        public string City { get; set; }
        [BindProperty, Required]
        public string Adress { get; set; }
        [BindProperty, Required]
        public string EMail { get; set; }
        #endregion

        //Runs when the site loads
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        //Creates a new user
        public async Task<IActionResult> OnPostCreateUser()
        {
            if (ModelState.IsValid)
            {
                UserDTO userDTO = new();
                userDTO.Username = Username;
                userDTO.Pin = Pin;
                userDTO.UserId = await _userService.CreateAndReturnWithId(userDTO);

                UserInformationDTO userInformationDTO = new();
                userInformationDTO.UserId = userDTO.UserId;
                userInformationDTO.FullName = FullName;
                userInformationDTO.City = City;
                userInformationDTO.Adress = Adress;
                userInformationDTO.EMail = EMail;

                await _userInformationService.CreateAsync(userInformationDTO);

                ShoppingCartDTO shoppingCartDTO = new();
                shoppingCartDTO.ShoppingCartId = userDTO.UserId;

                await _shoppingCartService.CreateAsync(shoppingCartDTO);

                return RedirectToPage("UserLogin");
            }
            else
            {
                return Page();
            }
            
        }
    }
}