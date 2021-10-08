using EShop.Repository.Domain;
using EShop.Repository.Repositories;
using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using EShop.Service.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Service.Services;
using Xunit;

namespace Tester
{
    public class UnitTest1
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IUserInformationService _userInformationService;

        public UnitTest1()
        {
            DbContextOptionsBuilder<EShopContext> builder = new();
            builder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = EShopDb; Trusted_Connection = True; ").EnableSensitiveDataLogging(true);
            EShopContext eShopContext = new(builder.Options);
           
            _userService = new UserService(new MappingService(), new UserRepository(eShopContext));
            _orderService = new OrderService(new MappingService(), new OrderRepository(eShopContext));
            _productService = new ProductService(new MappingService(), new ProductRepository(eShopContext));
            _shoppingCartService = new ShoppingCartService(new MappingService(), new ShoppingCartRepository(eShopContext));
            _userInformationService = new UserInformationService(new MappingService(), new UserInformationRepository(eShopContext));
        }

        //[Fact]
        //public async void TestUserService_CreateAndGetById()
        //{
        //    UserDTO userDTO = new();
        //    userDTO.Username = "TestUser";
        //    userDTO.Pin = 1234;

        //    await _userService.CreateAsync(userDTO);

        //    UserDTO testUser = testUser = await _userService.GetByIdAsync(4);
        //    testUser.UserId.Should().Be(4);
        //}

        //[Fact]
        //public async void TestUserService_GetAll()
        //{
        //    var testee = await _userService.GetAllAsync();

        //    testee.Count.Should().Be(4);
        //}

        //[Fact]
        //public async void TestUserService_UpdateAndGeyById()
        //{
        //    UserDTO userDTO = await _userService.GetByIdAsync(4);
        //    userDTO.Username = "TestUserChanged";

        //    await _userService.UpdateAsync(userDTO);

        //    UserDTO testUser = testUser = await _userService.GetByIdAsync(4);
        //    testUser.Username = "TestUserChanged";
        //}

        [Fact]
        public async void TestUserService_GetByIdWithUserInformation()
        {
            UserDTO userDTO = await _userService.GetUserByIdWithUserInformation(1);

            userDTO.UserInformation.FullName.Should().Be("Nicklas M Nielsen");
        }
    }
}