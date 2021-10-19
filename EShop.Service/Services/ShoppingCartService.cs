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

        //public async Task AddProductToShoppingCartByProductId(int productId, int shoppingCartId)
        //{
        //    try
        //    {
        //        await _shoppingCartRepository.AddProductToShoppingCartByProductId(productId, shoppingCartId);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //    }
        //}
    }
}