using EShop.Repository.Interfaces;
using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using EShop.Service.Services;
using FluentAssertions;
using Service.Services;
using Xunit;

namespace Tester
{
    public class UnitTest1
    {
        private readonly IUserService _userService;
        
        public UnitTest1(IUserService userService)
        {
            _userService = userService;
        }

        [Fact]
        public async void Test1()
        {

            UserDTO testUser = await _userService.GetByIdAsync(1);

            testUser.UserId.Should().Be(1);
        }
    }
}