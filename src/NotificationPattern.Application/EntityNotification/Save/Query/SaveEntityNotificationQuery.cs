using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Application.EntityNotification.Save.Query
{
    public class SaveEntityNotificationQuery : BaseWriteEntityNotificationRequest, IRequest<SaveEntityNotificationQueryResult>
    {
        public SaveEntityNotificationQuery()
            :base()
        {
        }
    }
}
