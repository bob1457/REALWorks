using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using REALWorks.AssetCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetData.Configuration
{
    public class PropertyImgConfig : IEntityTypeConfiguration<PropertyImg>
    {
        public void Configure(EntityTypeBuilder<PropertyImg> entity)
        {
            //throw new NotImplementedException();

            entity.Property(e => e.PropertyImgUrl).HasMaxLength(350);

            entity.Property(e => e.PropertyImgTitle)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Property)
                .WithMany(p => p.PropertyImg)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PropertyImg_Property");
        }
    }
}
