using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationPattern.Application.EntityNotification.Get.Query;
using NotificationPattern.Application.EntityNotification.Save.Query;

namespace NotificationPattern.WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiVersion("1")]
    [Produces("application/json")]
    public class EntitiesNotificationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntitiesNotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:long}", Name = "GetEntityNotification")]
        [ProducesResponseType(typeof(GetEntityNotificationQueryResult), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetEntityNotificationQueryResult>> GetEntityNotification(long id)
        {
            var entityNotification = await _mediator.Send(new GetEntityNotificationQuery(id));

            return entityNotification;
        }

        [HttpPost]
        [ProducesResponseType(typeof(SaveEntityNotificationQueryResult), StatusCodes.Status200OK)]
        public async Task<ActionResult<SaveEntityNotificationQueryResult>> Save(SaveEntityNotificationQuery request)
        {
            var entityNotification = await _mediator.Send(request);

            return entityNotification;
        }
    }
}
