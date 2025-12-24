using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions.NotFoundExceptions
{
	public class ParentNotFoundException(int id) : NotFoundException($"Parent with Id [[{id}]] is not found.")
	{
	}
}
