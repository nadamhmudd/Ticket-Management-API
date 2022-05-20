using System.Linq.Expressions;

namespace TicketManagement.Application.Interfaces.Repositories
{
    public interface IEventRepository : IAsyncRepository <Event>
    {
        Task<Event> GetByIdAsync(Guid id, Expression<Func<Event, object>> include);
        Task<bool> IsEventNameAndDateUnique(string name, DateTime date);
    }
}
