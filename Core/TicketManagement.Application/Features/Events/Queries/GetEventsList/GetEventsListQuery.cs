global using MediatR;

namespace TicketManagement.Application.Features.Events.Queries
{
    public class GetEventsListQuery : IRequest<List<EventDto>>
    {
    }
}
