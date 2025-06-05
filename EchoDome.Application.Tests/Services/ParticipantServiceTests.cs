using EchoDome.Application.DTOs.Participants;
using EchoDome.Application.Interfaces.Repositories;
using EchoDome.Application.Services;
using EchoDome.Domain.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace EchoDome.Application.Tests.Services
{
    public class ParticipantServiceTests
    {
        private readonly Mock<IParticipantRepository> _repoMock;
        private readonly ParticipantService _service;

        public ParticipantServiceTests()
        {
            _repoMock = new Mock<IParticipantRepository>();
            _service = new ParticipantService(_repoMock.Object);
        }

        [Fact]
        public async Task GetParticipantStatsAsync_ShouldReturnMappedStats()
        {
            // Arrange
            var participants = new List<Participant>
            {
                new Participant
                {
                    Name = "Alpha",
                    MatchCount = 10,
                    Wins = 6,
                    TournamentWins = 2,
                    Faction = new Faction { Name = "Red" }
                }
            };

            _repoMock.Setup(r => r.GetAllWithFactionAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(participants);

            // Act
            var result = await _service.GetParticipantStatsAsync(CancellationToken.None);

            // Assert
            result.Should().HaveCount(1);
            result[0].Name.Should().Be("Alpha");
            result[0].WinRate.Should().Be(60.0);
            result[0].Faction.Should().Be("Red");
        }

        [Fact]
        public async Task UpdateParticipantStatsAsync_ShouldThrow_IfParticipantNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync((Participant?)null);

            //var dto = new ParticipantStatsUpdateDTO { MatchCount = 10, Wins = 5 };
            var dto = new ParticipantStatsUpdateDTO(Guid.NewGuid(), null, null, 10, 5, null, null);

            var act = () => _service.UpdateParticipantStatsAsync(Guid.NewGuid(), dto, CancellationToken.None);

            await act.Should().ThrowAsync<KeyNotFoundException>();
        }

        [Fact]
        public async Task CreateParticipantAsync_ShouldReturnNewId()
        {
            var dto = new CreateParticipantDTO { Name = "Beta", MatchCount = 5, Wins = 3 };

            _repoMock.Setup(r => r.CreateParticipantAsync(It.IsAny<Participant>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(Guid.NewGuid());

            var id = await _service.CreateParticipantAsync(dto, CancellationToken.None);

            id.Should().NotBeEmpty();
        }
    }
}