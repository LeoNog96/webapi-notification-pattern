using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationPattern.Application.Models.EntityNotification.Get.Query;

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
        [ProducesResponseType(typeof(EntityNotificationQueryResult), StatusCodes.Status200OK)]
        public async Task<ActionResult<EntityNotificationQueryResult>> GetEntityNotification(long id)
        {
            var entityNotification = await _mediator.Send(new EntityNotificationQuery(id));

            return entityNotification;
        }
    }
}
