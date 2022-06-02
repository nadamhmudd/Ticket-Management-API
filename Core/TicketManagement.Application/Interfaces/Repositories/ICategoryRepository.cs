global using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Interfaces
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);
    }
}
