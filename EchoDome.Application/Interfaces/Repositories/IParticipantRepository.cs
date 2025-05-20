using EchoDome.Application.DTOs;
using EchoDome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDome.Application.Interfaces.Repositories
{
    public interface IParticipantRepository
    {
        Task<List<Participant>> GetAllWithFactionAsync(CancellationToken ct);
    }
}
