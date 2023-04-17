/*
using DespesaViagem.Domain.Models.Despesas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespesaViagem.Infra.EntityConfiguration.Despesas
{
    public class DespesaDeslocamentoEntityTypeConfiguration : IEntityTypeConfiguration<DespesaDeslocamento>
    {
        public void Configure(EntityTypeBuilder<DespesaDeslocamento> builder)
        {
            builder.ToTable($"{nameof(DespesaDeslocamento)}");

            builder.HasBaseType(typeof(Despesa));
            
            builder.Property(p => p.Quilometragem)
                   .HasColumnType("integer")
                   .IsRequired(true);

            builder.Property(p => p.ValorPorQuilometro)
                   .HasColumnType("decimal")
                   .HasPrecision(10, 2)
                   .IsRequired(true);

            builder
                .HasOne(veic => veic.Veiculo)
                .WithOne(despDesl => despDesl.DespesaDeslocamento);

            builder
                .HasOne(v => v.Viagem)
                .WithMany(despDesl => despDesl.DespesaDeslocamento);

        }
    }
}
*/
