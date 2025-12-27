using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public record StudentWithParentsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public IEnumerable<string> Parents { get; set; }
    }
}