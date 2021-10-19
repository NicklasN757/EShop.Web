using EShop.Repository.Entities;
using EShop.Repository.Interfaces;
using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Service.Services;
using System;
using System.Threading.Tasks;

namespace EShop.Service.Services
{
    public class ShoppingCartService : GenericService<ShoppingCartDTO, IShoppingCartRepository, ShoppingCart>, IShoppingCartService
    {
        private readonly MappingService _mappingService;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(MappingService mappingService, IShoppingCartRepository shoppingCartRepository) : base(mappingService, shoppingCartRepository)
        {
            _mappingService = mappingService;
            _shoppingCartRepository = shoppingCartRepository;
        }

        //Calls and logs the "GetShoppingCartByUser" funtion from the ShoppingCartRepository
        public async Task<ShoppingCartDTO> GetShoppingCartByUser(int userId)
        {
            try
            {
                ShoppingCartDTO shoppingCartDTO = _mappingService._mapper.Map<ShoppingCartDTO>(await _shoppingCartRepository.GetShoppingCartByUser(userId));

                return shoppingCartDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        //Calls and logs the "AddProductToShoppingCart" funtion from the ShoppingCartRepository
        public async Task AddProductToShoppingCart(int productId, int shoppingCartId)
        {
            try
            {
                await _shoppingCartRepository.AddProductToShoppingCart(productId, shoppingCartId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //Calls and logs the "RemoveProductFromShoppingCart" funtion from the ShoppingCartRepository
        public async Task RemoveProductFromShoppingCart(int shoppingCartProductId)
        {
            try
            {
                await _shoppingCartRepository.RemoveProductFromShoppingCart(shoppingCartProductId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task CalculateTotalCartPrice(int shoppingCartId)
        {
            try
            {
                await _shoppingCartRepository.CalculateTotalCartPrice(shoppingCartId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}