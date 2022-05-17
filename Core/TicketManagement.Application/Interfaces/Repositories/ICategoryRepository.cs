global using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Interfaces.Repositories
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);
    }
}
