using EchoDome.Domain.Entities;
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
        Task<List<Participant>> GetParticipantStatsAsync(CancellationToken cancellationToken);
    }
}
