using EchoDome.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDome.Application.Interfaces
{
    public interface IParticipantService
    {
        Task<List<ParticipantStatsDto>> GetParticipantStatsAsync();
    }
}
