using Assignment.DTO.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DAL.Configurations
{
	public class FruitConfiguration : IEntityTypeConfiguration<FruitEntity>
	{
		public void Configure(EntityTypeBuilder<FruitEntity> builder)
		{
			builder.Property(s => s.Id).ValueGeneratedOnAdd();

			builder.Property(s => s.Name).HasMaxLength(50);

			builder.Property(s => s.FileName).HasMaxLength(100);
		}
	}
}
