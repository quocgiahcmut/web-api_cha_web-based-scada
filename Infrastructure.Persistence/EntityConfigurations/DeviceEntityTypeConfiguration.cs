using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

public class DeviceEntityTypeConfiguration : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> deviceConfig)
    {
        deviceConfig
            .HasKey(d => d.Id);

        deviceConfig
            .Property(d => d.EonNodeId)
            .IsRequired();

        deviceConfig
            .HasMany(d => d.Tags)
            .WithOne()
            .HasForeignKey(t => t.DeviceId);
    }
}
