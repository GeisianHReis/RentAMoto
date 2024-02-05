using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentAMoto.Domain.Entities;

namespace RentAMoto.Infrastructure.Configurations
{
    public class MotoConfiguration : IEntityTypeConfiguration<Moto>
    {
        public void Configure(EntityTypeBuilder<Moto> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Ano)
                .IsRequired();
            
            builder.Property(e => e.Modelo)
                .IsRequired();
                
            builder.Property(e => e.Placa)
                .IsRequired()
                .HasMaxLength(7);
            
            builder.Property(e => e.Disponivel)
                .IsRequired();
        }
    }
}