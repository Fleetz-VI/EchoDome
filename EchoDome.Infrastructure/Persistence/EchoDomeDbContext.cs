using EchoDome.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDome.Infrastructure.Persistence
{
    public class EchoDomeDbContext : DbContext
    {
        public EchoDomeDbContext(DbContextOptions<EchoDomeDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Participant> Participants => Set<Participant>();
        public DbSet<Match> Matches => Set<Match>();
        public DbSet<Tournament> Tournaments => Set<Tournament>();
        public DbSet<Bet> Bets => Set<Bet>();
        public DbSet<PointsTransaction> PointsTransactions => Set<PointsTransaction>();
        public DbSet<BetType> BetTypes => Set<BetType>();
        public DbSet<BetReason> BetReasons => Set<BetReason>();
        public DbSet<Faction> Factions => Set<Faction>();
        public DbSet<Season> Seasons => Set<Season>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<TournamentType> TournamentTypes => Set<TournamentType>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API mappings (optional for precision)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EchoDomeDbContext).Assembly);
        }
    }
}
