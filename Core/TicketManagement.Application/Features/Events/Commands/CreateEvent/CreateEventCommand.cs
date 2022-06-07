namespace TicketManagement.Application.Features.Events.Commands
{
    public class CreateEventCommand : IRequest<EventDto>
    {
        public string Name { get; set; }
        public double Price { get; set; } //not null
        public string Artist { get; set; }
        public DateTime Date { get; set; } //not null 
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; } //not null

        public override string ToString()
        {
            return $"Event name: {Name}; Price: {Price}; By: {Artist}; On: {Date.ToShortDateString()}; Description: {Description}";
        }
    }
}