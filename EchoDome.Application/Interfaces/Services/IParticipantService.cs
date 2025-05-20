using EchoDome.Application.DTOs.Participants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EchoDome.Application.Interfaces.Services
{
    public interface IParticipantService
    {
        // TODO: Add filtering/paging/sorting
        Task<List<ParticipantStatsDTO>> GetParticipantStatsAsync(CancellationToken cancellationToken);
        
        Task UpdateParticipantStatsAsync(Guid participantId, ParticipantStatsUpdateDTO dto, CancellationToken cancellationToken);

        Task<Guid> CreateParticipantAsync(CreateParticipantDTO dto, CancellationToken cancellationToken);
    }
}
