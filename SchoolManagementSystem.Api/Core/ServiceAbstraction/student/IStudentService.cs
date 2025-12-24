using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceAbstraction.student
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDto?> GetByIdAsync(int id);
        Task<StudentDto> CreateAsync(CreateStudentDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<StudentCourseDto>> GetAvailableCoursesAsync();
        Task<IEnumerable<EnrollmentDto>> GetMyEnrollmentsAsync(int studentId);
        Task<IEnumerable<AttendanceDto>> GetMyAttendanceAsync(int studentId);
    }

}
