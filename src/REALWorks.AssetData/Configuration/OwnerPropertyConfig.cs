using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using REALWorks.AssetCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetData.Configuration
{
    public class OwnerPropertyConfig: IEntityTypeConfiguration<OwnerProperty>
    {
        public void Configure(EntityTypeBuilder<OwnerProperty> entity)
        {
            //throw new NotImplementedException();
            entity.HasKey(e => new { e.PropertyId, e.PropertyOwnerId });

            entity.HasOne(d => d.Property)
                .WithMany(p => p.OwnerProperty)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OwnerProperty_Property");

            entity.HasOne(d => d.PropertyOwner)
                .WithMany(p => p.OwnerProperty)
                .HasForeignKey(d => d.PropertyOwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OwnerProperty_PropertyOwner");
        }
    }
}
