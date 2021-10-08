using EShop.Repository.Entities;
using EShop.Repository.Interfaces;
using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Service.Services;
using System;
using System.Threading.Tasks;

namespace EShop.Service.Services
{
    public class UserService : GenericService<UserDTO, IUserRepository, User>, IUserService
    {
        private readonly MappingService _mappingService;
        private readonly IUserRepository _userRepository;

        public UserService(MappingService mappingService, IUserRepository userRepository) : base(mappingService, userRepository)
        {
            _mappingService = mappingService;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> GetUserByIdWithUserInformation(int id)
        {
            try
            {
                UserDTO userDTO = _mappingService._mapper.Map<UserDTO>(await _userRepository.GetUserByIdWithUserInformation(id));

                return userDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}