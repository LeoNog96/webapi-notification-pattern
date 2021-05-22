using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Application.EntityNotification.Get.Query
{
    public class GetEntityNotificationQuery : IRequest<GetEntityNotificationQueryResult>
    {
        public long Id { get; }

        public GetEntityNotificationQuery(long id)
        {
            Id = id;
        }
    }
}
