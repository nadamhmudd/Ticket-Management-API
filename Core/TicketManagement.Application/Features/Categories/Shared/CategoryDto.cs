namespace TicketManagement.Application.Features.Categories
{
    public record CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
