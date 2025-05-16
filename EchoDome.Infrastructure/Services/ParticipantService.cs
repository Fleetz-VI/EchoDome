using EchoDome.Application.DTOs;
using EchoDome.Application.Interfaces;
using EchoDome.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDome.Infrastructure.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly EchoDomeDbContext _context;

        public ParticipantService(EchoDomeDbContext context)
        {
            _context = context;
        }

        public async Task<List<ParticipantStatsDto>> GetParticipantStatsAsync()
        {
            var participants = await _context.Participants
                .Include(p => p.Faction)
                .OrderByDescending(p => p.Wins)
                .ToListAsync();

            var stats = participants.Select((p, index) => new ParticipantStatsDto
            {
                Ranking = index + 1,
                Name = p.Name,
                NrMatches = p.MatchCount,
                Wins = p.Wins,
                TournamentWins = p.TournamentWins,
                WinRate = p.MatchCount > 0 ? Math.Round((double)p.Wins / p.MatchCount * 100, 2) : 0,
                Faction = p.Faction?.Name ?? "Unknown"
            }).ToList();

            return stats;
        }
    }
}
