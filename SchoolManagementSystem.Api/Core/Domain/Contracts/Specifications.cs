using System.Linq.Expressions;

namespace Domain.Contracts
{
	public abstract class Specifications<T> where T : class
	{
		protected Specifications(Expression<Func<T, bool>>? criteria)
		{
			Criteria = criteria;
		}
		public Expression<Func<T, bool>>? Criteria { get; }

		public List<Expression<Func<T, object>>> Includes { get; } = new();
		protected void AddInclude(Expression<Func<T, object>> include)
			=> Includes.Add(include);

		public int Take { get; private set; }
		public int Skip { get; private set; }
		public bool IsPaginated { get; private set; }
		protected void ApplyPagination(int size, int index)
		{
			IsPaginated = true;
			Take = size;
			Skip = (index - 1) * size;
		}


	}
}
