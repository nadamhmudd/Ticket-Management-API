﻿using TicketManagement.Api.Utility;
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
        public async Task<ActionResult<List<EventDto>>> GetAllEvents()
        {
            return Ok(await _mediator.Send(new GetEventsListQuery()));
        }

        [HttpGet("{id}", Name = "GetEventById")]
        public async Task<ActionResult<EventDetailsDto>> GetEventById(Guid id)
        {
            return Ok(await _mediator.Send(new GetEventDetailQuery(id)));
        }

        [HttpGet("export", Name ="ExportEvents"), Authorize(Roles = SD.Role_Admin)]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportEvents()
        {
            var fileDto = await _mediator.Send(new GetEventsExportQuery());

            return File(fileDto.Data, fileDto.ContentType, fileDto.ExportFileName);
        }
        #endregion

        #region Commands
        [HttpPost(Name = "AddEvent"), Authorize(Roles = SD.Role_Admin)]
        public async Task<ActionResult<EventDto>> CreateEvent([FromBody] CreateEventCommand @event)
        {
            return Ok(await _mediator.Send(@event));
        }

        [HttpPut(Name = "UpdateEvent"), Authorize(Roles = SD.Role_Admin)]
        public async Task<ActionResult<EventDto>> UpdateEvent([FromBody] UpdateEventCommand @event)
        {
            return Ok(await _mediator.Send(@event));
        }

        [HttpDelete("{id}", Name = "DeleteEvent"), Authorize(Roles = SD.Role_Admin)]
        public async Task<ActionResult<EventDto>> DeleteEvent(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteEventCommand(id)));
        }
        #endregion
    }
}
