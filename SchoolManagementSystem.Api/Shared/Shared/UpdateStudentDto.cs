using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
	public record UpdateStudentDto
	{
		public int Id { get; set; }
		public int? GradeId { get; set; }
		public int? ClassId { get; set; }
		public int? ParentId { get; set; }
	}
}
