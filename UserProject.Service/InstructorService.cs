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

    public class InstructorService
    {
        private readonly AppDbContext _context;
        public InstructorService(AppDbContext context) { _context = context; }

        public async Task<Instructor> AddInstructorAsync(InstructorDto dto)
        {
            var instructor = new Instructor { Name = dto.Name, Email = dto.Email };
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
            return instructor;
        }

        public async Task<List<Instructor>> GetAllAsync()
        {
            return await _context.Instructors.ToListAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var user = await _context.Instructors.FindAsync(id);
            if (user == null) return;

            _context.Instructors.Remove(user);
            await _context.SaveChangesAsync();

        }
    }
}
