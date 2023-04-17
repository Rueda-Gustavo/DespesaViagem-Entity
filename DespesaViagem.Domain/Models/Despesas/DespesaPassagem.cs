/*
using DespesaViagem.Domain.Models.Core.Records;

namespace DespesaViagem.Domain.Models.Despesas
{    
    public class DespesaPassagem : Despesa
    {        
        public string Companhia { get; private set; }
        public string Origem { get; private set; }
        public string Destino { get; private set; }
        public DateTime DataHoraEmbarque { get; private set; }
        public decimal Preco { get; private set; }

        public DespesaPassagem(int id, string descricaoDespesa, string companhia, string origem, string destino, 
            DateTime dataHoraEmbarque, decimal preco) : base(id, "Despesa com passagem", descricaoDespesa, preco)
        {
            Companhia = companhia;
            Origem = origem;
            Destino = destino;
            DataHoraEmbarque = dataHoraEmbarque;
            Preco = preco;
        }

        public DespesaPassagem() { }
    }
}
*/