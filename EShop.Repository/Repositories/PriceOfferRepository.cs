using EShop.Repository.Domain;
using EShop.Repository.Entities;

namespace EShop.Repository.Repositories
{
    public class PriceOfferRepository : GenericRepository<PriceOffer>
    {
        private readonly EShopContext _dbContext;
        public PriceOfferRepository(EShopContext eShopContext) : base(eShopContext) => _dbContext = eShopContext;
    }
}