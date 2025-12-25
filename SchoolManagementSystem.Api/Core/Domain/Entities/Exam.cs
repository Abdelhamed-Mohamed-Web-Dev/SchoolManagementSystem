using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Exam : BaseEntity<int>
	{
		public string Name { get; set; }
		public DateTime ExamDate { get; set; }
		public int MaxScore { get; set; }
		public int PassScore { get; set; }

		public int SubjectId { get; set; }
		public Subject Subject { get; set; } = new Subject();

		public int ClassId { get; set; }
		public Class Class { get; set; } = new Class();

		public int GradeId { get; set; }
		public Grade Grade { get; set; } = new();

		public ICollection<GradeResult> GradeResults { get; set; } = new List<GradeResult>();
	}

}
