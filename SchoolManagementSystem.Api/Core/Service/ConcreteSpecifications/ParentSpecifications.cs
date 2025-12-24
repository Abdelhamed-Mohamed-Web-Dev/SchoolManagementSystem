using Shared.Params;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ConcreteSpecifications
{
	public class ParentSpecifications : Specifications<Parent>
	{
		public ParentSpecifications(ParentsParams _params)
			: base(p => (!_params.StudentId.HasValue || p.ParentStudents.Any(ps => _params.StudentId == ps.StudentId)) &&
					(string.IsNullOrWhiteSpace(_params.Search) || p.FullName.ToUpper().Contains(_params.Search!.ToUpper().Trim())))

		{
			AddInclude(p => p.ParentStudents);
			ApplyPagination(_params.PageSize, _params.PageIndex);
		}
		public ParentSpecifications()
			: base(null)
		{
			AddInclude(p => p.ParentStudents);
		}
	}
}
