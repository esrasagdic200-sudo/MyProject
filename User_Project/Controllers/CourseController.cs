using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
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
    public class CourseController:ControllerBase
    {
        private readonly CourseService _service;
        public CourseController(CourseService service) { _service = service; }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseDto dto)
        {
            var course = await _service.AddCourseAsync(dto);
            return Ok(course);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _service.GetAllCoursesAsync();
            return Ok(courses);
        }



    }
}
