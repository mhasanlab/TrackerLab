using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Business.BackgroundServices;
using TrackerLab.Business.Helpers;
using TrackerLab.Business.Interfaces;
using TrackerLab.Business.PipelineBehaviors;
using TrackerLab.Business.Services;

namespace TrackerLab.Business.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServicesExtensions).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            services.AddMemoryCache();

            TypeAdapterConfig.GlobalSettings.Scan(typeof(Mappings).Assembly);

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddHostedService<RemoveDeletedIssuesService>();
        }
    }
}
