using DespesaViagem.Domain.Models.Despesas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespesaViagem.Infra.EntityConfiguration.Despesas
{
    public class DespesaHospedagemEntityTypeConfiguration : IEntityTypeConfiguration<DespesaHospedagem>
    {
        public void Configure(EntityTypeBuilder<DespesaHospedagem> builder)
        {
            builder.ToTable($"DespesasHospedagem");
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
            */
            builder.Property(p => p.QuantidadeDias)
                   .HasColumnType("integer")
                   .IsRequired(true);

            builder.Property(p => p.ValorDiaria)
                   .HasColumnType("decimal")
                   .IsRequired(true);

            builder
                   .Property(p => p.TipoDespesa)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder
                    .HasOne(e => e.Endereco)
                    .WithMany(d => d.DespesasHospedagem)
                    .HasForeignKey(d => d.IdEndereco);

            /*
            builder
                .HasOne(v => v.Viagem)
                .WithMany(despHosp => despHosp.DespesaHospedagem);
            */
        }
    }
}
