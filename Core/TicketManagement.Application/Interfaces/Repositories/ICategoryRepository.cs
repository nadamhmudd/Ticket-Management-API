global using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Interfaces
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithEventsAsync(bool includePassedEvents);
        Task<Category> GetByNameAsync(string name);
        Task<bool> IsUnique(string name);
    }
}
