using DespesaViagem.Domain.Models.Core.Records;
using DespesaViagem.Domain.Models.Viagens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespesaViagem.Infra.EntityConfiguration.RecordsTypeConfiguration
{
    public class EnderecoEntityTypeConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable($"Enderecos");
            builder.HasKey(k => k.Id);
           
            builder.Property(p => p.Logradouro)
                   .HasMaxLength(150)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.NumeroCasa)
                   .HasColumnType("integer")                   
                   .IsRequired(true);

            builder.Property(p => p.CEP)
                   .HasMaxLength(10)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.Cidade)
                   .HasMaxLength(30)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.Estado)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .IsRequired(true);


            /*
            builder
                .HasOne(despHosp => despHosp.DespesaHospedagem)
                .WithOne(end => end.Endereco);
            */
        }
    }
}
