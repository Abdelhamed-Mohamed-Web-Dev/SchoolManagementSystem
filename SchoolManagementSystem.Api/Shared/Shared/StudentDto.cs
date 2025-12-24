using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
	public record StudentDto
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Gender { get; set; }
		public string Grade { get; set; }
		public DateTime EnrollmentDate { get; set; }

		public IEnumerable<string> Parents { get; set; }
		public IEnumerable<string> Classes { get; set; }
	}
}
