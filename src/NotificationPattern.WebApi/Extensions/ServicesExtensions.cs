using Microsoft.Extensions.DependencyInjection;
using NotificationPattern.Data.Repositories;
using NotificationPattern.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace NotificationPattern.WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("NotificationPattern.Application");
            services.AddMediatR(assembly);
        }        
    }
}
