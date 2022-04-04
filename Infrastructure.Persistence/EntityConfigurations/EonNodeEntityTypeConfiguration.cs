using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

public class EonNodeEntityTypeConfiguration : IEntityTypeConfiguration<EonNode>
{
    public void Configure(EntityTypeBuilder<EonNode> eonNodeConfig)
    {
        eonNodeConfig
            .HasKey(e => e.Id);

        eonNodeConfig
            .Property(e => e.Connected)
            .IsRequired();

        eonNodeConfig
            .HasMany(e => e.Devices)
            .WithOne()
            .HasForeignKey(d => d.EonNodeId);
    }
}
