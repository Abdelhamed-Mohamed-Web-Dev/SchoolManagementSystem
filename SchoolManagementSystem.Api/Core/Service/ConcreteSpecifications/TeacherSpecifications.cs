using Shared.Params;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ConcreteSpecifications
{
	public class TeacherSpecifications : Specifications<Teacher>
	{
		public TeacherSpecifications(TeachersParams _params)
			: base(t => (!_params.SubjectId.HasValue || t.TeacherSubjects.Any(s => s.SubjectId == _params.SubjectId)) &&
						(!_params.ClassId.HasValue || t.TeacherClasses.Any(s => s.ClassId == _params.ClassId)) &&
						(string.IsNullOrWhiteSpace(_params.Specialization) || t.Specialization.ToUpper().Contains(_params.Specialization.ToUpper())) &&
						(string.IsNullOrWhiteSpace(_params.Search) || t.FullName.ToUpper().Contains(_params.Search!.ToUpper().Trim()))
			)
		{
			AddInclude(t => t.User);
			AddInclude(t => t.TeacherSubjects);
		}
		public TeacherSpecifications(int id)
			: base(t => t.Id == id)
		{
			AddInclude(t => t.User);
			AddInclude(t => t.TeacherSubjects);
		}
	}
}
