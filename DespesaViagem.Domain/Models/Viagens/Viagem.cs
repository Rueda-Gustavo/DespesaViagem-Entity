using DespesaViagem.Domain.Models.Core.Enums;
using DespesaViagem.Domain.Models.Core.Records;
using DespesaViagem.Domain.Models.Despesas;
using System.ComponentModel.DataAnnotations.Schema;

namespace DespesaViagem.Domain.Models.Viagens
{
    public class Viagem
    {                
        public int Id { get; }
        public string NomeViagem { get; set; }
        public string DescricaoViagem { get; set; }
        public decimal Adiantamento { get; }
        //public Agendamento Agendamento { get; private set; }
        public DateTime DataInicial { get; private set; }
        public DateTime DataFinal { get; private set; }
        public decimal TotalDespesas { get; private set; }
        public Status StatusViagem { get; private set; }
        public IReadOnlyCollection<Despesa> Despesas
        {
            get { return _despesas.AsReadOnly(); }
        }
        public Funcionario Funcionario { get; private set; }
        public int IdFuncionario { get; private set; }
        //public string NomeFuncionario { get; private set; }
        //public string MatriculaFuncionario { get; private set; }
        //public List<DespesaDeslocamento> DespesaDeslocamento { get; set; }
        //public List<DespesaHospedagem> DespesaHospedagem { get; set; }
        //public List<DespesaPassagem> DespesaPassagem { get; set; }
        //public List<DespesaRefeicao> DespesaRefeicao { get; set; }

        private List<Despesa> _despesas = new List<Despesa>(); 

        public Viagem(/*int id,*/string nomeViagem, string descricaoViagem, decimal adiantamento, DateTime dataInicial, DateTime dataFinal, Funcionario funcionario)
        {
            //Id = id;
            NomeViagem = nomeViagem;
            DescricaoViagem = descricaoViagem;
            Adiantamento = adiantamento;
            DataFinal = dataFinal;
            Adiantamento = adiantamento;
            //Agendamento = agendamento;
            TotalDespesas = 0;
            StatusViagem = Status.Aberta;
            Funcionario = funcionario;
        }

        public Viagem() { }

        public Viagem(string nomeViagem, string descricaoViagem, decimal adiantamento, DateTime dataInicial, DateTime dataFinal, string nomeFuncionario, string matriculaFuncionario)
        {
            NomeViagem = nomeViagem;
            DescricaoViagem = descricaoViagem;
            StatusViagem = Status.Aberta;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
            Adiantamento = adiantamento;
            TotalDespesas = 0;
            //NomeFuncionario = nomeFuncionario;
            //MatriculaFuncionario = matriculaFuncionario;
        }

        public void AdicionarDespesa(Despesa despesa)
        {
            if (despesa.TotalDespesa > 0 && StatusViagem == Status.EmAndamento)
                TotalDespesas += despesa.TotalDespesa;
            _despesas.Add(despesa);
        }

        public void AdicionarDespesas(IEnumerable<Despesa> despesas)
        {
            if (StatusViagem == Status.EmAndamento)
            {
                foreach(var despesa in despesas)
                {
                    if (despesa.TotalDespesa > 0)
                    {
                        TotalDespesas += despesa.TotalDespesa;
                        _despesas.Add(despesa);
                    }
                }                
            }
        }

        public void RemoverDespesa(int id)
        {
            if (id > 0)
            {
                Despesa? despesa = BuscarDespesa(id);
                if (despesa != null)
                {
                    TotalDespesas -= despesa.TotalDespesa;
                    _despesas.Remove(despesa);
                    return;
                }
                throw new ArgumentException("A despesa não foi encontrada.");                
            }
            throw new ArgumentException("Por favor, informe um id válido.");            
        }

        public decimal GerarPrestacaoDeContas()
        {
            StatusViagem = Status.Encerrada;
            return TotalDespesas - Adiantamento;
        }

        public void IniciarViagem()
        {
            if (StatusViagem == Status.Encerrada || StatusViagem == Status.EmAndamento || StatusViagem == Status.Cancelada)
                throw new Exception("Viagem já foi fechada ou já está em andamento!");
            StatusViagem = Status.EmAndamento;
        }

        public void CancelarViagem()
        {
            StatusViagem = Status.Cancelada;
        }

        public void EncerrarViagem()
        {
            if(StatusViagem != Status.EmAndamento)
                throw new Exception("Viagem a viagem deve estar em andamento para ser encerrada!");
            StatusViagem = Status.Encerrada;


        }

        private Despesa? BuscarDespesa(int id)
        {
            foreach(var item in _despesas)
            {
                if(item.Id == id)
                    return item;
            }
            return default;
        }
    }
}