using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
{
    public void Configure(EntityTypeBuilder<ClientEntity> builder)
    {
        builder.Ignore(x => x.DomainEvents);
        builder.HasIndex(x => x.Email)
               .IsUnique();
        //builder.OwnsOne(x => x.Email);
        //builder.HasIndex(x => x.Email);//TODO add email index
        builder.Property(x => x.Name)
               .IsRequired();
    }
}
