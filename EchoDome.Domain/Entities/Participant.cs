using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDome.Domain.Entities
{
    public class Participant
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public int MatchCount { get; set; }
        public int Wins { get; set; }
        public int TournamentWins { get; set; }

        public Guid FactionId { get; set; }
        public Faction Faction { get; set; } = default!;
    }
}
