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
		//public DbSet<TeacherSubject> TeacherSubjects => Set<TeacherSubject>();
		//public DbSet<ClassTeacher> TeacherClasses => Set<ClassTeacher>();
		public DbSet<Grade> Grades => Set<Grade>();
		public DbSet<Attendance> Attendances => Set<Attendance>();
		public DbSet<Exam> Exams => Set<Exam>();
		public DbSet<GradeResult> GradeResults => Set<GradeResult>();


        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		
			base.OnModelCreating(modelBuilder);

			
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

			modelBuilder.Entity<Grade>()
				.HasMany(g => g.Students)
				.WithOne(s=> s.Grade)
				.HasForeignKey(s => s.GradeId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Grade>()
				.HasMany(g => g.Exams)
				.WithOne(s=> s.Grade)
				.HasForeignKey(s => s.GradeId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Grade>()
				.HasMany(g => g.GradeResults)
				.WithOne(s=> s.Grade)
				.HasForeignKey(s => s.GradeId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Grade>()
				.HasMany(g => g.Classes)
				.WithOne(s=> s.Grade)
				.HasForeignKey(s => s.GradeId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Student>()
				.HasOne(s => s.Class)
				.WithMany(c => c.Students)
				.HasForeignKey(s => s.ClassId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ClassTeacher>()
				.HasKey(tc => new { tc.TeacherId, tc.ClassId });

			modelBuilder.Entity<ClassTeacher>()
				.HasOne(tc => tc.Teacher)
				.WithMany(t => t.TeacherClasses)
				.HasForeignKey(tc => tc.TeacherId);

			modelBuilder.Entity<ClassTeacher>()
				.HasOne(tc => tc.Class)
				.WithMany(c => c.ClassTeachers)
				.HasForeignKey(tc => tc.ClassId);

			modelBuilder.Entity<ClassSubject>()
				.HasKey(tc => new { tc.SubjectId, tc.ClassId });

			modelBuilder.Entity<ClassSubject>()
				.HasOne(tc => tc.Subject)
				.WithMany(t => t.ClassSubjects)
				.HasForeignKey(tc => tc.SubjectId);

			modelBuilder.Entity<ClassSubject>()
				.HasOne(tc => tc.Class)
				.WithMany(c => c.ClassSubjects)
				.HasForeignKey(tc => tc.ClassId);

			modelBuilder.Entity<TeacherSubject>()
				.HasKey(tc => new { tc.SubjectId, tc.TeacherId });

			modelBuilder.Entity<TeacherSubject>()
				.HasOne(tc => tc.Subject)
				.WithMany(t => t.TeacherSubjects)
				.HasForeignKey(tc => tc.SubjectId);

			modelBuilder.Entity<TeacherSubject>()
				.HasOne(tc => tc.Teacher)
				.WithMany(c => c.TeacherSubjects)
				.HasForeignKey(tc => tc.TeacherId);

		}
	}
}
