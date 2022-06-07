using System.Linq.Expressions;

namespace TicketManagement.Application.Interfaces
{
    public interface IEventRepository : IAsyncRepository <Event>
    {
        Task<Event> GetByIdAsync(Guid id, Expression<Func<Event, object>> include);
        Task<Event> GetEventNameAndDate(string name, DateTime date);
    }
}
