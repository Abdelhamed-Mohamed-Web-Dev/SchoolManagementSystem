using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions.NotFoundExceptions
{
	public class SubjectNotFoundException(int id) : NotFoundException($"Subject with Id [{id}] was not found.")
	{
	}
}
