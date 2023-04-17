/*
using DespesaViagem.Domain.Models.Despesas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespesaViagem.Infra.EntityConfiguration.Despesas
{
    public class DespesaPassagemEntityTypeConfiguration : IEntityTypeConfiguration<DespesaPassagem>
    {
        public void Configure(EntityTypeBuilder<DespesaPassagem> builder)
        {
            builder.ToTable($"{nameof(DespesaPassagem)}");            

            builder.Property(p => p.Companhia)
                   .HasMaxLength(50)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.Origem)
                   .HasMaxLength(30)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.Destino)
                   .HasMaxLength(30)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.DataHoraEmbarque)
                   .HasColumnType("datetime2")
                   .IsRequired(true);

            builder.Property(p => p.Preco)
                   .HasColumnType("decimal")
                   .HasPrecision(10, 2)
                   .IsRequired(true);
 
            builder
                .HasOne(v => v.Viagem)
                .WithMany(despPass => despPass.DespesaPassagem);
        }
    }
}
*/