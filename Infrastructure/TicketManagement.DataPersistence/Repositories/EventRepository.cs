using System.Linq.Expressions;

namespace TicketManagement.DataPersistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Event> GetByIdAsync(Guid id, Expression<Func<Event, object>> include)
            => await _dbContext.Events.Where(e => e.Id == id)
                                   .Include(include)
                                   .FirstOrDefaultAsync(e => e.Id == id);

        public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            var matches = _dbContext.Events.Any(
                e => e.Name.Equals(name) && e.Date.Date.Equals(eventDate.Date));
            
            return Task.FromResult(matches);
        }
    }
}
