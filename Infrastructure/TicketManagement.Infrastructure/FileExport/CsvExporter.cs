using CsvHelper;
using System.Globalization;
using TicketManagement.Application.Contracts.Infrastructure;
using TicketManagement.Application.Features.Events.Queries;

namespace TicketManagement.Infrastructure
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventsExportDtos)
        {
            using var memoryStream = new MemoryStream();
            
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                csvWriter.WriteRecords(eventsExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
