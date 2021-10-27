using EShop.Repository.Domain;
using EShop.Repository.Entities;
using EShop.Repository.Interfaces;

namespace EShop.Repository.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        private readonly EShopContext _dbContext;
        public TagRepository(EShopContext eShopContext) : base(eShopContext) => _dbContext = eShopContext;
    }
}