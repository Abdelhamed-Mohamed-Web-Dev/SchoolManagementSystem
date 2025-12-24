using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Params
{
	public class TeachersParams
	{
		// filter
		public int? ClassId { get; set; }
		// pagination
		const int MaxSize = 10;
		const int DefaultSize = 5;
		private int pageSize = DefaultSize;

		public int PageSize
		{
			get => pageSize;
			set => pageSize = value > MaxSize ? MaxSize : value;
		}
		public int PageIndex { get; set; } = 1;
		// search
		public string? Search { get; set; }


	}
}
