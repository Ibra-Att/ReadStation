using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadStation.Models.Entities;
using static ReadStation.Helper.Enums.Enums;

namespace ReadStation.Models.EntityConfigurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
    
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscription");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.Description).HasMaxLength(60);
            builder.Property(x => x.DurationInDays).HasDefaultValue(DurationInDays.Thirty);
            builder.Property(x => x.MembershipTier).HasConversion<string>();
            builder.Property(x => x.DurationInDays).HasConversion<string>();


            builder.ToTable(x => x.HasCheckConstraint("CH_Subscription_PricePerMonth", "PricePerMonth>=4.99"));
            builder.ToTable(x => x.HasCheckConstraint("CH_Subscription_DownloadableContentPerMonth", "DownloadableContentPerMonth>=15"));

        }
    }
}
