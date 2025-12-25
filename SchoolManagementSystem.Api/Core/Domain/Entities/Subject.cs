using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Subject : BaseEntity<int>
	{
		public string Name { get; set; } 

		public ICollection<TeacherSubject> TeacherSubjects { get; set; } 
		public ICollection<Exam> Exams { get; set; }
	}
}
