namespace TicketManagement.Application.Features.Events.Commands
{
    public class CreateEventCommand : IRequest<EventDto>
    {
        public EventCommand Event { get; set; }
    }
}