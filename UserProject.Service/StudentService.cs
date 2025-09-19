using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserProject.Core.Dtos;
using UserProject.Core.Interfaces;
using UserProject.Core.Models;
using UserProject.Data;

namespace UserProject.Service
{
    public class StudentService
    {
        private readonly AppDbContext _context;
        public StudentService(AppDbContext context) { _context = context; }

        public async Task<Student> AddStudentAsync(StudentDto dto)
        {
            var student = new Student { StudentName = dto.Name, Email = dto.Email };
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

    }
}
