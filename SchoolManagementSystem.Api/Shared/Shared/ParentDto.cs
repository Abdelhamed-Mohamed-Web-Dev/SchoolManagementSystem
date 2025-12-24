using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
	public record ParentDto
	{
		public int Id { get; set; }
		public string FullName { get; set; }

		//public int StudentId { get; set; }

		public string Email { get; set; }
		public IEnumerable<string> Students { get; set; }
	}
}
