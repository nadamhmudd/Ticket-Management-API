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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EventDto>>> GetAllEvents()
        {
            return Ok(await _mediator.Send(new GetEventsListQuery()));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEventById(Guid id)
        {
            return Ok(await _mediator.Send(new GetEventDetailQuery(id)));
        }


        #endregion

        #region Commands

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventCommand createEventCommand)
        {
            return Ok(await _mediator.Send(createEventCommand));
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateEventCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteEventCommand(id));
            return NoContent();
        }

        #endregion
    }
}
