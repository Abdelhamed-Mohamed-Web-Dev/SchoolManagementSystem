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


		}
	}
}
