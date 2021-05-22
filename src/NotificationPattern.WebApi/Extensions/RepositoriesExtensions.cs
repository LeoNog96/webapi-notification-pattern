using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationPattern.Data.Context;
using NotificationPattern.Data.Repositories;
using NotificationPattern.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationPattern.WebApi.Extensions
{
    public static class RepositoriesExtensions
    {
        public static void ConfigureContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<NotificationPatternContext>(
                options => options.UseNpgsql(config.GetConnectionString("NotificationPatternContext"))
            );
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEntityNotificationRepository, EntityNotificationRepository>();
        }
    }
}
