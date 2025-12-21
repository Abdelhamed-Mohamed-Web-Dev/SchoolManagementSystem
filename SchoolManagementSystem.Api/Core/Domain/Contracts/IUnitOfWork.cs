using Domain.Entities;

namespace Domain.Contracts
{
	public interface IUnitOfWork 
	{
		public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
		public Task<int> SaveChangesAsync();

	}
}
