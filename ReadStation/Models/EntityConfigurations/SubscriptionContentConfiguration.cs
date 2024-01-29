using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadStation.Models.Entities;

namespace ReadStation.Models.EntityConfigurations
{
    public class SubscriptionContentConfiguration : IEntityTypeConfiguration<SubscriptionContent>
    {
        public void Configure(EntityTypeBuilder<SubscriptionContent> builder)
        {
            throw new NotImplementedException();
        }
    }
}
