using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadStation.Models.Entities;

namespace ReadStation.Models.EntityConfigurations
{
    public class UserSubscriptionConfiguration : IEntityTypeConfiguration<UserSubscription>
    {
        public void Configure(EntityTypeBuilder<UserSubscription> builder)
        {
            builder.ToTable("UserSubscription");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.Promotion).HasDefaultValue(1);
            

            builder.ToTable(x => x.HasCheckConstraint("CH_UserSubscription_NetPrice", "NetPrice>= 0"));
            builder.ToTable(x => x.HasCheckConstraint("CH_UserSubscription_Price", "Price>= 0"));
            builder.ToTable(x => x.HasCheckConstraint("CH_SubscriptionContent_DownloadCounter", "DownloadCounter>=0"));
            builder.ToTable(x => x.HasCheckConstraint("CH_UserSubscription_DurationInMonths", "DurationInMonths<= 12"));
            builder.ToTable(x => x.HasCheckConstraint("CH_UserSubscription_Promotion", "Promotion>=0.05 AND Promotion<=1 "));
        }
    }
}
