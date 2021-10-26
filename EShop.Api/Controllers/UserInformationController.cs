using EShop.Api.Models;
using EShop.Service.DataTransferObjects;
using EShop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserInformationController : ControllerBase
    {
        private readonly IUserInformationService _userInformationService;

        public UserInformationController(IUserInformationService userInformationService)
        {
            _userInformationService = userInformationService;
        }

        [HttpGet]
        public async Task<List<UserInformationDTO>> GetAllUserInformations() => await _userInformationService.GetAllAsync();

        [HttpGet]
        [Route("{id}")]
        public async Task<UserInformationDTO> GetUserInformation(int id) => await _userInformationService.GetByIdAsync(id);

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateUserInformation(UserInformationModel userInformationModel)
        {
            try
            {
                UserInformationDTO updatedUserInformation = new();
                updatedUserInformation.UserId = userInformationModel.UserId;
                updatedUserInformation.FullName = userInformationModel.FullName;
                updatedUserInformation.City = userInformationModel.City;
                updatedUserInformation.Adress = userInformationModel.Adress;
                updatedUserInformation.EMail = userInformationModel.EMail;

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Create")]
        public async Task<IActionResult> CreateUserInformation(UserInformationModel userInformationModel)
        {
            try
            {
                UserInformationDTO newUserInformation = new();
                newUserInformation.FullName = userInformationModel.FullName;
                newUserInformation.City = userInformationModel.City;
                newUserInformation.Adress = userInformationModel.Adress;
                newUserInformation.EMail = userInformationModel.EMail;

                await _userInformationService.CreateAsync(newUserInformation);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}