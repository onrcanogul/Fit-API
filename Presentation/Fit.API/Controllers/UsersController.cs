using Fit.Application.Abstractions.Services;
using Fit.Application.DTOs;
using Fit.Application.DTOs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(int page, int size)
        {
            ListDto users = await _userService.GetUsersAsync(page, size);
            return Ok(users);
        }
        [HttpGet("user-id")]
        public async Task<IActionResult> GetUserById([FromQuery]string id)
        {
            UserDto user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto user)
        {
            await _userService.CreateUserAsync(user);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody]UpdateUserDto user)
        {
            await _userService.UpdateUserAsync(user);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
