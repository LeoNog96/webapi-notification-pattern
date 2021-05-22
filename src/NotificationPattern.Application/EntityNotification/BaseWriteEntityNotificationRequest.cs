using NotificationPattern.Application.EntityNotification.Validators;
using NotificationPattern.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Application.EntityNotification
{
    public class BaseWriteEntityNotificationRequest : BaseValidator
    {
        public long Id { get; set; }
        public string Description { get; set; }

        public BaseWriteEntityNotificationRequest()
        {
            Validate(this, new EntityNotificationValidator());
        }
    }
}
