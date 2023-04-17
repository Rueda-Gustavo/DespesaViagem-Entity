using DespesaViagem.Domain.Models.Despesas;
using System.ComponentModel.DataAnnotations.Schema;

namespace DespesaViagem.Domain.Models.Core.Records
{
    public record Estabelecimento
    {
        [ForeignKey("DespesaRefeicao")]
        public int Id { get; set; }
        public required string NomeEstabelecimento { get; set; }
        public required string CNPJ { get; set; }
        //public DespesaRefeicao? DespesaRefeicao { get; set; }
    }
}
