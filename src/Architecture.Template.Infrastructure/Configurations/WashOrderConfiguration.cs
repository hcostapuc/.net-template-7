using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public sealed class WashOrderConfiguration : IEntityTypeConfiguration<WashOrderEntity>
{
    public void Configure(EntityTypeBuilder<WashOrderEntity> builder)
    {
        builder.Ignore(x => x.DomainEvents);
    }
}
