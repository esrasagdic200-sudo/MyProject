using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UserProject.Core.Models
{
    public class UserRole:BaseEntity
    {
        public string RoleName { get; set; } = default!;
        public ICollection<User> Users { get; set; } = new List<User>();

    }
}
