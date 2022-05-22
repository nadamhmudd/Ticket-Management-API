global using MediatR;

namespace TicketManagement.Application.Features.Events.Queries
{
    public class GetEventDetailQuery : IRequest<Response<EventDetailsDto>>
    {
        public readonly Guid Id; //parameter needed

        public GetEventDetailQuery(Guid id)
        {
            Id = id;
        }
    }
}
