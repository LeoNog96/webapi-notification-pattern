using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NotificationPattern.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationPattern.WebApi.Configures.Context
{
    public static class ContextConfigure
    {
        public static void Configure(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
           .CreateScope();
            serviceScope.ServiceProvider.GetService<NotificationPatternContext>().Database.Migrate();
        }
    }
}
