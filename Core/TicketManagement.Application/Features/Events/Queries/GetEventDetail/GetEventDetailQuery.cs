global using MediatR;

namespace TicketManagement.Application.Features.Events.Queries
{
    public class GetEventDetailQuery : IRequest<EventDto>
    {
        public readonly Guid Id; //parameter needed

        public GetEventDetailQuery(Guid id)
        {
            Id = id;
        }
    }
}
