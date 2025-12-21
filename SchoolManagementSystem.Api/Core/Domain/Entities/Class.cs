using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Class : BaseEntity<int>
	{
		public string Grade { get; set; }
		public string Name { get; set; } 
		public string AcademicYear { get; set; }

		public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
		public ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
		public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
		public ICollection<Exam> Exams { get; set; } = new List<Exam>();
	}
}
