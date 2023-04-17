using DespesaViagem.Domain.Models.Viagens;
using System.ComponentModel.DataAnnotations.Schema;

namespace DespesaViagem.Domain.Models.Core.Records
{
    public record Funcionario
    {
        [ForeignKey("Viagem")]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Matricula { get; set; }
        public Viagem Viagem { get; set; }
    }
}
