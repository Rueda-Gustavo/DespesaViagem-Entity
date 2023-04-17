/*
using DespesaViagem.Domain.Models.Despesas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespesaViagem.Infra.EntityConfiguration.Despesas
{
    public class DespesaRefeicaoEntityTypeConfiguration : IEntityTypeConfiguration<DespesaRefeicao>
    {
        public void Configure(EntityTypeBuilder<DespesaRefeicao> builder)
        {
            builder.ToTable($"{nameof(DespesaRefeicao)}");
            /*builder.HasKey(k => k.Id);

            builder.Property(p => p.NomeDespesa)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.DescricaoDespesa)
                   .HasMaxLength(60)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.TotalDespesa)
                   .HasColumnType("decimal")
                   .HasPrecision(10,2)
                   .IsRequired(true);

            builder.Property(p => p.DataDespesa)
                   .HasColumnType("datetime")
                   .IsRequired(true);
            *//*
            builder
                .HasOne(estab => estab.Estabelecimento)
                .WithOne(despRef => despRef.DespesaRefeicao);

            builder
                .HasOne(v => v.Viagem)
                .WithMany(despRef => despRef.DespesaRefeicao);
        }
    }
}
*/