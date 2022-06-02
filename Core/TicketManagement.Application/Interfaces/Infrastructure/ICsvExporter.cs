using TicketManagement.Application.Features.Events.Queries;

namespace TicketManagement.Application.Interfaces
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventsExportDtos);
    }
}
