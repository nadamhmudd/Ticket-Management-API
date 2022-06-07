namespace TicketManagement.Application.Features.Events.Commands
{
    public class UpdateEventCommand : IRequest<EventDto>
    {
        public readonly Guid Id;
        public EventCommand Event { get; set; }

        public UpdateEventCommand(Guid id) => Id = id;
    }
}