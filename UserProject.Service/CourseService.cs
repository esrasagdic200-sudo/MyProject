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
    public class CourseService 
    {
        private readonly AppDbContext _context;
        public CourseService(AppDbContext context) { _context = context; }

        public async Task<Course> AddCourseAsync(CourseDto dto)
        {
            var instructor = await _context.Instructors.FindAsync(dto.InstructorId);
            if (instructor == null) throw new Exception("Instructor not found");

            var students = await _context.Students
                .Where(s => dto.StudentIds.Contains(s.StudentId))
                .ToListAsync();

            var course = new Course
            {
                CourseName = dto.CourseName,
                Instructor = instructor,
                Students = students
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses
                .Include(c => c.Instructor)
                .Include(c => c.Students)
                .ToListAsync();
        }
    }
}

