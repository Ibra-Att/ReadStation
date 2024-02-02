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
            builder.Property(x => x.RegistrationDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Phone).HasColumnType("nvarchar(14)");
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Phone).IsUnique();
            builder.Property(x => x.Gender).HasConversion<string>();

            builder.ToTable(x => x.HasCheckConstraint("CH_User_Phone", "Phone LIKE '00%' AND LEN(Phone) = 14"));
            builder.ToTable(x => x.HasCheckConstraint("CH_User_FullName", "LEN(FullName) >= 5"));
            builder.ToTable(x => x.HasCheckConstraint("CH_User_Age", "Age >= 1"));
            builder.ToTable(x => x.HasCheckConstraint("CH_User_Salary", "Salary >= 260"));
            builder.ToTable(x => x.HasCheckConstraint("CH_User_Email", "EMAIL LIKE '%@___%.COM'"));
           


        }
    }
}
