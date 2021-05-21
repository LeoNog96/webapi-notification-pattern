using Mapster;
using NotificationPattern.Data.Entities;
using NotificationPattern.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationPattern.WebApi.Configures.Mapper
{
    public static class MapperConfigure
    {
        public static void Configure()
        {
            TypeAdapterConfig<EntityNotificationEntity, EntityNotification>.NewConfig();
            TypeAdapterConfig<EntityNotification, EntityNotificationEntity>.NewConfig();
        }
    }
}
