using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
	public record TeacherDto
	{
		public int Id { get; set; }
		public string FullName { get; set; } 
		public string Specialization { get; set; } 
		public DateTime HireDate { get; set; }
		public IEnumerable<string> Subjects { get; set; }
	}
}
