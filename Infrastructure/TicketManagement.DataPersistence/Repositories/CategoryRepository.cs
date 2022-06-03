namespace TicketManagement.DataPersistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithEventsAsync(bool includePassedEvents)
        {
            var allCategories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();
            
            if(!includePassedEvents)
                allCategories.ForEach(p => p.Events.ToList()
                             .RemoveAll(c => c.Date < DateTime.Today));
            
            return allCategories;
        }

        public async Task<Category> GetByNameAsync(string name)
        {
            return await _dbContext.Categories
                .Where(c => c.Name == name)
                .SingleOrDefaultAsync()
                ;
        }

        public async Task<bool> IsUnique(string name)
        {
            return (await GetByNameAsync(name) is null);
        }
    }
}
