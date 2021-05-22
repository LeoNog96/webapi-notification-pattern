using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Application.Models.EntityNotification.Get.Query
{
    public class EntityNotificationQuery : IRequest<EntityNotificationQueryResult>
    {
        public long Id { get; }

        public EntityNotificationQuery(long id)
        {
            Id = id;
        }
    }
}
