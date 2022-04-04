using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

public class TagEntityTypeConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> tagConfig)
    {
        tagConfig
            .HasKey(t => t.Id);

        tagConfig
            .Property(t => t.Name)
            .IsRequired();

        tagConfig
            .Property(t => t.DeviceId)
            .IsRequired();

        tagConfig
            .Property(t => t.EonNodeId)
            .IsRequired();

        tagConfig
            .Property(t => t.DataType)
            .IsRequired();
    }
}
