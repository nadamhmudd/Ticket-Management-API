using TicketManagement.Application.Features.Events;

namespace TicketManagement.Application.Features.Categories.Queries
{ 
    public class CategoryEventsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<EventDto> Events { get; set; }
    }
}
