using DespesaViagem.Domain.Models.Viagens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespesaViagem.Infra.EntityConfiguration.Viagens
{
    public class ViagemEntityTypeConfiguration : IEntityTypeConfiguration<Viagem>
    {
        public void Configure(EntityTypeBuilder<Viagem> builder)
        {
            builder.ToTable($"{nameof(Viagem)}");
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

            /*
            builder
                .HasMany(despHosp => despHosp.DespesaHospedagem)
                .WithOne(v => v.Viagem);
            
            builder
                .HasMany(despDesl => despDesl.DespesaDeslocamento)
                .WithOne(v => v.Viagem);            

            builder
                .HasMany(despPass => despPass.DespesaPassagem)
                .WithOne(v => v.Viagem);

            builder
                .HasMany(despRef => despRef.DespesaRefeicao)
                .WithOne(v => v.Viagem);
            */
            /*
            builder
                .HasOne(agend => agend.Agendamento)
                .WithOne(v => v.Viagem);

            builder
                .HasOne(func => func.Funcionario)
                .WithOne(v => v.Viagem);
            */
        }
    }
}
