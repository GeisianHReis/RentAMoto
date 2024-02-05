using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentAMoto.Domain.Entities;

namespace RentAMoto.Infrastructure.Configurations
{
    public class EntregadorConfiguration : IEntityTypeConfiguration<Entregador>
    {
        public void Configure(EntityTypeBuilder<Entregador> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.CNPJ)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(e => e.DataNascimento)
                .IsRequired();

            builder.Property(e => e.NumeroCNH)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(e => e.TipoCNH)
                .IsRequired();
        }
    }
}