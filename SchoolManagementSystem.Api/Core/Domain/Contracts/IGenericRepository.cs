using Domain.Entities;

namespace Domain.Contracts
{
	public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
	{
		public Task<TEntity> GetAsync(TKey Id);
		public Task<IEnumerable<TEntity>> GetAllAsync();
		public Task AddAsync(TEntity entity);
		public void Update(TEntity entity);
		public void Delete(TEntity entity);
	}
}
