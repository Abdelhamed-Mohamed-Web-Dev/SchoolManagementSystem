using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared
{
	public record UserRegisterDTO
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		public string UserName { get; set; }
		[Required]
		public string PhoneNumber { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string Role { get; set; }
	}
}
