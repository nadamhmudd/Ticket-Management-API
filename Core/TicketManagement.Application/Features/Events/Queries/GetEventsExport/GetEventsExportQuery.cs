global using TicketManagement.Application.Models;

namespace TicketManagement.Application.Features.Events.Queries
{
    public class GetEventsExportQuery : IRequest<CsvFile>
    {
    }
}
