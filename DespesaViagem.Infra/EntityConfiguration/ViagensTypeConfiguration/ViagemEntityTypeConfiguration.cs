using DespesaViagem.Domain.Models.Viagens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespesaViagem.Infra.EntityConfiguration.Viagens
{
    public class ViagemEntityTypeConfiguration : IEntityTypeConfiguration<Viagem>
    {
        public void Configure(EntityTypeBuilder<Viagem> builder)
        {
            builder.ToTable($"Viagens");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.NomeViagem)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.DescricaoViagem)
                   .HasMaxLength(60)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.Adiantamento)
                   .HasColumnType("decimal")
                   .HasPrecision(10, 2)
                   .IsRequired();

            builder.Property(p => p.TotalDespesas)
                   .HasColumnType("decimal")
                   .HasPrecision(10, 2)
                   .IsRequired();

            builder.Property(p => p.StatusViagem)
                   .HasColumnType("varchar")
                   .HasMaxLength(15)
                   .IsUnicode(false)
                   .IsRequired();            

            builder.Ignore(p => p.Despesas);

            builder
                .HasMany(d => d.Despesas)
                .WithOne(v => v.Viagem)
                .HasForeignKey(d => d.IdViagem);

            builder
                .HasOne(f => f.Funcionario)
                .WithMany(v => v.Viagens)
                .HasForeignKey(f => f.IdFuncionario);           
        }
    }
}
