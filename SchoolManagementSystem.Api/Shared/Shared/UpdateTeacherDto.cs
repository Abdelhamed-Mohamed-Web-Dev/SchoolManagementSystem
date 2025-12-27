using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
	public record UpdateTeacherDto
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string Specialization { get; set; }
		public List<int> SubjectIds { get; set; }
		public List<int> ClassIds { get; set; }
	}
}
