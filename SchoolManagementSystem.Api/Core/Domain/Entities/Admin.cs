using Microsoft.AspNetCore.Identity;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Admin : BaseEntity<int>
	{
		public string FullName { get; set; }

		public string UserId { get; set; }
		public IdentityUser User { get; set; }
	}

}
