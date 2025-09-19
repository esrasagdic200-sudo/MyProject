using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public class StudentsController:ControllerBase
    {
        private readonly StudentService _service;
        public StudentsController(StudentService service) { _service = service; }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StudentDto dto)
        {
            var student = await _service.AddStudentAsync(dto);
            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _service.GetAllAsync();
            return Ok(students);
        }
    }


}

