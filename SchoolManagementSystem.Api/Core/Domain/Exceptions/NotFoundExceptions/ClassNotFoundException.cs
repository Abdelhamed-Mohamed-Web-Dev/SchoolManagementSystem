using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions.NotFoundExceptions
{
	public class ClassNotFoundException(int id) : NotFoundException($"Class with id [[{id}]] is Not Found")
	{
	}
}
