using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Application.Notifications.Response
{
    public class NotificationResponse
    {
        public string Title { get; private set; }
        public IEnumerable<Notification> Notifications { get; private set;}

        public NotificationResponse(string title, IEnumerable<Notification> notifications)
        {
            Title = title;
            Notifications = notifications;
        }
    }
}
