using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Parent :BaseEntity<int>
	{
		public string FullName { get; set; } 

		public string UserId { get; set; }
		public IdentityUser User { get; set; }

		public ICollection<Student>Students { get; set; } 
	}

}
