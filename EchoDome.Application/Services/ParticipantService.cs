using EchoDome.Application.DTOs;
using EchoDome.Application.Interfaces.Repositories;
using EchoDome.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDome.Application.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;

        // Inject the repository through the constructor
        public ParticipantService(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        // Implement the GetParticipantStatsAsync method
        public async Task<List<ParticipantStatsDto>> GetParticipantStatsAsync(CancellationToken cancellationToken)
        {
            // Fetch participants with their related factions from the repository
            List<Domain.Entities.Participant> participants = await _participantRepository.GetAllWithFactionAsync(cancellationToken);

            // Map the domain entities (Participant) to the DTOs (ParticipantStatsDto)
            var stats = participants.Select((p, index) => new ParticipantStatsDto
            {
                Ranking = index + 1, // Ranking based on order
                Name = p.Name,
                NrMatches = p.MatchCount,
                Wins = p.Wins,
                TournamentWins = p.TournamentWins,
                WinRate = CalculateWinRate(p),
                Faction = p.Faction?.Name ?? string.Empty
            }).ToList();

            // Return the list of DTOs
            return stats;
        }

        // Calculate win rate, ensuring no division by zero
        private static double CalculateWinRate(Domain.Entities.Participant p)
        {
            try
            {
                return p.MatchCount > 0 ? Math.Round((double)p.Wins / p.MatchCount * 100, 2) : 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
