using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EchoDome.Infrastructure.Persistence;
using EchoDome.Application.Interfaces; // For IRepository or service interfaces
//using EchoDome.Infrastructure.Repositories;
using EchoDome.Infrastructure.Services;

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
            //services.AddScoped<ITournamentService, TournamentService>();
            //services.AddScoped<IBetService, BetService>();
            services.AddScoped<IParticipantService, ParticipantService>();

            return services;
        }
    }
}
