using DespesaViagem.Domain.Models.Viagens;
using System.ComponentModel.DataAnnotations.Schema;

namespace DespesaViagem.Domain.Models.Core.Records
{
    public record Agendamento
    {
        [ForeignKey("Viagem")]
        public int Id { get; set; }
        public required DateTime DataInicial { get; set; }
        public required DateTime DataFinal { get; set; }
        public Viagem Viagem { get; set; }
    }
}
