namespace TicketManagement.Application.Features.Events.Commands
{
    public class DeleteEventCommand : IRequest
    {
        public readonly Guid Id;

        public DeleteEventCommand(Guid id)
        {
            Id = id;
        }
    }
}
