using EchoDome.Application.DTOs.Participants;
using EchoDome.Application.Interfaces.Repositories;
using EchoDome.Application.Interfaces.Services;
using EchoDome.Domain.Entities;
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

        #region Interface methods
        // Implement the GetParticipantStatsAsync method
        public async Task<List<ParticipantStatsDTO>> GetParticipantStatsAsync(CancellationToken cancellationToken)
        {
            // Fetch participants with their related factions from the repository
            List<Domain.Entities.Participant> participants = await _participantRepository.GetAllWithFactionAsync(cancellationToken);

            // Map the domain entities (Participant) to the DTOs (ParticipantStatsDto)
            var stats = participants.Select((p, index) => new ParticipantStatsDTO
            (
                index + 1, // Ranking based on order
                p.Name,
                p.MatchCount,
                p.Wins,
                p.TournamentWins,
                CalculateWinRate(p),
                p.Faction?.Name ?? string.Empty
            )).ToList();

            // Return the list of DTOs
            return stats;
        }

        public async Task UpdateParticipantStatsAsync(Guid participantId, ParticipantStatsUpdateDTO dto, CancellationToken cancellationToken)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto), "Update data must be provided.");

            var participant = await _participantRepository.GetByIdAsync(participantId, cancellationToken);
            
            if (participant is null)
                throw new KeyNotFoundException("Participant not found.");

            ApplyCommonParticipantFields(participant, dto.Name, dto.ImageUrl, dto.MatchCount, dto.Wins, dto.TournamentWins, dto.FactionId);

            await _participantRepository.UpdateParticipantAsync(participant, cancellationToken);
        }

        public async Task<Guid> CreateParticipantAsync(CreateParticipantDTO dto, CancellationToken cancellationToken)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto), "Create data must be provided.");

            var participant = new Participant();
            ApplyCommonParticipantFields(participant, dto.Name, dto.ImageUrl, dto.MatchCount, dto.Wins, dto.TournamentWins, dto.FactionId);

            Guid participantId = await _participantRepository.CreateParticipantAsync(participant, cancellationToken);
            return participantId;

        }
        #endregion

        #region Helper methods
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

        private void ApplyCommonParticipantFields(Participant participant, string? name, string? imageUrl, int? matchCount, int? wins, int? tournamentWins, Guid? factionId)
        {
            if (matchCount is not null && wins is not null && wins > matchCount)
                throw new ArgumentException("Wins cannot exceed total matches.");

            if (name is not null)
                participant.Name = name;

            if (imageUrl is not null)
                participant.ImageUrl = imageUrl;

            if (matchCount is not null)
                participant.MatchCount = matchCount.Value;

            if (wins is not null)
                participant.Wins = wins.Value;

            if (tournamentWins is not null)
                participant.TournamentWins = tournamentWins.Value;

            if (factionId is not null)
                participant.FactionId = factionId.Value;
        }
        #endregion


    }
}
