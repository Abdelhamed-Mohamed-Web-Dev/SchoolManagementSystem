
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Services.Contracts
{
	public class GenericRepository<TEntity, TKey>(MainContext mainContext) : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
	{
		public async Task AddAsync(TEntity entity)
		=> await mainContext.Set<TEntity>().AddAsync(entity);

		public void Update(TEntity entity)
		=> mainContext.Set<TEntity>().Update(entity);

		public void Delete(TEntity entity)
		=> mainContext.Set<TEntity>().Remove(entity);

		public async Task<TEntity?> GetAsync(TKey Id)
		=> await mainContext.Set<TEntity>().FindAsync(Id);

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		=> await mainContext.Set<TEntity>().ToListAsync();



	}
}
