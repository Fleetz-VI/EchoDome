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
                },
                new Participant
                {
                    Name = "Bravo",
                    MatchCount = 0,
                    Wins = 0,
                    TournamentWins = 0,
                    Faction = null
                }
            };

            _repoMock.Setup(r => r.GetAllWithFactionAsync(It.IsAny<CancellationToken>()))
                     .ReturnsAsync(participants);

            // Act
            var result = await _service.GetParticipantStatsAsync(CancellationToken.None);

            // Assert
            result.Should().HaveCount(2);
            result[0].Name.Should().Be("Alpha");
            result[0].WinRate.Should().Be(60.0);
            result[1].Faction.Should().Be(string.Empty);
        }

        [Fact]
        public async Task UpdateParticipantStatsAsync_ShouldUpdateAndCallRepo()
        {
            // Arrange
            var participantId = Guid.NewGuid();
            var participant = new Participant { Id = participantId, Name = "OldName" };

            var dto = new ParticipantStatsUpdateDTO(Guid.NewGuid(), "NewName", "test", 5, 3, 1, Guid.NewGuid());

            _repoMock.Setup(r => r.GetByIdAsync(participantId, It.IsAny<CancellationToken>()))
                     .ReturnsAsync(participant);

            // Act
            await _service.UpdateParticipantStatsAsync(participantId, dto, CancellationToken.None);

            // Assert
            participant.Name.Should().Be("NewName");
            participant.MatchCount.Should().Be(5);
            participant.Wins.Should().Be(3);
            participant.TournamentWins.Should().Be(1);
            participant.FactionId.Should().Be(dto.FactionId.Value);
            participant.ImageUrl.Should().Be(dto.ImageUrl);

            _repoMock.Verify(r => r.UpdateParticipantAsync(participant, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateParticipantStatsAsync_ShouldThrow_IfDtoIsNull()
        {
            var act = () => _service.UpdateParticipantStatsAsync(Guid.NewGuid(), null!, CancellationToken.None);

            await act.Should().ThrowAsync<ArgumentNullException>();
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
        public async Task UpdateParticipantStatsAsync_ShouldThrow_IfWinsExceedMatches()
        {
            var participant = new Participant { Id = Guid.NewGuid() };

            var dto = new ParticipantStatsUpdateDTO(Guid.NewGuid(), null, null, 3, 5, null, null);


            _repoMock.Setup(r => r.GetByIdAsync(participant.Id, It.IsAny<CancellationToken>()))
                     .ReturnsAsync(participant);

            var act = () => _service.UpdateParticipantStatsAsync(participant.Id, dto, CancellationToken.None);

            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task CreateParticipantAsync_ShouldCreate_AndReturnId()
        {
            var dto = new CreateParticipantDTO
            {
                Name = "NewParticipant",
                MatchCount = 2,
                Wins = 1,
                TournamentWins = 0,
                FactionId = Guid.NewGuid(),
                ImageUrl = "http://url"
            };

            var newId = Guid.NewGuid();

            _repoMock.Setup(r => r.CreateParticipantAsync(It.IsAny<Participant>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(newId);

            var result = await _service.CreateParticipantAsync(dto, CancellationToken.None);

            result.Should().Be(newId);

            _repoMock.Verify(r => r.CreateParticipantAsync(It.Is<Participant>(p =>
                p.Name == dto.Name &&
                p.MatchCount == dto.MatchCount &&
                p.Wins == dto.Wins &&
                p.TournamentWins == dto.TournamentWins &&
                p.FactionId == dto.FactionId &&
                p.ImageUrl == dto.ImageUrl
            ), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task CreateParticipantAsync_ShouldThrow_IfDtoIsNull()
        {
            var act = () => _service.CreateParticipantAsync(null!, CancellationToken.None);

            await act.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}