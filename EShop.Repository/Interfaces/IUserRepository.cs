using EShop.Repository.Entities;
using System.Threading.Tasks;

namespace EShop.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> GetUserByIdWithUserInformation(int id);
    }
}