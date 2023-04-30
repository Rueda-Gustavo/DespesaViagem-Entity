using DespesaViagem.Domain.Models.Core.Records;
using System.ComponentModel.DataAnnotations.Schema;

namespace DespesaViagem.Domain.DTOs.Despesas
{
    public class DespesaHospedagemDTO
    {
        public int Id { get; set; }                      
        public required string NomeDespesa { get; set; }        
        public required string DescricaoDespesa { get; set; }        
        public decimal TotalDespesa { get; set; }
        public DateTime DataDespesa { get; set; }
        public required string TipoDespesa { get; set; }
        public required string Logradouro { get; set; }
        public int NumeroCasa { get; set; }
        public required string CEP { get; set; }
        public required string Cidade { get; set; }
        public required string Estado { get; set; }
        public int QuantidadeDias { get; set; }
        public decimal ValorDiaria { get; set; }
    }
}
