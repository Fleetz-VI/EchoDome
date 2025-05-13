using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDome.Domain.Entities
{
    public class Match
    {
        public Guid Id { get; set; }
        public Guid TournamentId { get; set; }
        public Tournament Tournament { get; set; } = default!;
        public int RoundNumber { get; set; }
        public Guid ParticipantAId { get; set; }
        public Participant ParticipantA { get; set; } = default!;
        public Guid ParticipantBId { get; set; }
        public Participant ParticipantB { get; set; } = default!;
        public Guid? WinnerId { get; set; }
        public Participant? Winner { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
