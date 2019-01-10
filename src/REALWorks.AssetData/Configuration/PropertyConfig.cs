using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using REALWorks.AssetCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static REALWorks.AssetCore.Entities.Property;

namespace REALWorks.AssetData.Configuration
{
    public class PropertyConfig : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> entity)
        {
            //throw new NotImplementedException();

            //entity.Property(e => e.FurnishingId).HasDefaultValueSql("((0))");

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.PropertyDesc).HasMaxLength(250);

            entity.Property(e => e.PropertyLogoImgUrl).HasMaxLength(100);

            entity.Property(e => e.PropertyManagerUserName);

            entity.Property(e => e.PropertyName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.PropertyVideoUrl).HasMaxLength(100);

            entity.Property(e => e.StrataCouncilId).HasDefaultValueSql("((0))");
            
            // Value conversion for Enum type
            entity.Property(e => e.Type) 
                .HasConversion(
                    v => v.ToString(),
                    v => (PropertyType)Enum.Parse(typeof(PropertyType), v));

            entity.Property(e => e.Status) 
               .HasConversion(
                   v => v.ToString(),
                   v => (RentalStatus)Enum.Parse(typeof(RentalStatus), v));
        }
    }
}
