using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using NotificationPattern.Application.Notifications;
using NotificationPattern.Application.Notifications.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationPattern.WebApi.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly NotificationContext _notificationContext;

        public NotificationFilter(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationContext.HasNotifications)
            {
                context.HttpContext.Response.StatusCode = _notificationContext.StatusCode;
                context.HttpContext.Response.ContentType = "application/json";

                var notifications = JsonConvert.SerializeObject(new NotificationResponse("Falha na Operação", _notificationContext.Notifications));
                await context.HttpContext.Response.WriteAsync(notifications);

                return;
            }
            await next();
        }
    }
}
