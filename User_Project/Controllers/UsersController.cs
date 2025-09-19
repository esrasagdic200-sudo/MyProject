using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserProject.Core.Dtos;
using UserProject.Core.Interfaces;

namespace UserProject.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userService.LoginAsync(dto);
            if (user == null)
            {
                return Unauthorized("Kullanıcı veya şifre hatalı");
            }

            return Ok(user);
        }




        [HttpPost]
        public async Task<ActionResult<UserDetailDto>> Create(CreateUserDto dto)
        {
            var result = await _userService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetailDto>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailDto>> GetById(int id)
        {
            var user=await _userService.GetByIdAsync(id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CreateUserDto dto)
        {
            await _userService.UpdateAsync(id,dto);
            return NoContent();
        }

        
        [Authorize(Roles ="Admin,Guest")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }

    }
}