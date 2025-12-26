using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ConcreteSpecifications
{
	internal class ClassSpecifications : Specifications<Class>
	{
		public ClassSpecifications(string className)
			: base(c => c.Name.ToUpper() == className.ToUpper())
		{


		}
	}
}
