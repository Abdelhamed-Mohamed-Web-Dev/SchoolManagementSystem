using AutoMapper;
using Domain.Entities;
using Shared;
using System.Linq;

namespace Service.MappingProfiles
{
	public class AdminProfile : Profile
	{
		public AdminProfile()
		{
			CreateMap<Teacher, TeacherDto>()
				.ForMember(s => s.Subjects, opt => opt.MapFrom(d => d.TeacherSubjects.Select(n => n.Subject.Name)))
				.ReverseMap();
			CreateMap<Student, StudentDto>()
				.ForMember(s => s.Parents, opt => opt.MapFrom(d => d.Parent.FullName))
				.ForMember(s => s.Classes, opt => opt.MapFrom(d => d.Class.Name))
				.ReverseMap();
			CreateMap<Parent, ParentDto>()
				.ForMember(s => s.Students, opt => opt.MapFrom(d => d.Students.Select(n => n.FullName)))
				.ReverseMap();

			// Map create/update DTOs to Parent
			CreateMap<CreateParentDto, Parent>();
			CreateMap<UpdateParentDto, Parent>();
		}
	}
}
