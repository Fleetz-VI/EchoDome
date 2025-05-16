using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDome.Application.DTOs
{
    public class ParticipantStatsDto
    {
        public int Ranking { get; set; }
        public string Name { get; set; }
        public int NrMatches { get; set; }
        public int Wins { get; set; }
        public int TournamentWins { get; set; }
        public double WinRate { get; set; }
        public string Faction { get; set; }
    }
}
