using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using UserProject.Core.Dtos;
using UserProject.Core.Interfaces;
using UserProject.Core.Models;
using UserProject.Data;

namespace UserProject.Service
{
    public class UserServicee : IUserService
    {
        private readonly AppDbContext _context;

        public UserServicee(AppDbContext context)
        {
            _context=context;
        }

        public async Task<UserDetailDto> CreateAsync(CreateUserDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                UserRoleId=dto.UserRoleId,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var role = await _context.UserRoles.FindAsync(dto.UserRoleId);

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
            if (!isPasswordValid)
                return null;

            return new UserDetailDto
            {
                Id =dto.UserRoleId,
                Username=dto.Username,
                Email=dto.Email,
                RoleName=role?.RoleName ?? ""
            };
                 
        }

        public async Task DeleteAsync(int id)
        {
            var user=await _context.Users.FindAsync(id);
            if (user == null) return;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<UserDetailDto>> GetAllAsync()
        {
            return await _context.Users
                .Include(u => u.UserRole)  // navigation property
                .Select(u => new UserDetailDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    RoleName = u.UserRole.RoleName
                }).ToListAsync();
        }


        public async Task<UserDetailDto?> GetByIdAsync(int id)
        {
            var user=await _context.Users.Include(x=>x.UserRole).FirstOrDefaultAsync(u=>u.Id==id);

            if (user == null) return null;
            
                return new UserDetailDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    RoleName = user.UserRole.RoleName
                };
            
        }

        public async Task<UserDetailDto> LoginAsync(LoginDto dto)
        {
            var users=await _context.Users.
                Include(x=>x.UserRole).
                FirstOrDefaultAsync(x=>
            x.Username==dto.Username &&
            x.Password==dto.Password
            );

            if(users==null) return null;

            return new UserDetailDto
            {
                Id = users.Id,
                Username = users.Username,
                Email = users.Email,
                RoleName = users.UserRole?.RoleName

            };

        }

        public async Task UpdateAsync(int id, CreateUserDto dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return;

            user.Username = dto.Username;
            user.Email = dto.Email;
            user.UserRoleId = dto.UserRoleId;
            user.UpdatedUtc = DateTime.UtcNow;
            
            await _context.SaveChangesAsync();   
        }

     
    }
}
