using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using REALWorks.MarketingCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.MarketingData.Configuration
{
    public class PropertyListingConfig : IEntityTypeConfiguration<PropertyListing>
    {
        public void Configure(EntityTypeBuilder<PropertyListing> builder)
        {
            builder.Property(e => e.ListingDesc).IsRequired();

            builder.HasOne(d => d.RentalProperty)
                .WithMany(p => p.PropertyListing)
                //.HasForeignKey(d => d.RentalPropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PropertyListing_RentalProperty");
        }
    }
}
