using TicketManagement.Application.Features.Events.Queries;

namespace TicketManagement.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventsExportDtos);
    }
}
