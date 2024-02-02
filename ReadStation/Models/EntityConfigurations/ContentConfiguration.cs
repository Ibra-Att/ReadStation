using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadStation.Models.Entities;

namespace ReadStation.Models.EntityConfigurations
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.ToTable("Content");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Author).HasMaxLength(50);
            builder.Property(x => x.ContentType).HasConversion<string>();
            builder.Property(x => x.Category).HasConversion<string>();

            builder.ToTable(x => x.HasCheckConstraint("CH_Content_DownloadingCount", "DownloadingCount>=0"));
        }
    }
}
