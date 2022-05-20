namespace TicketManagement.Application.Features.Events.Commands
{
    public class CreateEventCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }

        public override string ToString() 
            => $"Event name: {Name}; Price: {Price}; By: {Artist}; On: {Date.ToShortDateString()}; Description: {Description}";
    }
}