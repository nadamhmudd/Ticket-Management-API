namespace TicketManagement.Application.DTOs
{
    public record EventDetailsDto : EventDto
    {
        public CategoryDto Category { get; set; }
    }
}
