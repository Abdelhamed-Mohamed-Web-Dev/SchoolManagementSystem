using Domain.Contracts;
using Domain.Entities;
using Persistence;
using System.Collections.Concurrent;

namespace Services.Contracts
{
	public class UnitOfWork : IUnitOfWork
	{
		readonly MainContext mainContext;
		readonly ConcurrentDictionary<string, object> storedRepositories;

		public UnitOfWork(MainContext mainContext)
		{
			this.mainContext = mainContext;
			this.storedRepositories = new();
		}

		public async Task<int> SaveChangesAsync()
		=> await mainContext.SaveChangesAsync();

		public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
		=> (GenericRepository<TEntity, TKey>)
			storedRepositories.GetOrAdd(typeof(TEntity).Name
				, _ => new GenericRepository<TEntity, TKey>(mainContext));

		// الليله اللى فوق دى عشان لما اجى اكريت ابجكت مره يتخزن ولما اجى احتاجه تانى
		// استدعيه بدل م اكريته من اول وجديد ونملى الميمورى ع الفاضى
	}
}
