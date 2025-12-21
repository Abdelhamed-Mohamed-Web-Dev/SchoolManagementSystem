using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts
{
	public interface IDbInitializer
	{
		public Task InitializeIdentityAsync();

	}
}
