using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contracts
{
	public static class SpecificationEvaluator // Query builder
	{
		public static IQueryable<T> QueryBuilder<T>(IQueryable<T> init, Specifications<T> specifications) where T : class
		{
			var query = init;

			if (specifications.Criteria is not null)
				query = query.Where(specifications.Criteria); 

			query = specifications.Includes.Aggregate(query, (current, increment) => current.Include(increment));

			if (specifications.IsPaginated)
			{
				query = query.Skip(specifications.Skip).Take(specifications.Take);
			}
			return query;
		}
	}
}
