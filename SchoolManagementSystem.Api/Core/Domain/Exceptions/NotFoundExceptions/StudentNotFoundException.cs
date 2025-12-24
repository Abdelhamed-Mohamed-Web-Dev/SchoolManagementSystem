using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions.NotFoundExceptions
{
	public class StudentNotFoundException(int id) : NotFoundException($"Student with Id [[{id}]] is not found.")
	{
	}
}
