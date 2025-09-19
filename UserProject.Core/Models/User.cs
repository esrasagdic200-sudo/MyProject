using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UserProject.Core.Models
{
    public class User :BaseEntity
    {
        public string Username { get; set; } = default!;
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; } = default!;
        public UserRole UserRole { get; set; } = default!;

    }
}
