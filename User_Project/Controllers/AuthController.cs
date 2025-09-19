using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserProject.API.Services;
using UserProject.Core.Dtos;
using UserProject.Core.Interfaces;

namespace UserProject.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtService _jwtService;

        public AuthController(IUserService userService,JwtService jwtService)
        {
            _userService = userService; 
            _jwtService = jwtService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userService.LoginAsync(dto);
            if (user == null)
            {
                return Unauthorized(new { message = "Kullanıcı veya şifre hatalı!" });
            }


            var token = _jwtService.GenerateToken(user.Id.ToString(), user.Username, user.RoleName);

            return Ok(new
            {
                acces_token=token,
                token_type="Bearer",
                expires_in_minutes=30
            });
        }       
    }
}
