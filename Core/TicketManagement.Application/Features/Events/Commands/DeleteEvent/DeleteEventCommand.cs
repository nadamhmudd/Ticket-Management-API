namespace TicketManagement.Application.Features.Events.Commands
{
    public class DeleteEventCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
