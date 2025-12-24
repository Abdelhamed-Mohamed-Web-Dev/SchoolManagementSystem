using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public record CreateStudentDto
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
