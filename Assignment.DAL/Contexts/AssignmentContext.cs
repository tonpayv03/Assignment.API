using Assignment.DTO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DAL.Contexts
{
	public class AssignmentContext : DbContext
	{
		public DbSet<PersonUserEntity> PersonUser { get; set; }
		public DbSet<CompanyUserEntity> CompanyUser { get; set; }

		//public DbSet<InformationEntity> Informations { get; set; }

		//ILoggerFactory loggerFactory = LoggerFactory.Create(option => option.AddConsole());

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=Localhost;Database=Assignment;TrustServerCertificate=True;User Id=SA;Password=P@ssw0rd;Integrated Security=false");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
