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
				.ForMember(s => s.Parents, opt => opt.MapFrom(d => d.ParentStudents.Select(n => n.Parent.FullName)))
				.ForMember(s => s.Classes, opt => opt.MapFrom(d => d.Enrollments.Select(n => n.Class.Name)))
				.ReverseMap();
			CreateMap<Parent, ParentDto>()
				.ForMember(s => s.Students, opt => opt.MapFrom(d => d.ParentStudents.Select(n => n.Student.FullName)))
				.ReverseMap();
		}
	}
}
