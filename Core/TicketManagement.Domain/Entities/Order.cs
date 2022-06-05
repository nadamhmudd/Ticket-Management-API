namespace TicketManagement.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public Guid Id { get; set; }
        public int TicktCounts { get; set; }
        public double OrderTotal { get; set; }
        public bool OrderPaid { get; set; }
        public DateTime OrderPlaced { get; set; }

        //one to many relationship
        public Guid UserId { get; set; } //FK

        public Guid EventId { get; set; } //FK
        public Event Event { get; set; } //navigation property
    }
}
