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
		public DbSet<Grade> Grades => Set<Grade>();
		public DbSet<Attendance> Attendances => Set<Attendance>();
		public DbSet<Exam> Exams => Set<Exam>();
		public DbSet<GradeResult> GradeResults => Set<GradeResult>();

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

		}
	}
}
