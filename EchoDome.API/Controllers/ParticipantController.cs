using EchoDome.Application.DTOs.Participants;
using EchoDome.Application.Interfaces.Repositories;
using EchoDome.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EchoDome.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetStats(CancellationToken cancellationToken)
        {
            var stats = await _participantService.GetParticipantStatsAsync(cancellationToken);
            return Ok(stats);
        }

        [HttpPatch("{participantId}/stats")]
        public async Task<IActionResult> UpdateStats(Guid participantId, ParticipantStatsUpdateDTO dto, CancellationToken ct)
        {
            await _participantService.UpdateParticipantStatsAsync(participantId, dto, ct);
            return NoContent();
        }
    }
}
