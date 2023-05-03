using DespesaViagem.Domain.Models.Core.Records;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DespesaViagem.Infra.EntityConfiguration.RecordsTypeConfiguration
{
    public class FuncionarioEntityTypeConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable($"{nameof(Funcionario)}s");
            builder.HasKey(k => k.Id);
            
            builder.Property(p => p.Nome)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.Sobrenome)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .IsRequired(true);

            builder.Property(p => p.CPF)                   
                   .HasMaxLength(15)
                   .IsUnicode(false)
                   .IsRequired(true);                        
            
            builder.Property(p => p.Matricula)
                   .HasMaxLength(30)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.HasIndex(f => f.CPF).IsUnique(true);
            builder.HasIndex(f => f.Matricula).IsUnique(true);
        }
    }
}