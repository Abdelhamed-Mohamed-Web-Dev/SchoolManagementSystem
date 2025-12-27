using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions.NotFoundExceptions;
using Domain.Exceptions;
using ServiceAbstraction.Teacher;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.TeacherService
{
    public class TeacherService(IUnitOfWork unitOfWork, IMapper mapper) : ITeacherService
    {
        private readonly IUnitOfWork _uow = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<TeacherDto>> GetTeachersAsync(Shared.Params.TeachersParams _params)
        {
            var teachers = await _uow.GetRepository<Teacher, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<TeacherDto>>(teachers ?? new List<Teacher>());
        }

        public async Task<TeacherDto> GetTeacherByIdAsync(int id)
        {
            var teacher = await _uow.GetRepository<Teacher, int>().GetAsync(id);
            return teacher is not null ? _mapper.Map<TeacherDto>(teacher) : throw new TeacherNotFoundException(id);
        }

        public async Task<IEnumerable<TeacherSubjectDto>> GetTeacherSubjectsAsync(int teacherId)
        {
            var subjects = await _uow.GetRepository<TeacherSubject, int>().GetAllAsync();
            var my = subjects.Where(s => s.TeacherId == teacherId);
            return _mapper.Map<IEnumerable<TeacherSubjectDto>>(my);
        }

        public async Task<IEnumerable<ClassDto>> GetMyClassesAsync(int teacherId)
        {
            var teacherSubjects = await _uow.GetRepository<TeacherSubject, int>().GetAllAsync();
            var classIds = teacherSubjects.Where(ts => ts.TeacherId == teacherId).Select(ts => ts.ClassId).Distinct();
            var classes = await _uow.GetRepository<Class, int>().GetAllAsync();
            var my = classes.Where(c => classIds.Contains(c.Id));
            return _mapper.Map<IEnumerable<ClassDto>>(my);
        }

        public async Task<IEnumerable<StudentWithParentsDto>> GetMyStudentsAsync(int teacherId)
        {
            var teacherSubjects = await _uow.GetRepository<TeacherSubject, int>().GetAllAsync();
            var classIds = teacherSubjects.Where(ts => ts.TeacherId == teacherId).Select(ts => ts.ClassId).Distinct();
            var students = await _uow.GetRepository<Student, int>().GetAllAsync();
            var myStudents = students.Where(s => classIds.Contains(s.ClassId));
            return _mapper.Map<IEnumerable<StudentWithParentsDto>>(myStudents);
        }

        public async Task<IEnumerable<ExamDto>> GetExamSchedulesAsync(int teacherId)
        {
            var teacherSubjects = await _uow.GetRepository<TeacherSubject, int>().GetAllAsync();
            var pairs = teacherSubjects.Where(ts => ts.TeacherId == teacherId).Select(ts => new { ts.ClassId, ts.SubjectId }).ToList();
            var exams = await _uow.GetRepository<Exam, int>().GetAllAsync();
            var myExams = exams.Where(e => pairs.Any(p => p.ClassId == e.ClassId && p.SubjectId == e.SubjectId));
            return _mapper.Map<IEnumerable<ExamDto>>(myExams);
        }

        public async Task<IEnumerable<GradeResultDto>> GetExamResultsAsync(int examId)
        {
            var results = await _uow.GetRepository<GradeResult, int>().GetAllAsync();
            var my = results.Where(r => r.ExamId == examId);
            return _mapper.Map<IEnumerable<GradeResultDto>>(my);
        }

        public async Task SetStudentScoreAsync(int examId, int studentId, int score)
        {
            var exam = await _uow.GetRepository<Exam, int>().GetAsync(examId);
            if (exam is null) throw new NotFoundException($"Exam with Id [[{examId}]] not found.");






















}    }        }
n            await _uow.SaveChangesAsync();            }                repo.Update(entry);                entry.Score = score;            {            else            }                await repo.AddAsync(gr);                };                    Score = score                    GradeId = exam.GradeId,                    StudentId = studentId,                    ExamId = examId,                {                var gr = new GradeResult            {            if (entry is null)            var entry = (await repo.GetAllAsync()).FirstOrDefault(r => r.ExamId == examId && r.StudentId == studentId);n            var repo = _uow.GetRepository<GradeResult, int>();