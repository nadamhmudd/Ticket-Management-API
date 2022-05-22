global using MediatR;

namespace TicketManagement.Application.Features.Events.Queries
{
    public class GetEventsListQuery : IRequest<Response<List<EventDto>>>
    {
    }
}
