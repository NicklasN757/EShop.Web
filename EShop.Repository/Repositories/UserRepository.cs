using EShop.Repository.Domain;
using EShop.Repository.Entities;
using EShop.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly EShopContext _dbContext;
        public UserRepository(EShopContext eShopContext) : base(eShopContext) => _dbContext = eShopContext;

        public async Task<User> GetUserByIdWithUserInformation(int id) => await _dbContext.Users.AsNoTracking().Include(u => u.UserInformation).SingleAsync(u => u.UserId == id);
    }
}