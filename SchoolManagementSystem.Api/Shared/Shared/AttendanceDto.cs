using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class AttendanceDto
    {
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public string SubjectName { get; set; }
    }
}
