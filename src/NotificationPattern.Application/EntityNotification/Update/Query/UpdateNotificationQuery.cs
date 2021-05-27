using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Application.EntityNotification.Update.Query
{
    public class UpdateNotificationQuery : BaseWriteEntityNotificationRequest, IRequest<UpdateNotificationQueryResult>
    {
        public UpdateNotificationQuery()
            : base()
        {
        }
    }
}
