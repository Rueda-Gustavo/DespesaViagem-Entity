/*
using DespesaViagem.Domain.Models.Core.Records;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespesaViagem.Infra.EntityConfiguration.RecordsTypeConfiguration
{
    public class FuncionarioEntityTypeConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable($"{nameof(Funcionario)}");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Nome)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.Matricula)
                   .HasMaxLength(30)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder
                .HasOne(v => v.Viagem)
                .WithOne(func => func.Funcionario);
        }
    }
}
*/