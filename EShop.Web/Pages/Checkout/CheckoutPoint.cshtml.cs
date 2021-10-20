using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.Web.Pages.Checkout
{
    public class CheckoutPointModel : PageModel
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IUserService _userService;
        private readonly IUserInformationService _userInformationService;
        private readonly IOrderService _orderService;
        

        public CheckoutPointModel(IShoppingCartService shoppingCartService, IUserService userService, IUserInformationService userInformationService, IOrderService orderService)
        {
            _shoppingCartService = shoppingCartService;
            _userService = userService;
            _userInformationService = userInformationService;
            _orderService = orderService;
        }

        //User
        public UserDTO AppUser { get; set; }
        [BindProperty]
        public UserInformationDTO UserInformation { get; set; }

        //Other
        public ShoppingCartDTO ShoppingCart { get; set; }

        //Runs when the site loads
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetInt32("_UserId") == null)
            {
                return RedirectToPage("../User/UserLogin");
            }
            else
            {
                int tmpId = (int)HttpContext.Session.GetInt32("_UserId");
                ShoppingCart = await _shoppingCartService.GetShoppingCartByUser(tmpId);
                AppUser = await _userService.GetByIdAsync(tmpId);
                UserInformation = await _userInformationService.GetByIdAsync(tmpId);
            }
            return Page();
        }

        //Confirms the order
        public async Task<IActionResult> OnPostConfirmOrder()
        {
            int tmpId = (int)HttpContext.Session.GetInt32("_UserId");
            ShoppingCart = await _shoppingCartService.GetShoppingCartByUser(tmpId);

            OrderDTO newOrder = new();
            newOrder.FK_UserId = tmpId;
            newOrder.FK_UserInformationId = tmpId;
            newOrder.TotalOrderPrice = ShoppingCart.TotalPrice;

            newOrder = await _orderService.CreateAndReturnOrder(newOrder);
            await _orderService.ConvertShoppingCartToOrder(ShoppingCart.ShoppingCartProducts, newOrder.OrderId);

            await _shoppingCartService.ClearCart(tmpId);

            return RedirectToPage("ThankYou");
        }

        //Update the user information
        public async Task<IActionResult> OnPostUpdateUserInformation(int userId)
        {
            UserInformationDTO userInformationDTO = new();
            userInformationDTO.UserId = userId;
            userInformationDTO.FullName = UserInformation.FullName;
            userInformationDTO.City = UserInformation.City;
            userInformationDTO.Adress = UserInformation.Adress;
            userInformationDTO.EMail = UserInformation.EMail;

            await _userInformationService.UpdateAsync(userInformationDTO);
            return RedirectToPage();
        }
    }
}