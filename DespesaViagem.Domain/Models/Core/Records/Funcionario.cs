using DespesaViagem.Domain.Models.Viagens;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DespesaViagem.Domain.Models.Core.Records
{
    public record Funcionario
    {
        [ForeignKey("Viagem")]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }        
        public required string CPF { get; set; }
        public required string Matricula { get; set; }
        [JsonIgnore]
        public ICollection<Viagem> Viagens { get; set; } = new Collection<Viagem>();
    }
}
