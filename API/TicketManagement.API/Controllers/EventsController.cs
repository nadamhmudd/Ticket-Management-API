using TicketManagement.Api.Utility;
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

        [HttpGet(Name = "GetAllEvents")]
        public async Task<ActionResult<Response<List<EventDto>>>> GetAllEvents()
        {
            return Ok(await _mediator.Send(new GetEventsListQuery()));
        }


        [HttpGet("{id}", Name = "GetEventById")]
        public async Task<ActionResult<Response<EventDetailsDto>>> GetEventById(Guid id)
        {
            return Ok(await _mediator.Send(new GetEventDetailQuery(id)));
        }

        [HttpGet("export", Name ="ExportEvents")]

        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportEvents()
        {
            var fileDto = await _mediator.Send(new GetEventsExportQuery());

            return File(fileDto.Data.Data, fileDto.Data.ContentType, fileDto.Data.ExportFileName);
        }

        #endregion

        #region Commands

        [HttpPost(Name = "AddEvent")]
        public async Task<ActionResult<Response<EventDto>>> CreateEvent([FromBody] CreateEventCommand createEventCommand)
        {
            return Ok(await _mediator.Send(createEventCommand));
        }


        [HttpPut(Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Response<EventDto>>> UpdateEvent([FromBody] UpdateEventCommand updateEventCommand)
        {
            return Ok(await _mediator.Send(updateEventCommand));
        }


        [HttpDelete("{id}", Name = "DeleteEvent")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Response<EventDto>>> DeleteEvent(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteEventCommand(id)));
        }

        #endregion
    }
}
