using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using REALWorks.AssetCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetData.Configuration
{
    public class OwnerConfig : IEntityTypeConfiguration<PropertyOwner>
    {
        public void Configure(EntityTypeBuilder<PropertyOwner> entity)
        {
            entity.Property(e => e.ContactEmail)
                    .IsRequired()
                    .HasMaxLength(100);

            entity.Property(e => e.ContactTelephone1)
                .IsRequired()
                .HasMaxLength(25);

            entity.Property(e => e.ContactTelephone2).HasMaxLength(25);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.UserAvartaImgUrl)
                .IsRequired()
                .HasMaxLength(100)
                .HasDefaultValueSql("('default')");

            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValueSql("('tba')");
        }
    }
}
