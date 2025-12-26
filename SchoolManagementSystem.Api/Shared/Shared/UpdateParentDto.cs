using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public record UpdateParentDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
