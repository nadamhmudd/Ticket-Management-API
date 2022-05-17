global using TicketManagement.Domain.Common;

namespace TicketManagement.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 

        //one to many relationship
        public ICollection<Event> Events { get; set; }
    }
}
