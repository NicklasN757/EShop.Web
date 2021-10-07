using EShop.Repository.Entities;
using EShop.Repository.Interfaces;
using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Service.Services;

namespace EShop.Service.Services
{
    public class UserInformationService : GenericService<UserInformationDTO, IUserInformationRepository, UserInformation>, IUserInformationService
    {
        private readonly MappingService _mappingService;
        private readonly IUserInformationRepository _userInformationRepository;

        public UserInformationService(MappingService mappingService, IUserInformationRepository userInformationRepository) : base(mappingService, userInformationRepository)
        {
            _mappingService = mappingService;
            _userInformationRepository = userInformationRepository;
        }
    }
}