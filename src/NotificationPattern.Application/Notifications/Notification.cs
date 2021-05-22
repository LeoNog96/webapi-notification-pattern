using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Application.Notifications
{
    public class Notification
    {
        public string Key { get; private set; }
        public string Message { get; private set; }

        public Notification(string key, string message)
        {
            Key = key;
            Message = message;
        }
    }
}
