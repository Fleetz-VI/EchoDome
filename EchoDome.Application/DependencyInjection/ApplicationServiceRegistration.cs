using EchoDome.Application.Interfaces.Services;
using EchoDome.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDome.Application.DependencyInjection
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IParticipantService, ParticipantService>();
            //services.AddScoped<ITournamentService, TournamentService>();

            return services;
        }
    }
}
