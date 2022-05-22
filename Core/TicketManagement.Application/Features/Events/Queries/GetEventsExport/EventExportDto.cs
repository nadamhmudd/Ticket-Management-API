namespace TicketManagement.Application.Features.Events.Queries
{
    public record EventExportDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
