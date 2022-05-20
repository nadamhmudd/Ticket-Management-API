namespace TicketManagement.Application.Features.Categories.Queries
{ 
    public class CategoryEventListResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryEventDto> Events { get; set; }
    }
}
