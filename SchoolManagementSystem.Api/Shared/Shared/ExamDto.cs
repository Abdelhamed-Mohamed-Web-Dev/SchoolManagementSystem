using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public record ExamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExamDate { get; set; }
        public int MaxScore { get; set; }
        public int PassScore { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }
}