using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IUserInformationService _userInformationService;

        public IndexModel(IProductService productService, IUserService userService, IUserInformationService userInformationService)
        {
            _productService = productService;
            _userService = userService;
            _userInformationService = userInformationService;
        }

        public List<ProductDTO> ProductDTOs { get; set; }

        public string WelcomeMeassage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SeachString { get; set; }

        public async Task<IActionResult> OnGet()
        {
            


            if (HttpContext.Session.GetInt32("_UserId") == null)
            {
                WelcomeMeassage = "Hello and welcome to my shop.";
            }
            else
            {
                int tmpId = (int)HttpContext.Session.GetInt32("_UserId");
                UserInformationDTO tmpUserInfo = await _userInformationService.GetByIdAsync(tmpId);

                WelcomeMeassage = "Hello " + tmpUserInfo.FullName + " and welcome back to my shop.";
            }

            ProductDTOs = await _productService.GetAllProductsBySeachAsync(SeachString);

            return Page();
        }
    }
}