using Shared.Params;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ConcreteSpecifications
{
	public class StudentSpecifications : Specifications<Student>
	{
		public StudentSpecifications(StudentsParams _params)
		: base(p => (!_params.GradeId.HasValue || p.GradeId == _params.GradeId) &&
					(!_params.ClassId.HasValue || p.ClassId == _params.ClassId) &&
					(!_params.ParentId.HasValue || p.ParentId == _params.ParentId) &&
					(string.IsNullOrWhiteSpace(_params.Gender) || p.Gender.ToUpper() == _params.Gender.ToUpper()) &&
					(string.IsNullOrWhiteSpace(_params.Search) || p.FullName.ToUpper().Contains(_params.Search!.ToUpper().Trim())))

		{
			AddInclude(p => p.User);
			AddInclude(p => p.Parent);
			AddInclude(p => p.Class);
			AddInclude(p => p.Grade);
			ApplyPagination(_params.PageSize, _params.PageIndex);
		}
		public StudentSpecifications(int id)
			: base(s => s.Id == id)
		{
			AddInclude(p => p.User);
			AddInclude(p => p.Parent);
			AddInclude(p => p.Class);
			AddInclude(p => p.Grade);
		}
	}
}
