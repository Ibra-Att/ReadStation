using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadStation.Models.Entities;

namespace ReadStation.Models.EntityConfigurations
{
    public class SubscriptionContentConfiguration : IEntityTypeConfiguration<SubscriptionContent>
    {
        public void Configure(EntityTypeBuilder<SubscriptionContent> builder)
        {
            builder.ToTable("SubscriptionContent");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
        }
    }
}
