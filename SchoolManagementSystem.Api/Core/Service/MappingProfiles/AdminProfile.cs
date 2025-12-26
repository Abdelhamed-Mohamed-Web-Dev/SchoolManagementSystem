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
				.ForMember(s => s.Email, opt => opt.MapFrom(d => d.User.Email))
				.ReverseMap();



			CreateMap<Student, StudentDto>()
				.ForMember(s => s.Email, opt => opt.MapFrom(d => d.User.Email))
				.ForMember(s => s.Parent, opt => opt.MapFrom(d => d.Parent.FullName))
				.ForMember(s => s.Class, opt => opt.MapFrom(d => d.Class.Name))
				.ForMember(s => s.Grade, opt => opt.MapFrom(d => d.Grade.Name))
				.ReverseMap();



			CreateMap<Parent, ParentDto>()
				.ForMember(s => s.Students, opt => opt.MapFrom(d => d.Students.Select(n => n.FullName)))
				.ForMember(s => s.Email, opt => opt.MapFrom(d => d.User.Email))
				.ReverseMap();

			//CreateMap<Parent, CreateParentDto>()
			//	.ForMember(d => d.Students, opt => opt.MapFrom(d => d.Students.Select(s => s.Id)))
			//	.ForMember(d => d.Email, opt => opt.MapFrom(d => d.User.Email))
			//	.ReverseMap();

			CreateMap<Class, ClassDto>()
				.ForMember(d => d.Grade, opt => opt.MapFrom(s => s.Grade.Name))
				.ForMember(d => d.Students, opt => opt.MapFrom(s => s.Students.Select(s => s.FullName)))
				.ForMember(d => d.Subjects, opt => opt.MapFrom(s => s.TeacherSubjects.Select(s => s.Subject.Name)))
				.ForMember(d => d.Exams, opt => opt.MapFrom(s => s.Exams.Select(s => s.Name)))
				.ReverseMap();

			// Map create/update DTOs to Parent
			CreateMap<CreateParentDto, Parent>();
			CreateMap<UpdateParentDto, Parent>();
		}
	}
}
