using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Attendance : BaseEntity<int>
	{
		public int StudentId { get; set; }
		public Student Student { get; set; } = new Student();

		public int ClassId { get; set; }
		public Class Class { get; set; } = new Class();

		public DateTime Date { get; set; }
		public string Status { get; set; } 
	}

}
