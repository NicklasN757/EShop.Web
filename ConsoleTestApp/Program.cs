using EShop.Repository.Domain;
using EShop.Repository.Entities;
using EShop.Repository.Interfaces;
using EShop.Repository.Repositories;
using System;

namespace ConsoleTestApp
{
    class Program
    {
        private static UserRepository _userRepository;

        static void Main(string[] args)
        {
            PrintId(1);   
        }

        public static async void PrintId(int id)
        {
            _userRepository = new(new EShopContext());
            User user = await _userRepository.GetByIdAsync(id);
            Console.WriteLine(user.UserId);
        }
    }
}