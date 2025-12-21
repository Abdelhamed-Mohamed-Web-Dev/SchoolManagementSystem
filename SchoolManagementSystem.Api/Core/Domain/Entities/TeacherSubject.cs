using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class TeacherSubject : BaseEntity<int>
	{
		public int TeacherId { get; set; }
		public Teacher Teacher { get; set; } = new Teacher();

		public int SubjectId { get; set; }
		public Subject Subject { get; set; } = new Subject();

		public int ClassId { get; set; }
		public Class Class { get; set; } = new Class();
	}

}
