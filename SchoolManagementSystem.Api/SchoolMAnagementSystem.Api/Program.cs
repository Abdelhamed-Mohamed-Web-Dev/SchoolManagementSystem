using Domain.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Contracts;
using Presentation;
using Service;
using Service.AdminService;
using Service.StudentService;
using ServiceAbstraction;
using ServiceAbstraction.student;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace SchoolMAnagementSystem.Api
{
	public static class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
			builder.Services.AddOpenApi();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddAutoMapper(typeof(Service.AssemblyReference).Assembly);
			builder.Services.AddScoped<IDbInitializer, DbInitializer>();
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.Services.AddScoped<IServiceManager, ServiceManger>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddControllers().AddApplicationPart(typeof(ControllerAssembly).Assembly);
			builder.Services.AddDbContext<MainContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSqlConnection")));
			builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<MainContext>();

			var app = builder.Build();

			await app.DataSeeding();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.MapOpenApi();

			}
			app.UseSwagger();
			app.UseSwaggerUI();

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.UseMiddleware<ExceptionHandlerMiddleware>();

			app.Run();
		}
		static async Task DataSeeding(this WebApplication app)
		{
			// Create Scope 
			using var scope = app.Services.CreateScope();
			// Inject
			var initDb = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
			// Call Initializer 
			// Initialization "Users"
			await initDb.InitializeIdentityAsync();
		}

	}
}
