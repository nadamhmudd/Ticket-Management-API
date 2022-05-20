namespace TicketManagement.DataPersistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        #region Props / Vars
        protected readonly ApplicationDbContext _dbContext; 
        #endregion

        #region Constructor(s)
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Methods
        public virtual async Task<T> GetByIdAsync(Guid id)
            => await _dbContext.Set<T>().FindAsync(id);

        public async Task<IReadOnlyList<T>> ListAllAsync()
            => await _dbContext.Set<T>().ToListAsync();

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        } 
        #endregion
    }
}
