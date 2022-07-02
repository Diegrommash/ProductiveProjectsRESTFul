using Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Configuration
{
    public class TypeMeasurementUnitConfig : IEntityTypeConfiguration<TypeMeasurementUnit>
    {
        public void Configure(EntityTypeBuilder<TypeMeasurementUnit> builder)
        {
            builder.ToTable("TypeMeasurementUnits");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(300);

            builder.Property(p => p.CreatedBy)
                .HasMaxLength(50);

            builder.Property(p => p.LastModified)
            .HasMaxLength(50);

        }
    }
}
