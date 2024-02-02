using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadStation.Models.Entities;

namespace ReadStation.Models.EntityConfigurations
{
    public class UserContentConfiguration : IEntityTypeConfiguration<UserContent>
    {
        public void Configure(EntityTypeBuilder<UserContent> builder)
        {
            builder.ToTable("UserContent");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

        }

    }
}
