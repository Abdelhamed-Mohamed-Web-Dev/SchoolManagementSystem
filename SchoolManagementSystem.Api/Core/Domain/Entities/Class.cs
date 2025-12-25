using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Class : BaseEntity<int>
	{
		public string Name { get; set; } 
		public string AcademicYear { get; set; }

		public int GradeId { get; set; }
		public Grade Grade { get; set; }

		public ICollection<Student> Students { get; set; } = new List<Student>();
		public ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
		public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
		public ICollection<Exam> Exams { get; set; } = new List<Exam>();
	}
}
