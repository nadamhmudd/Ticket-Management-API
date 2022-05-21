global using MediatR;

namespace TicketManagement.Application.Features.Events.Queries
{
    public class GetEventDetailQuery : IRequest<EventDto>
    {
        public Guid Id { get; set; } //parameter needed
    }
}
