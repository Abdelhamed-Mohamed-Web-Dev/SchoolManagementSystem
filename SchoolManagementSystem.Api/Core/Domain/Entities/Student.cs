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

		public int GradeId { get; set; }
		public Grade Grade { get; set; }

		public string UserId { get; set; }
		public IdentityUser User { get; set; }

		public int ParentId { get; set; }
		public Parent Parent { get; set; }

		public int ClassId { get; set; }
		public Class Class { get; set; } = new();

		public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
		public ICollection<GradeResult> GradeResults { get; set; } = new List<GradeResult>();
	}

}
