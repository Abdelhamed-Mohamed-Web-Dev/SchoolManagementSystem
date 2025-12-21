using Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Contracts
{
	public class DbInitializer : IDbInitializer
	{

		readonly UserManager<IdentityUser> userManager;
		readonly RoleManager<IdentityRole> roleManager;
		public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
		}

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

				var student = new IdentityUser
				{
					Email = "student@school.edu",
					UserName = "Student",
					PhoneNumber = "01098765432"
				};
				var parent = new IdentityUser
				{
					Email = "parent@school.edu",
					UserName = "Parent",
					PhoneNumber = "01578945612"
				};
				var teacher = new IdentityUser
				{
					Email = "teacher@school.edu",
					UserName = "Teacher",
					PhoneNumber = "01223456789"
				};
				var admin = new IdentityUser
				{
					Email = "admin@school.edu",
					UserName = "Admin",
					PhoneNumber = "01123456789"
				};

				await userManager.CreateAsync(student, "$Ss12345678");
				await userManager.CreateAsync(parent, "$Ss12345678");
				await userManager.CreateAsync(teacher, "$Ss12345678");
				await userManager.CreateAsync(admin, "$Ss12345678");



				await userManager.AddToRoleAsync(student, "Student");
				await userManager.AddToRoleAsync(parent, "Parent");
				await userManager.AddToRoleAsync(teacher, "Teacher");
				await userManager.AddToRoleAsync(admin, "Admin");

			}
		}
	}
}

