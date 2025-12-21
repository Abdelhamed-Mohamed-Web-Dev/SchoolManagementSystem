using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Exam : BaseEntity<int>
	{
		public int SubjectId { get; set; }
		public Subject Subject { get; set; } = new Subject();

		public int ClassId { get; set; }
		public Class Class { get; set; } = new Class();

		public DateTime ExamDate { get; set; }
		public int MaxScore { get; set; }
		public int PassScore { get; set; }

		public ICollection<GradeResult> GradeResults { get; set; } = new List<GradeResult>();
	}

}
