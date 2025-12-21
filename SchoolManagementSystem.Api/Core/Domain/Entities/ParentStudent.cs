using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class ParentStudent
	{
		public int ParentId { get; set; }
		public Parent Parent { get; set; } = new Parent();

		public int StudentId { get; set; }
		public Student Student { get; set; } = new Student();
	}
}
