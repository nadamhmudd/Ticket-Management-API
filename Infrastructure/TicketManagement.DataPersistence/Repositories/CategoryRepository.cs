namespace TicketManagement.DataPersistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            var allCategories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();
            
            if(!includePassedEvents)
                allCategories.ForEach(p => p.Events.ToList()
                             .RemoveAll(c => c.Date < DateTime.Today));
            
            return allCategories;
        }
    }
}
