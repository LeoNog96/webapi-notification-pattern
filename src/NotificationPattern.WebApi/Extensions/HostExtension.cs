using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using NotificationPattern.Application.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationPattern.WebApi.Extensions
{
    public static class HostExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NotificationPattern.WebApi", Version = "v1" });
            });
        }

        public static void ConfigureNotifications(this IServiceCollection services)
        {
            services.AddScoped<NotificationContext>();
        }
    }
}
