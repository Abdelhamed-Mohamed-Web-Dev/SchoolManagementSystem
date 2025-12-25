using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
	public record ClassDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string AcademicYear { get; set; }

		public string Grade { get; set; }
		public ICollection<string> Students { get; set; } 
		public ICollection<string> Subjects { get; set; }
		public ICollection<string> Exams { get; set; } 
	}
}
