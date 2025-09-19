using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProject.Core.Dtos;
using UserProject.Core.Models;

namespace UserProject.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailDto> CreateAsync(CreateUserDto dto);
        Task<IEnumerable<UserDetailDto>> GetAllAsync();
        Task<UserDetailDto?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, CreateUserDto dto);
        Task<UserDetailDto> LoginAsync(LoginDto dto);

    }
}
