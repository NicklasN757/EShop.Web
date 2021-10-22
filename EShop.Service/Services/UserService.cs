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

        //Calls and logs the "CreateAndReturnWithId" funtion from the UserRepository
        public async Task<int> CreateAndReturnWithId(UserDTO user)
        {
            try
            {
                int userId = await _userRepository.CreateAndReturnWithId(_mappingService._mapper.Map<User>(user));

                LogInformation($"Successfully created and returned the id of a new user - User: {user}");

                return userId;
            }
            catch (Exception ex)
            {
                LogError($"Failed to create and return the id of a new user - User: {user} - ", ex);

                return 0;
            }
        }

        //Calls and logs the "GetUserByIdWithUserInformation" funtion from the UserRepository
        public async Task<UserDTO> GetUserByIdWithUserInformation(int id)
        {
            try
            {
                UserDTO userDTO = _mappingService._mapper.Map<UserDTO>(await _userRepository.GetUserByIdWithUserInformation(id));

                LogInformation($"Successfully retrieved a User and its UserInformation with the giving id - Id: {id}.");

                return userDTO;
            }
            catch (Exception ex)
            {
                LogError($"Failed to retrieve a User and its UserInformation with the giving id - Id: {id}", ex);

                return null;
            }
        }

        //Calls and logs the "GetUserByUsername" funtion from the UserRepository
        public async Task<UserDTO> GetUserByUsername(string username)
        {
            try
            {
                UserDTO userDTO = _mappingService._mapper.Map<UserDTO>(await _userRepository.GetUserByUsername(username));

                LogInformation($"Successfully retrieved a User and its UserInformation with the giving username - Username: {username}.");

                return userDTO;
            }
            catch (Exception ex)
            {
                LogError($"Failed to retrieve a User and its UserInformation with the giving username - Username: {username} - ", ex);

                return null;
            }
        }

        //Calls and logs the "UserLoginCheck" funtion from the UserRepository
        public async Task<bool> UserLoginCheck(string username, int pin)
        {
            try
            {
                bool userIsLegit = await _userRepository.UserLoginCheck(username, pin);

                LogInformation($"Successfully checked if the giving Username and Pin exists in the Users table in the database - Uername: {username}, Pin: {pin}.");

                return userIsLegit;
            }
            catch (Exception ex)
            {
                LogError($"Failed to check if the giving Username and Pin exists in the Users table in the database - Uername: {username}, Pin: {pin} - ", ex);

                return false;
            }
        }
    }
}