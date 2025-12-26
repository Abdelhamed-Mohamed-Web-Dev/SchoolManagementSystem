using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions.NotFoundExceptions
{
	public class GradeNotFoundException(int id) : NotFoundException($"Grade with Id [[{id}]] is not found.")
	
	{
	}
}
