using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Teacher : BaseEntity<int>
	{
		public string FullName { get; set; } = string.Empty;
		public string Specialization { get; set; } = string.Empty;
		public DateTime HireDate { get; set; }
		public string UserId { get; set; }
		public IdentityUser User { get; set; }

		public ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
	}

}
