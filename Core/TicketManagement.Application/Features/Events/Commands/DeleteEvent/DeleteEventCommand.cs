namespace TicketManagement.Application.Features.Events.Commands
{
    public class DeleteEventCommand : IRequest<EventDto>
    {
        public readonly Guid Id;

        public DeleteEventCommand(Guid id)
        {
            Id = id;
        }
    }
}
