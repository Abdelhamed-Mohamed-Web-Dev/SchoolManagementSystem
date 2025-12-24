using Domain.Entities;

namespace Domain.Contracts
{
	public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
	{
		Task AddAsync(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);
		Task<TEntity> GetAsync(TKey Id);
		Task<IEnumerable<TEntity>> GetAllAsync();
		Task<TEntity> GetAsync(Specifications<TEntity> specifications);
		Task<IEnumerable<TEntity>> GetAllAsync(Specifications<TEntity> specifications);
		Task<int> CountAsync(Specifications<TEntity> specifications);
	}
}
