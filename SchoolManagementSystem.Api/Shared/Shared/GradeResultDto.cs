using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public record GradeResultDto
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Score { get; set; }
    }
}