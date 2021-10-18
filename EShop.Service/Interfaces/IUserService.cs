using EShop.Service.DataTransferObjects;
using System.Threading.Tasks;

namespace EShop.Service.Interfaces
{
    public interface IUserService : IGenericService<UserDTO>
    {
        /// <summary>
        /// Gets a User and its UserInformation, base on id
        /// </summary>
        /// <returns>A User</returns>
        public Task<UserDTO> GetUserByIdWithUserInformation(int id);

        /// <summary>
        /// Gets a user and its UserInFormation, based on username
        /// </summary>
        /// <returns>A User</returns>
        public Task<UserDTO> GetUserByUsername(string username);

        /// <summary>
        /// check if the giving username and pin code is right and does exsist in the database
        /// </summary>
        /// <returns>A boolean</returns>
        public Task<bool> UserLoginCheck(string username, int pin);
    }
}