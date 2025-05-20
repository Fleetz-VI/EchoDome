using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EchoDome.Infrastructure.Persistence;
using EchoDome.Infrastructure.Repositories;
//using EchoDome.Infrastructure.Services;
using EchoDome.Application.Interfaces.Repositories;

namespace EchoDome.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<EchoDomeDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register your repositories and service implementations here
            //services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            //services.AddScoped<ISeasonRepository, SeasonRepository>();
            //services.AddScoped<ITournamentRepository, TournamentRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
