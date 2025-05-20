using EchoDome.Application.Interfaces.Repositories;
using EchoDome.Domain.Entities;
using EchoDome.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDome.Infrastructure.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly EchoDomeDbContext _context;

        public ParticipantRepository(EchoDomeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Participant>> GetAllWithFactionAsync(CancellationToken ct)
        {
            return await _context.Participants
                .Include(p => p.Faction)
                .ToListAsync(ct);
        }

        public async Task<Participant?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _context.Participants
                .Include(p => p.Faction)
                .FirstOrDefaultAsync(p => p.Id == id, ct);
        }

        public async Task UpdateParticipantAsync(Participant participant, CancellationToken ct)
        {
            _context.Participants.Update(participant);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<Guid> CreateParticipantAsync(Participant participant, CancellationToken ct)
        {
            if (participant is null)
                throw new ArgumentNullException(nameof(participant));

            await _context.Participants.AddAsync(participant);
            await _context.SaveChangesAsync(ct);
            return participant.Id;
        }
    }
}
