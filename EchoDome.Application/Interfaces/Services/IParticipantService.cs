using EchoDome.Application.DTOs;
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
        Task<List<ParticipantStatsDto>> GetParticipantStatsAsync(CancellationToken cancellationToken);
    }
}
