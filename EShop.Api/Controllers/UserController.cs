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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<UserDTO>> GetAllUsers() => await _userService.GetAllAsync();

        [HttpGet]
        [Route("{id}")]
        public async Task<UserDTO> GetUser(int id) => await _userService.GetByIdAsync(id);

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateUser(UserModel userModel)
        {
            try
            {
                UserDTO updatedUser = new();
                updatedUser.UserId = userModel.UserId;
                updatedUser.Username = userModel.Username;
                updatedUser.Pin = userModel.Pin;
                updatedUser.IsAdmin = userModel.IsAdmin;

                await _userService.UpdateAsync(updatedUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Create")]
        public async Task<IActionResult> CreateUser(UserModel userModel)
        {
            try
            {
                UserDTO newUser = new();
                newUser.Username = userModel.Username;
                newUser.Pin = userModel.Pin;
                newUser.IsAdmin = userModel.IsAdmin;

                await _userService.CreateAsync(newUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}