using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDome.Application.DTOs.Participants
{
    public record ParticipantStatsDTO(int Ranking, string Name, int NrMatches, int Wins, int TournamentWins,
        double WinRate, string Faction);
}
