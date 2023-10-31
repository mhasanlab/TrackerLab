using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Data.Helpers;

namespace TrackerLab.Data.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddDataServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("Default")));
            services.AddSingleton<IDateProvider, DateProvider>();
        }
    }
}
