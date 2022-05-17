global using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Interfaces.Repositories
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}
