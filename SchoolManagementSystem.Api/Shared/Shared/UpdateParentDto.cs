using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Shared
{
    public record UpdateParentDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
