using System.Threading.Tasks;
using CangguEvents.Api.Events.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CangguEvents.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class EventsController : Controller
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var send = await _mediator.Send(new GetAllEventsQuery());
            return Ok(send);
        }
    }
}