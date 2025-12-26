using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Shared
{
    public record CreateParentDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FullName { get; set; }
        // optional: associate with existing identity user
        public string? UserId { get; set; }
    }
}
