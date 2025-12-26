using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared
{
	public record CreateParentDto
	{
		[EmailAddress]
		public string Email { get; set; }
		public string UserName { get; set; }
		public string PhoneNumber { get; set; }

		public string FullName { get; set; }
	}
}
