namespace TicketManagement.Application.Features.Events.Queries
{
    public record EventsListResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
    }
}
