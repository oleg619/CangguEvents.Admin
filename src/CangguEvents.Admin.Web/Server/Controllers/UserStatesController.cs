using System.Linq;
using System.Threading.Tasks;
using CangguEvents.Admin.Web.Shared;
using CangguEvents.Api.Events.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CangguEvents.Admin.Web.Server.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class UserStatesController : Controller
    {
        private readonly IMediator _mediator;

        public UserStatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var userStates = await _mediator.Send(new GetAllUserStatesQuery());

            return Ok(userStates.Select(state => new UserStateDto()
            {
                Id = state.Id,
                Subscribed = state.Subscribed,
                ShortInfo = state.ShortInfo
            }).ToList());
        }
    }
}