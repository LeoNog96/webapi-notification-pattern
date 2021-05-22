using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Application.Notifications
{
    public class NotificationContext
    {
        private readonly List<Notification> _notifications;
        private int _statusCode;
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public bool HasNotifications => _notifications.Any();
        public int StatusCode => _statusCode;

        public NotificationContext()
        {
            _notifications = new List<Notification>();
            _statusCode = 400;
        }

        public void SetStatusCode(int statusCode)
        {
            _statusCode = statusCode;
        }

        public void AddNotification(string key, string message)
        {
            _notifications.Add(new Notification(key, message));
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotification(error.ErrorCode, error.ErrorMessage);
            }
        }
    }
}
