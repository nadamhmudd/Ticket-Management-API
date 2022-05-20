namespace TicketManagement.Domain.Entities
{
    public class Event : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        //one to many relationship
        public Guid CategoryId { get; set; } //FK
        public Category Category { get; set; } //navigation property
    }
}
