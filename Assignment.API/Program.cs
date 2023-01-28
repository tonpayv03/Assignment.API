using Assignment.BSL.Services;
using Assignment.DAL.Contexts;
using Assignment.DAL.Repositories;
using Assignment.DTO.Interfaces.IRepositories;
using Assignment.DTO.Interfaces.IServices;
using Assignment.API.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
			var builder = WebApplication.CreateBuilder(args);

			builder.Logging.ClearProviders();
			builder.Logging.AddConsole();

			builder.Services.AddCors(options =>
			{
				options.AddPolicy(name: MyAllowSpecificOrigins,
					policy => policy
						.WithOrigins("http://localhost:3000")
						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials());
			});

			builder.Services.Configure<ApiBehaviorOptions>(options =>
			{
				options.SuppressModelStateInvalidFilter = true;
			});

			// Add services to the container.
			builder.Services.AddControllers(options =>
			{
				//options.Filters.Add(new HttpResponseExceptionFilter());
			});

			builder.Services.AddDbContext<AssignmentContext>();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();


			DependencyInjection(builder.Services);


			var app = builder.Build();

			// Allow Cors from React web
			app.UseCors(MyAllowSpecificOrigins);

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}

		public static void DependencyInjection(IServiceCollection services)
		{
			services.AddScoped<ValidationFilterAttribute>();

			services.AddScoped<IUserService, UserService>();

			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IActionRepository, ActionRepository>();
		}
	}
}