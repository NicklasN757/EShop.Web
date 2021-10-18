using EShop.Repository.Entities;
using System.Threading.Tasks;

namespace EShop.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        /// Gets a User and its UserInformation, base on id
        /// </summary>
        /// <returns>A User</returns>
        public Task<User> GetUserByIdWithUserInformation(int id);

        /// <summary>
        /// Gets a user and its UserInFormation, based on username
        /// </summary>
        /// <returns>A User</returns>
        public Task<User> GetUserByUsername(string username);

        /// <summary>
        /// check if the giving username and pin code is right and does exsist in the database
        /// </summary>
        /// <returns>A boolean</returns>
        public Task<bool> UserLoginCheck(string username, int pin);
    }
}