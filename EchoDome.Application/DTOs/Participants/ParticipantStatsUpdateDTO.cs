using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDome.Application.DTOs.Participants
{
    public record ParticipantStatsUpdateDTO(Guid Id, string? Name = null, string? ImageUrl = null, int? MatchCount = null, 
        int? Wins = null, int? TournamentWins = null, Guid? FactionId = null);
}
