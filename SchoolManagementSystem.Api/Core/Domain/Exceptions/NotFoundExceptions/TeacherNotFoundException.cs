using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions.NotFoundExceptions
{
	public class TeacherNotFoundException(int id) : NotFoundException($"Teacher with Id [[{id}]] is not found.")
	{
	}
}
