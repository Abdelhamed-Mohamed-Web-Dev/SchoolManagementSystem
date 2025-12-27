using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public record TeacherSubjectDto
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}