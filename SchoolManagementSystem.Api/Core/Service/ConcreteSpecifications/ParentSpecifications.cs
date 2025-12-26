using Shared.Params;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ConcreteSpecifications
{
	public class ParentSpecifications : Specifications<Parent>
	{
		public ParentSpecifications(ParentsParams _params)
			: base(p => (!_params.StudentId.HasValue || p.Students.Any(s => _params.StudentId == s.Id)) &&
					(string.IsNullOrWhiteSpace(_params.Search) || p.FullName.ToUpper().Contains(_params.Search!.ToUpper().Trim())))

		{
			AddInclude(p => p.Students);
			AddInclude(p => p.User);
			ApplyPagination(_params.PageSize, _params.PageIndex);
		}
		public ParentSpecifications(int id)
			: base(p=>p.Id == id)
		{
			AddInclude(p => p.User);
			AddInclude(p => p.Students);
		}
	}
}
