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

                LogInformation($"Successfully retrieved a ShoppingCart with the giving userId - UserId: {userId}.");

                return shoppingCartDTO;
            }
            catch (Exception ex)
            {
                LogError($"Failed to retrieved a ShoppingCart with the giving userId - UserId: {userId} - ", ex);

                return null;
            }
        }

        //Calls and logs the "AddProductToShoppingCart" funtion from the ShoppingCartRepository
        public async Task AddProductToShoppingCart(int productId, int shoppingCartId)
        {
            try
            {
                await _shoppingCartRepository.AddProductToShoppingCart(productId, shoppingCartId);

                LogInformation($"Successfully added a new Product to the shoppingCart with the giving information - Information - ProductId: {productId}, ShoppingCartId: {shoppingCartId}.");
            }
            catch (Exception ex)
            {
                LogError($"Failed to add a new Product to the shoppingCart with the giving information - Information - ProductId: {productId}, ShoppingCartId: {shoppingCartId} - ", ex);
            }
        }

        //Calls and logs the "RemoveProductFromShoppingCart" funtion from the ShoppingCartRepository
        public async Task RemoveProductFromShoppingCart(int shoppingCartProductId)
        {
            try
            {
                await _shoppingCartRepository.RemoveProductFromShoppingCart(shoppingCartProductId);

                LogInformation($"Successfully removed a Product from the shoppingCart with the giving shoppingCartProductId - ShoppingCartProductId: {shoppingCartProductId}.");
            }
            catch (Exception ex)
            {
                LogError($"Failed to remove a Product from the shoppingCart with the giving shoppingCartProductId - ShoppingCartProductId: {shoppingCartProductId} - ", ex);
            }
        }

        //Calls and logs the "CalculateTotalCartPrice" funtion from the ShoppingCartRepository
        public async Task CalculateTotalCartPrice(int shoppingCartId)
        {
            try
            {
                await _shoppingCartRepository.CalculateTotalCartPrice(shoppingCartId);

                LogInformation($"Successfully calculated the total cart price with the giving shoppingCartId - ShoppingCartId: {shoppingCartId}.");
            }
            catch (Exception ex)
            {
                LogError($"Failed to calculate the total cart price with the giving shoppingCartId - ShoppingCartId: {shoppingCartId} - ", ex);
            }
        }

        //Calls and logs the "ClearCart" funtion from the ShoppingCartRepository
        public async Task ClearCart(int shoppingCartId)
        {
            try
            {
                await _shoppingCartRepository.ClearCart(shoppingCartId);

                LogInformation($"Successfully cleared the cart with the giving shoppingCartId - ShoppingCartId: {shoppingCartId}");
            }
            catch (Exception ex)
            {
                LogError($"Failed to clear the cart with the giving shoppingCartId - ShoppingCartId: {shoppingCartId} - ", ex);
            }
        }
    }
}