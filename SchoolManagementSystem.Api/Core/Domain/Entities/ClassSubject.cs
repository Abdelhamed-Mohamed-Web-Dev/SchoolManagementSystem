using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class ClassSubject
	{
		public Class Class { get; set; }
		public int ClassId { get; set; }
		public Subject Subject { get; set; }
		public int SubjectId { get; set; }
	}
}
