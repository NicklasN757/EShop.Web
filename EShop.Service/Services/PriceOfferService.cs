using EShop.Repository.Entities;
using EShop.Repository.Interfaces;
using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Service.Services;

namespace EShop.Service.Services
{
    public class PriceOfferService : GenericService<PriceOfferDTO, IPriceOfferRepository, PriceOffer>, IPriceOfferService
    {
        private readonly MappingService _mappingService;
        private readonly IPriceOfferRepository _PriceOfferRepository;

        public PriceOfferService(MappingService mappingService, IPriceOfferRepository priceOfferRepository) : base(mappingService, priceOfferRepository)
        {
            _mappingService = mappingService;
            _PriceOfferRepository = priceOfferRepository;
        }
    }
}