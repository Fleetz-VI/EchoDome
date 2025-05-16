using EchoDome.Application.Interfaces;
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
        public async Task<IActionResult> GetStats()
        {
            var stats = await _participantService.GetParticipantStatsAsync();
            return Ok(stats);
        }
    }
}
