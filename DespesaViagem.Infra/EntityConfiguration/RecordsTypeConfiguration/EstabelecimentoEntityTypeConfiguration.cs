/*
using DespesaViagem.Domain.Models.Core.Records;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespesaViagem.Infra.EntityConfiguration.RecordsTypeConfiguration
{
    public class EstabelecimentoEntityTypeConfiguration : IEntityTypeConfiguration<Estabelecimento>
    {
        public void Configure(EntityTypeBuilder<Estabelecimento> builder)
        {
            builder.ToTable($"{nameof(Estabelecimento)}");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.NomeEstabelecimento)
                   .HasMaxLength(150)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.CNPJ)
                   .HasMaxLength(15)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder
                   .HasOne(despRef => despRef.DespesaRefeicao)
                   .WithOne(estab => estab.Estabelecimento);
        }
    }
}
*/