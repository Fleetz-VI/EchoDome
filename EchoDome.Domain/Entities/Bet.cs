using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDome.Domain.Entities
{
    public class Bet
    {
        public Guid Id { get; set; }
        public Guid BetTypeId { get; set; }
        public BetType BetType { get; set; } = default!;
        public Guid BetReasonId { get; set; }
        public BetReason BetReason { get; set; } = default!;
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public Guid MatchId { get; set; }
        public Match Match { get; set; } = default!;
        public Guid ParticipantId { get; set; }
        public Participant Participant { get; set; } = default!;
        public int PointsWagered { get; set; }
        public bool Won { get; set; }
        public int? PayoutAmount { get; set; }
        public DateTime PlacedAt { get; set; }
    }
}
