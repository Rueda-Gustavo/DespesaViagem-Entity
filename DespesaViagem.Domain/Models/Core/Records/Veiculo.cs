using DespesaViagem.Domain.Models.Despesas;
using System.ComponentModel.DataAnnotations.Schema;

namespace DespesaViagem.Domain.Models.Core.Records
{
    public record Veiculo
    {
        [ForeignKey("DespesaDeslocamento")]
        public int Id { get; set; }
        public required string Placa { get; set; }
        public required string Modelo { get; set; }
        //public DespesaDeslocamento? DespesaDeslocamento { get; set; }
    }
}
