using EShop.Repository.Entities;
using EShop.Repository.Interfaces;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tester
{
    public class UnitTest1
    {
        private readonly IUserRepository _userRepository;
        
        public UnitTest1(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Fact]
        public async void Test1()
        {
            User testUser = await _userRepository.GetByIdAsync(1);

            testUser.UserId.Should().Be(1);
        }
    }
}