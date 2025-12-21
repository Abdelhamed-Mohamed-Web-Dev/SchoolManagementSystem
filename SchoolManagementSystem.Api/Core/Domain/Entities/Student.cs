using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Student : BaseEntity<int>
	{
		public string FullName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Gender { get; set; }
		public DateTime EnrollmentDate { get; set; }

		public string UserId { get; set; }
		public IdentityUser User { get; set; }

		public ICollection<ParentStudent> ParentStudents { get; set; } = new List<ParentStudent>();
		public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
		public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
		public ICollection<GradeResult> GradeResults { get; set; } = new List<GradeResult>();
	}

}
