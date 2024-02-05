using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentAMoto.Domain.Entities;

namespace RentAMoto.Infrastructure.Configurations
{
    public class LocacaoConfiguration : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.DataInicio)
                .IsRequired();
            
            builder.Property(e => e.DataTermino)
                .IsRequired();
            
            builder.Property(e => e.Valor)
                .IsRequired();
            
            builder.Property(e => e.EntregadorId)
                .IsRequired();
            
            builder.Property(e => e.MotoId)
                .IsRequired();
            
            builder.HasOne(e => e.Entregador)
                .WithMany()
                .HasForeignKey(e => e.EntregadorId);
            
            builder.HasOne(e => e.Moto)
                .WithMany()
                .HasForeignKey(e => e.MotoId);
        }
    }
}