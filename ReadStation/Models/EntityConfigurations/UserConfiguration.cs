using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadStation.Models.Entities;

namespace ReadStation.Models.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x=>x.FullName).HasMaxLength(100);
            builder.Property(x => x.Age).HasDefaultValue(18);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Phone).IsUnique();
            builder.ToTable(x => x.HasCheckConstraint("CH_User_Phone", "Phone LIKE '00------------'"));
            builder.ToTable(x => x.HasCheckConstraint("CH_User_Email", "EMAIL LIKE '%@___%.COM'"));
            builder.Property(u => u.Gender).HasConversion<string>();


        }
    }
}
