using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDome.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
        public string HashedPassword { get; set; } = default!;
        public string DisplayName { get; set; } = default!;
        public int Points { get; set; }
        public Guid RoleId { get; set; }
        public UserRole Role { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
