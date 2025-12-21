using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class GradeResult : BaseEntity<int>
	{
		public int ExamId { get; set; }
		public Exam Exam { get; set; } = new Exam();

		public int StudentId { get; set; }
		public Student Student { get; set; } = new Student();

		public int Score { get; set; }
	}

}
