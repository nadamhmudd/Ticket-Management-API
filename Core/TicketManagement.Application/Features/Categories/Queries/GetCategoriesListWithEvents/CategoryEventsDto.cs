namespace TicketManagement.Application.DTOs
{ 
    public record CategoryEventsDto : CategoryDto
    {
        public ICollection<EventDto> Events { get; set; }
    }
}
