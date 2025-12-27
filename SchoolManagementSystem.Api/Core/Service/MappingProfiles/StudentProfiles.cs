using AutoMapper;
using Domain.Entities;
using Shared;
using System.Linq;

namespace Service.MappingProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Teacher, TeacherDto>()
                .ForMember(s => s.Subjects, opt => opt.MapFrom(d => d.TeacherSubjects.Select(n => n.Subject.Name)))
                .ForMember(s => s.Email, opt => opt.MapFrom(d => d.User.Email))
                .ReverseMap();



            CreateMap<Student, StudentDto>()
                .ForMember(d => d.Grade, opt => opt.MapFrom(s => s.Grade.Name))
                .ForMember(s => s.Email, opt => opt.MapFrom(d => d.User.Email))//فين كلاس ال user
                .ForMember(s => s.Parent, opt => opt.MapFrom(d => d.Parent.FullName))
                .ForMember(s => s.Class, opt => opt.MapFrom(d => d.Class.Name))
                .ReverseMap();




            CreateMap<Class, ClassDto>()
                .ForMember(d => d.Grade, opt => opt.MapFrom(s => s.Grade.Name))

                .ForMember(d => d.Students, opt => opt.MapFrom(s => s.Students.Select(s => s.FullName)))

                .ForMember(d => d.Subjects, opt => opt.MapFrom(s => s.TeacherSubjects.Select(s => s.Subject.Name)))

                .ForMember(d => d.Exams, opt => opt.MapFrom(s => s.Exams.Select(s => s.Name)))
                .ReverseMap();


            //me
            CreateMap<Attendance, AttendanceDto>()
                .ForMember(d => d.IsPresent, opt => opt.MapFrom(s => s.Status == "Present"))
                .ForMember(d => d.SubjectName, opt => opt.MapFrom(s => s.Class.TeacherSubjects.Select(s => s.Subject.Name)))
                .ReverseMap();

          

            //me
            CreateMap<Enrollment, EnrollmentDto>()
                .ForMember(d => d.SubjectId, opt => opt.MapFrom(s => s.Class.TeacherSubjects.Select(s => s.Subject.Id)))
                .ForMember(d => d.SubjectName, opt => opt.MapFrom(s => s.Class.TeacherSubjects.Select(s => s.Subject.Name)))
                .ForMember(d => d.EnrollmentDate, opt => opt.MapFrom(s => s.Student.EnrollmentDate))
                .ReverseMap();




            //me
            CreateMap<Subject, StudentCourseDto>()
                .ForMember(d => d.SubjectName, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.TeacherName,opt => opt.MapFrom(s => s.TeacherSubjects.Select(n => n.Teacher.FullName)))
                .ReverseMap();
            

        }
    }
}
