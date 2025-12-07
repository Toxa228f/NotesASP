using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notes.Domain.Entities;
using Notes.Domain.Interfaces;
using Notes.Service.Implementations;
using Notes.Service.Interfaces;
using static Notes.Domain.DTOs.UserDTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService service;
        public UsersController(IUsersService service) => this.service = service;


        [Authorize]
        [HttpGet("GetMe")]
        public async Task<IActionResult> GetUser()
        {
            string userId = User.FindFirst("userId")?.Value;
            if (userId == null) return Unauthorized();

            IBaseResponse<User> response = await service.SelectByIdAsync(Guid.Parse(userId));
            if (response.Data == null) return NotFound("Пользователь не найден");

            return Ok(new UserResponseDto
            {
                Id = response.Data.Id,
                Login = response.Data.Login,
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            User user = new()
            {
                Login = dto.Login,
                Password = dto.Password
            };

            IBaseResponse<bool> response = await service.CreateAsync(user);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            IBaseResponse<User> response = await service.GetByLoginAndPasswordAsync(dto.Login, dto.Password);
            if (response.Data == null) return Unauthorized("Неверный логин или пароль");

            // TODO JWT
            return Ok(new UserResponseDto
            {
                Id = response.Data.Id,
                Login = response.Data.Login
            });
        }
    }
}
