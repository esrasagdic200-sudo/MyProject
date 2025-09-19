using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserProject.Core.Dtos;
using UserProject.Core.Interfaces;
using UserProject.Core.Models;
using UserProject.Data;
using UserProject.Service;

namespace UserProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InstructorController : ControllerBase
    {
        private readonly InstructorService _service;
        public InstructorController(InstructorService service) { _service = service; }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InstructorDto dto)
        {
            var instructor = await _service.AddInstructorAsync(dto);
            return Ok(instructor);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var instructors = await _service.GetAllAsync();
            return Ok(instructors);
        }


        [Authorize(Roles= "Instructor,Student")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }


    }
}
