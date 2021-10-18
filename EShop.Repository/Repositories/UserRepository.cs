using EShop.Repository.Domain;
using EShop.Repository.Entities;
using EShop.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EShop.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly EShopContext _dbContext;
        public UserRepository(EShopContext eShopContext) : base(eShopContext) => _dbContext = eShopContext;

        //Gets a user with all the user information
        public async Task<User> GetUserByIdWithUserInformation(int id) => await _dbContext.Users.AsNoTracking().Include(u => u.UserInformation).SingleAsync(u => u.UserId == id);

        //Gets a user by its username
        public async Task<User> GetUserByUsername(string username) => await _dbContext.Users.AsNoTracking().SingleAsync(u => u.Username == username);

        //Check if the username and pin is in the database
        public async Task<bool> UserLoginCheck(string username, int pin)
        {
            User tmpUser = await GetUserByUsername(username);

            if (tmpUser.Pin == pin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}