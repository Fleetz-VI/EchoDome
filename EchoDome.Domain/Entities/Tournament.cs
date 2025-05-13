using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDome.Domain.Entities
{
    public class Tournament
    {
        public Guid Id { get; set; }
        public Guid TournamentTypeId { get; set; }
        public TournamentType TournamentType { get; set; } = default!;
        public Guid SeasonId { get; set; }
        public Season Season { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? ChampionParticipantId { get; set; }
        public Participant? ChampionParticipant { get; set; }
        public Guid? WinnerFactionId { get; set; }
        public Faction? WinnerFaction { get; set; }
        public bool IsCompleted { get; set; }
    }
}
