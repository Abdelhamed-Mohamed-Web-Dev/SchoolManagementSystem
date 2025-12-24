using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
	public record PaginatedResultDto<TData>
	(int PageSize, int PageIndex, int Total, IEnumerable<TData> Data)
	{
	}
}
