using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public record CreateParentDto
    {
        public string FullName { get; set; }
        // optional: associate with existing identity user
        public string? UserId { get; set; }
    }
}
