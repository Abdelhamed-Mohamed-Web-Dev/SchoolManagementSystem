
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Persistence.Contracts
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


		#region With Specifications
		public async Task<TEntity?> GetAsync(Specifications<TEntity> specifications)
			=> await ApplySpecification(specifications).FirstOrDefaultAsync();

		public async Task<IEnumerable<TEntity>> GetAllAsync(Specifications<TEntity> specifications)
			=> await ApplySpecification(specifications).ToListAsync();

		public async Task<int> CountAsync(Specifications<TEntity> specifications)
			=> await ApplySpecification(specifications).CountAsync();

		private IQueryable<TEntity> ApplySpecification(Specifications<TEntity> specifications)
			=> SpecificationEvaluator.QueryBuilder<TEntity>(mainContext.Set<TEntity>(), specifications);
		#endregion


	}
}
