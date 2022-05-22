namespace TicketManagement.Application.Features.Events.Commands
{
    public class DeleteEventCommand : IRequest<Response<EventDto>>
    {
        public readonly Guid Id;

        public DeleteEventCommand(Guid id)
        {
            Id = id;
        }
    }
}
