using DespesaViagem.Domain.Models.Despesas;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DespesaViagem.Domain.Models.Core.Records
{
    public record Endereco
    {
        [ForeignKey("DespesaHospedagem")]
        public int Id { get; set; }
        public required string Logradouro { get; set; }
        public required int NumeroCasa { get; set; }
        public required string CEP { get; set; }
        public required string Cidade { get; set; }
        public required string Estado { get; set; }
        [JsonIgnore]
        public ICollection<DespesaHospedagem> DespesasHospedagem { get; set; } = new Collection<DespesaHospedagem>();
    }
}
