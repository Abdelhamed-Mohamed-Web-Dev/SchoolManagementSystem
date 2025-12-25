using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class GradeResult : BaseEntity<int>
	{
		public int ExamId { get; set; }
		public Exam Exam { get; set; }

		public int StudentId { get; set; }
		public Student Student { get; set; }

		public int GradeId { get; set; }
		public Grade Grade { get; set; } 

		public int Score { get; set; }
	}

}
