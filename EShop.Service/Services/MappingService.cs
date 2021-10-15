using System;
using EShop.Repository.Entities;
using EShop.Service.DataTransferObjects;
using Service.Services.Base;

namespace Service.Services
{
    /// <summary>
    /// The MappingService. Used for Automapper so only 1 mapper is needed.
    /// </summary>
    public class MappingService : BaseService
    {
        public readonly AutoMapper.IMapper _mapper;
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingService"/> class.
        /// </summary>
        public MappingService()
        {
            AutoMapper.MapperConfiguration mapperConfig = new AutoMapper.MapperConfiguration(cfg =>
            {
                #region Class Mappings
                // Order
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderDTO, Order>();

                // Product
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, Product>();

                // PriceOffer
                cfg.CreateMap<PriceOffer, PriceOfferDTO>();
                cfg.CreateMap<PriceOfferDTO, PriceOffer>();

                // ShoppingCart
                cfg.CreateMap<ShoppingCart, ShoppingCartDTO>();
                cfg.CreateMap<ShoppingCartDTO, ShoppingCart>();

                // User
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();

                // UserInformation
                cfg.CreateMap<UserInformation, UserInformationDTO>();
                cfg.CreateMap<UserInformationDTO, UserInformation>();
                #endregion
            });

            try
            {
                _mapper = mapperConfig.CreateMapper();
            }
            catch (Exception ex)
            {
                LogError("Failed to create mappings", ex);
            }

        }
    }
}