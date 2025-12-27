using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;

namespace Shared
{
	public record CreateStudentDto
	{
		[EmailAddress]
		public string Email { get; set; }
		public string UserName { get; set; }
		public string PhoneNumber { get; set; }

		public string FullName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Gender { get; set; }


		public int GradeId { get; set; }
		public int ParentId { get; set; }
		public int ClassId { get; set; }

	}
}
