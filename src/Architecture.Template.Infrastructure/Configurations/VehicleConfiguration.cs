using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class VehicleConfiguration : IEntityTypeConfiguration<VehicleEntity>
{
    public void Configure(EntityTypeBuilder<VehicleEntity> builder)
    {
        //TODO: ver como ta ignorando o dmainevents da versao 7.0
        builder.Ignore(x => x.DomainEvents);
        //builder.OwnsOne(x => x.Colour);//TODO voltar quando voltar com o value object
        builder.HasIndex(x => new { x.ClientId, x.Plate })
               .IsUnique();
    }
}
