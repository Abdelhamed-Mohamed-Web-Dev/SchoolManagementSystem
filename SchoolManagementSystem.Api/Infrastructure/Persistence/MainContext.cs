using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Migrations;

namespace Persistence
{
	public class MainContext(DbContextOptions<MainContext> options)
		: IdentityDbContext(options)
	{
		// DbSets

		public DbSet<Student> Students => Set<Student>();
		public DbSet<Teacher> Teachers => Set<Teacher>();
		public DbSet<Parent> Parents => Set<Parent>();
		public DbSet<Admin> Admins => Set<Admin>();

		public DbSet<Class> Classes => Set<Class>();
		public DbSet<Subject> Subjects => Set<Subject>();
		public DbSet<TeacherSubject> TeacherSubjects => Set<TeacherSubject>();
		public DbSet<Enrollment> Enrollments => Set<Enrollment>();
		public DbSet<Attendance> Attendances => Set<Attendance>();
		public DbSet<Exam> Exams => Set<Exam>();
		public DbSet<GradeResult> GradeResults => Set<GradeResult>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ParentStudent>()
				.HasKey(ps => new { ps.ParentId, ps.StudentId });

			modelBuilder.Entity<ParentStudent>()
				.HasOne(ps => ps.Parent)
				.WithMany(p => p.ParentStudents)
				.HasForeignKey(ps => ps.ParentId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ParentStudent>()
				.HasOne(ps => ps.Student)
				.WithMany(s => s.ParentStudents)
				.HasForeignKey(ps => ps.StudentId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Student>()
				.HasOne(s => s.User)
				.WithMany()
				.HasForeignKey(s => s.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Teacher>()
				.HasOne(s => s.User)
				.WithMany()
				.HasForeignKey(s => s.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Parent>()
				.HasOne(s => s.User)
				.WithMany()
				.HasForeignKey(s => s.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Admin>()
				.HasOne(s => s.User)
				.WithMany()
				.HasForeignKey(s => s.UserId)
				.OnDelete(DeleteBehavior.Restrict);


			//// Parent -> Student (Required)
			//modelBuilder.Entity<Parent>()
			//	.HasOne(p => p.Student)
			//	.WithMany()
			//	.HasForeignKey(p => p.StudentId)
			//	.IsRequired();
			//SchoolManagementSystem
			//// Enrollment
			//modelBuilder.Entity<Enrollment>()
			//	.HasOne(e => e.Student)
			//	.WithMany(s => s.Enrollments)
			//	.HasForeignKey(e => e.StudentId)
			//	.IsRequired();

			//modelBuilder.Entity<Enrollment>()
			//	.HasOne(e => e.Class)
			//	.WithMany(c => c.Enrollments)
			//	.HasForeignKey(e => e.ClassId)
			//	.IsRequired();

			//// TeacherSubject
			//modelBuilder.Entity<TeacherSubject>()
			//	.HasOne(ts => ts.Teacher)
			//	.WithMany(t => t.TeacherSubjects)
			//	.HasForeignKey(ts => ts.TeacherId)
			//	.IsRequired();

			//modelBuilder.Entity<TeacherSubject>()
			//	.HasOne(ts => ts.Subject)
			//	.WithMany(s => s.TeacherSubjects)
			//	.HasForeignKey(ts => ts.SubjectId)
			//	.IsRequired();

			//modelBuilder.Entity<TeacherSubject>()
			//	.HasOne(ts => ts.Class)
			//	.WithMany(c => c.TeacherSubjects)
			//	.HasForeignKey(ts => ts.ClassId)
			//	.IsRequired();

			//// Attendance
			//modelBuilder.Entity<Attendance>()
			//	.HasOne(a => a.Student)
			//	.WithMany(s => s.Attendances)
			//	.HasForeignKey(a => a.StudentId)
			//	.IsRequired();

			//modelBuilder.Entity<Attendance>()
			//	.HasOne(a => a.Class)
			//	.WithMany(c => c.Attendances)
			//	.HasForeignKey(a => a.ClassId)
			//	.IsRequired();

			//// Exam
			//modelBuilder.Entity<Exam>()
			//	.HasOne(e => e.Subject)
			//	.WithMany(s => s.Exams)
			//	.HasForeignKey(e => e.SubjectId)
			//	.IsRequired();

			//modelBuilder.Entity<Exam>()
			//	.HasOne(e => e.Class)
			//	.WithMany(c => c.Exams)
			//	.HasForeignKey(e => e.ClassId)
			//	.IsRequired();

			//// GradeResult
			//modelBuilder.Entity<GradeResult>()
			//	.HasOne(gr => gr.Exam)
			//	.WithMany(e => e.GradeResults)
			//	.HasForeignKey(gr => gr.ExamId)
			//	.IsRequired();

			//modelBuilder.Entity<GradeResult>()
			//	.HasOne(gr => gr.Student)
			//	.WithMany(s => s.GradeResults)
			//	.HasForeignKey(gr => gr.StudentId)
			//	.IsRequired();

		}
	}
}
