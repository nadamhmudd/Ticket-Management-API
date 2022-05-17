namespace TicketManagement.Application.Features.Events.Queries
{
    public record CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}