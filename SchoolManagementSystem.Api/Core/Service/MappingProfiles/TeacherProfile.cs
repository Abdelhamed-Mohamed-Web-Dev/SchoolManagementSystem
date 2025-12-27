using AutoMapper;
using Domain.Entities;
using Shared;
using System.Linq;

namespace Service.MappingProfiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<TeacherSubject, TeacherSubjectDto>()
                .ForMember(d => d.ClassName, opt => opt.MapFrom(s => s.Class.Name))
                .ForMember(d => d.SubjectName, opt => opt.MapFrom(s => s.Subject.Name))
                .ReverseMap();

            CreateMap<Exam, ExamDto>()
                .ForMember(d => d.SubjectName, opt => opt.MapFrom(s => s.Subject.Name))
                .ForMember(d => d.ClassName, opt => opt.MapFrom(s => s.Class.Name))
                .ReverseMap();

            CreateMap<GradeResult, GradeResultDto>()
                .ForMember(d => d.StudentName, opt => opt.MapFrom(s => s.Student.FullName))
                .ForMember(d => d.ExamName, opt => opt.MapFrom(s => s.Exam.Name))
                .ReverseMap();

            CreateMap<Student, StudentWithParentsDto>()
                .ForMember(d => d.ClassName, opt => opt.MapFrom(s => s.Class.Name))
                .ForMember(d => d.Parents, opt => opt.MapFrom(s => new[] { s.Parent.FullName }))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.User.Email))
                .ReverseMap();
        }
    }
}