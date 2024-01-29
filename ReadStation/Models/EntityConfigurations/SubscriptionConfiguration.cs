using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadStation.Models.Entities;

namespace ReadStation.Models.EntityConfigurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
    
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            throw new NotImplementedException();
        }
    }
}
