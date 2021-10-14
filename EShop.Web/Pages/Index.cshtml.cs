﻿using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
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

        public List<ProductDTO> ProductDTOs { get; set; }

        public async Task<IActionResult> OnGet()
        {
            TestUser = await _userService.GetByIdAsync(1);

            ProductDTOs = await _productService.GetAllAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostTest()
        {
            return Page();
        }
    }
}