using Assignment.DTO.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Assignment.DAL.Configurations
{
	public class CompanyUserConfiguration : IEntityTypeConfiguration<CompanyUserEntity>
	{
		public void Configure(EntityTypeBuilder<CompanyUserEntity> builder)
		{
			builder.Property(s => s.Id).ValueGeneratedOnAdd();

			builder.HasIndex(u => u.TaxID).IsUnique();

			builder.Property(s => s.TaxID).HasMaxLength(20);

			builder.Property(s => s.CompanyName).HasMaxLength(50);

			builder.Property(s => s.Email).HasMaxLength(20);

			builder.Property(s => s.Address).HasMaxLength(150);

			builder.Property(s => s.Telephone).HasMaxLength(15);
		}
	}
}
