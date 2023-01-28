using Assignment.DTO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DAL.Configurations
{
	public class PersonUserConfiguration : IEntityTypeConfiguration<PersonUserEntity>
	{
		public void Configure(EntityTypeBuilder<PersonUserEntity> builder)
		{
			builder.Property(s => s.Id).ValueGeneratedOnAdd();

			builder.HasIndex(u => u.CardID).IsUnique();

			builder.Property(s => s.CardID).HasMaxLength(20);

			builder.Property(s => s.DateOfBirth).HasColumnType("date");

			builder.Property(s => s.Name).HasMaxLength(50);

			builder.Property(s => s.Surname).HasMaxLength(50);

			builder.Property(s => s.CompanyName).HasMaxLength(50);

			builder.Property(s => s.Email).HasMaxLength(20);

			builder.Property(s => s.Address).HasMaxLength(150);

			builder.Property(s => s.Telephone).HasMaxLength(15);

			// configures one-to-many relationship
			builder
				.HasOne(s => s.Company)
				.WithMany(s => s.Persons)
				.HasForeignKey(s => s.CompanyId)
				.HasConstraintName("FK_CompanyId")
				.IsRequired()
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
