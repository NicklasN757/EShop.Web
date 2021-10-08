using EShop.Service.DataTransferObjects;
using System.Threading.Tasks;

namespace EShop.Service.Interfaces
{
    public interface IUserService : IGenericService<UserDTO>
    {
        public Task<UserDTO> GetUserByIdWithUserInformation(int id);
    }
}