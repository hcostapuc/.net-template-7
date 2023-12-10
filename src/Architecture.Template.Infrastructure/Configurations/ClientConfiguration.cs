using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
{
    public void Configure(EntityTypeBuilder<ClientEntity> builder)
    {
        builder.Ignore(x => x.DomainEvents);
        //TODO: add builder.OwnsOne(x => x.Email); when transform Email to value object
        builder.HasIndex(x => x.Email)
               .IsUnique();
        builder.Property(x => x.Name)
               .IsRequired();
    }
}
