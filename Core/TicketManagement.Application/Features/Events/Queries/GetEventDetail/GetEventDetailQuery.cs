global using MediatR;

namespace TicketManagement.Application.Features.Events.Queries
{
    public class GetEventDetailQuery : IRequest<EventDetailResponse>
    {
        public Guid Id { get; set; } //parameter needed
    }
}
