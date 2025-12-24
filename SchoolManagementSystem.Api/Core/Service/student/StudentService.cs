using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using ServiceAbstraction.student;
using Shared;

namespace Service.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // =========================
        // Students CRUD
        // =========================

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var students = await unitOfWork
                .GetRepository<Student, int>()
                .GetAllAsync();

            return students == null
                ? new List<StudentDto>()
                : mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var student = await unitOfWork
                .GetRepository<Student, int>()
                .GetAsync(id);

            return student == null
                ? null
                : mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> CreateAsync(CreateStudentDto dto)
        {
            var student = mapper.Map<Student>(dto);

            await unitOfWork
                .GetRepository<Student, int>()
                .AddAsync(student);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<StudentDto>(student);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var repo = unitOfWork.GetRepository<Student, int>();
            var student = await repo.GetAsync(id);

            if (student == null)
                return false;

            repo.Delete(student);
            await unitOfWork.SaveChangesAsync();
            return true;
        }

        // =========================
        // Student Business Logic
        // =========================

        // 🟢 الكورسات المتاحة
        public async Task<IEnumerable<StudentCourseDto>> GetAvailableCoursesAsync()
        {
            var subjects = await unitOfWork
                .GetRepository<Subject, int>()
                .GetAllAsync();

            return mapper.Map<IEnumerable<StudentCourseDto>>(subjects);
        }

        // 🟢 الكورسات اللي الطالب مسجل فيها
        public async Task<IEnumerable<EnrollmentDto>> GetMyEnrollmentsAsync(int studentId)
        {
            var enrollments = await unitOfWork
                .GetRepository<Enrollment, int>()
                .GetAllAsync();

            var myEnrollments = enrollments
                .Where(e => e.StudentId == studentId);

            return mapper.Map<IEnumerable<EnrollmentDto>>(myEnrollments);
        }

        // 🟢 Attendance بتاع الطالب
        public async Task<IEnumerable<AttendanceDto>> GetMyAttendanceAsync(int studentId)
        {
            var attendance = await unitOfWork
                .GetRepository<Attendance, int>()
                .GetAllAsync();

            var myAttendance = attendance
                .Where(a => a.StudentId == studentId);

            return mapper.Map<IEnumerable<AttendanceDto>>(myAttendance);
            //ااااااااااااااااااااااااااااااااااااااا
        }
    }
}
