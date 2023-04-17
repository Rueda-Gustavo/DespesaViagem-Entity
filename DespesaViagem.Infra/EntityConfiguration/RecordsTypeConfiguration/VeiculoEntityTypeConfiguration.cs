/*
using DespesaViagem.Domain.Models.Core.Records;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespesaViagem.Infra.EntityConfiguration.RecordsTypeConfiguration
{
    public class VeiculoEntityTypeConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable($"{nameof(Veiculo)}s");

            builder.Property(p => p.Placa)
                 .HasMaxLength(10)
                 .IsUnicode(false)
                 .IsRequired(true);

            builder.Property(p => p.Modelo)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder
                .HasOne(despDesl => despDesl.DespesaDeslocamento)
                .WithOne(veic => veic.Veiculo);
        }
    }
}
*/