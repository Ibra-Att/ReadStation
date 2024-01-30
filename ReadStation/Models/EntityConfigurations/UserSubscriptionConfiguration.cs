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


            builder.ToTable(x => x.HasCheckConstraint("CH_UserSubscription_NetPrice", "NetPrice>= 0"));
            builder.ToTable(x => x.HasCheckConstraint("CH_UserSubscription_DurationInDays", "DurationInDays<= 365"));
            builder.ToTable(x => x.HasCheckConstraint("CH_UserSubscription_Promotion", "Promotion<=0.50 "));
        }
    }
}
