using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ConcreteSpecifications
{
	public class GradeSpecifications : Specifications<Grade>
	{
		public GradeSpecifications(string gradeName)
			: base(g => g.Name.ToUpper() == gradeName.ToUpper())
		{

		}
	}
}
