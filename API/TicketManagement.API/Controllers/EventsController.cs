using TicketManagement.Application.Features.Events;
using TicketManagement.Application.Features.Events.Commands;
using TicketManagement.Application.Features.Events.Queries;

namespace TicketManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        #region Props / Vars
        private readonly IMediator _mediator;
        #endregion

        #region Ctor
        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Queries

        [HttpGet]
        public async Task<ActionResult<Response<List<EventDto>>>> GetAllEvents()
        {
            return Ok(await _mediator.Send(new GetEventsListQuery()));
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Response<EventDto>>> GetEventById(Guid id)
        {
            return Ok(await _mediator.Send(new GetEventDetailQuery(id)));
        }


        #endregion

        #region Commands

        [HttpPost]
        public async Task<ActionResult<Response<EventDto>>> Create([FromBody] CreateEventCommand createEventCommand)
        {
            return Ok(await _mediator.Send(createEventCommand));
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Response<EventDto>>> Update([FromBody] UpdateEventCommand updateEventCommand)
        {
            return Ok(await _mediator.Send(updateEventCommand));
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Response<EventDto>>> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteEventCommand(id)));
        }

        #endregion
    }
}
