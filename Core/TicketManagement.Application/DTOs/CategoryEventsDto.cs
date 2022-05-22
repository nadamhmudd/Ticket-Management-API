namespace TicketManagement.Application.DTOs
{ 
    public class CategoryEventsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<EventDto> Events { get; set; }
    }
}
