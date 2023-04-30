using DespesaViagem.Domain.Models.Viagens;
using System.ComponentModel.DataAnnotations.Schema;

namespace DespesaViagem.Domain.Models.Despesas
{

    public abstract class Despesa
    {
        [ForeignKey("Viagem")]
        public int Id { get; protected set; }
        [Column(TypeName = "varchar(30)")]
        public virtual string NomeDespesa { get; protected set; }
        [Column(TypeName = "varchar(200)")]
        public virtual string DescricaoDespesa { get; protected set; }
        [Column(TypeName = "decimal(10,2)")]
        public virtual decimal TotalDespesa { get; protected set; }
        public virtual DateTime DataDespesa { get; protected set; }
        public string TipoDespesa { get; protected set; }
        public int IdViagem { get; protected set; }
        public Viagem Viagem { get; set; }

        public Despesa(int id, string nomeDespesa, string descricaoDespesa, decimal totalDespesa, string tipoDespesa, int idViagem)
        {            
            Id = id;
            NomeDespesa = nomeDespesa;
            DescricaoDespesa = descricaoDespesa;
            TotalDespesa = totalDespesa;
            DataDespesa = DateTime.UtcNow;
            TipoDespesa = tipoDespesa;
        }

        public Despesa() { }
        //Abstract class - https://sourcemaking.com/refactoring/replace-conditional-with-polymorphism       
    }
}
