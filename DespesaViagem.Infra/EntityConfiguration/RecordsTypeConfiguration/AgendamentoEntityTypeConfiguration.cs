/*
using DespesaViagem.Domain.Models.Core.Records;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespesaViagem.Infra.EntityConfiguration.RecordsTypeConfiguration
{
    public class AgendamentoEntityTypeConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable($"{nameof(Agendamento)}");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.DataInicial)
                  .HasColumnType("datetime")
                  .IsRequired(true);

            builder.Property(p => p.DataFinal)
                   .HasColumnType("datetime")
                   .IsRequired(true);

            builder
                .HasOne(v => v.Viagem)
                .WithOne(agend => agend.Agendamento);
        }
    }
}
*/