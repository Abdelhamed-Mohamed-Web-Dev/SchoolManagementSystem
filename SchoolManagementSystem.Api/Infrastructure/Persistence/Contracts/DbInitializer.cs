using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace Persistence.Contracts
{
	public class DbInitializer(MainContext mainContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		 : IDbInitializer
	{
		public async Task InitializeIdentityAsync()
		{
			// Seed Default Roles
			if (!roleManager.Roles.Any())
			{
				await roleManager.CreateAsync(new IdentityRole("Student"));
				await roleManager.CreateAsync(new IdentityRole("Parent"));
				await roleManager.CreateAsync(new IdentityRole("Teacher"));
				await roleManager.CreateAsync(new IdentityRole("Admin"));
			}

			//   Seed Default User
			if (!userManager.Users.Any())
			{
				var admin = new IdentityUser
				{
					Email = "admin@school.edu",
					UserName = "Admin",
					PhoneNumber = "01123456789"
				};
				await userManager.CreateAsync(admin, "$Ss12345678");
				await userManager.AddToRoleAsync(admin, "Admin");

				var dataFile = await File.ReadAllTextAsync($@"..\Infrastructure\Persistence\Seeding\Users.json");
				var roles = JsonSerializer.Deserialize<List<r>>(dataFile);
				var data = JsonSerializer.Deserialize<List<IdentityUser>>(dataFile);

				for (var i = 0; i < data.Count; i++)
				{
					var user = data[i];
					var role = roles[i].Role;
					await userManager.CreateAsync(user, "$Ss12345678");
					await userManager.AddToRoleAsync(user, role);
				}
			}
		}

		public async Task InitializeAsync()
		{
			if (!mainContext.Admins.Any())
			{
				var adminUser = await userManager.FindByEmailAsync("admin@school.edu");
				await mainContext.Admins.AddAsync(new Admin { FullName = "Admin", UserId = adminUser?.Id ?? "" });
				await mainContext.SaveChangesAsync();
			}
			await Init<Parent>("Parents.json");
			await Init<Teacher>("Teachers.json");
			await Init<Grade>("Grades.json");
			await Init<Subject>("Subjects.json");
			await Init<Class>("Classes.json");
			await Init<TeacherSubject>("TeacherSubjects.json");
			await Init<Student>("Students.json");
			await Init<Attendance>("Attendance.json");
			await Init<Exam>("Exams.json");
			await Init<GradeResult>("GradeResults.json");
		}

		async Task Init<TTable>(string fileName) where TTable : class
		{
			if (!mainContext.Set<TTable>().Any())
			{
				var dataFile = await File.ReadAllTextAsync($@"..\Infrastructure\Persistence\Seeding\{fileName}");
				var data = JsonSerializer.Deserialize<List<TTable>>(dataFile);
				if (data is not null && data.Any())
				{
					await mainContext.Set<TTable>().AddRangeAsync(data);
					var res2 = await mainContext.SaveChangesAsync();
				}
			}
		}
	}
	class r { public string Role { get; set; } }
}

