using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class VehicleConfiguration : IEntityTypeConfiguration<VehicleEntity>
{
    public void Configure(EntityTypeBuilder<VehicleEntity> builder)
    {
        builder.Ignore(x => x.DomainEvents);
        builder.OwnsOne(x => x.Colour);
        builder.HasIndex(x => x.Plate)
               .IsUnique();
    }
}
