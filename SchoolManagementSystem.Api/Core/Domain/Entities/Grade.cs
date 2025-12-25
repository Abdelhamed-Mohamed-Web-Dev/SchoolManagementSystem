using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Grade : BaseEntity<int>
	{
		public string Name { get; set; }

		public IEnumerable<Student> Students { get; set; }
		public IEnumerable<Class> Classes { get; set; }
		public IEnumerable<GradeResult> GradeResults { get; set; }
		public IEnumerable<Exam> Exams { get; set; }


	}
}
