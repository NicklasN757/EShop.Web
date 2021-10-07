using EShop.Repository.Domain;
using EShop.Repository.Entities;
using EShop.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Repository.Repositories
{
    public class UserInformationRepository : GenericRepository<UserInformation>, IUserInformationRepository
    {
        private readonly EShopContext _dbContext;
        public UserInformationRepository(EShopContext eShopContext) : base(eShopContext) => _dbContext = eShopContext;
    }
}