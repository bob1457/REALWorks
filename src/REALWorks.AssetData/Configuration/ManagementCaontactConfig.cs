using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using REALWorks.AssetCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static REALWorks.AssetCore.Entities.ManagementContract;

namespace REALWorks.AssetData.Configuration
{
    public class ManagementCaontactConfig : IEntityTypeConfiguration<ManagementContract>
    {
        public void Configure(EntityTypeBuilder<ManagementContract> entity)
        {
            entity.Property(e => e.ManagementContractDocUrl).HasMaxLength(150);
           

            entity.Property(e => e.ManagementContractTitle)
                        .IsRequired()
                        .HasMaxLength(50);

            entity.Property(e => e.ManagementFeeScale)
                        .IsRequired()
                        .HasMaxLength(50);

            entity.Property(e => e.PlacementFeeScale)
                        .IsRequired()
                        .HasMaxLength(50);

            entity.HasOne(d => d.Property)
                        .WithMany(p => p.ManagementContract)
                        .HasForeignKey(d => d.PropertyId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ManagementContract_Property");

            entity.Property(e => e.Type)
               .HasConversion(
                   v => v.ToString(),
                   v => (ContractType)Enum.Parse(typeof(ContractType), v));
        }
    }
}
