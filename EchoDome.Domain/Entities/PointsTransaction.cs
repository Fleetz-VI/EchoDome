using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDome.Domain.Entities
{
    public class PointsTransaction
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public int Amount { get; set; } // Can be negative or positive
        public string Reason { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
