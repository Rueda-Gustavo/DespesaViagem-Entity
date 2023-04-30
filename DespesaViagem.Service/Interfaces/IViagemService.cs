using CSharpFunctionalExtensions;
using DespesaViagem.Domain.Models.Despesas;
using DespesaViagem.Domain.Models.Viagens;

namespace DespesaViagem.Service.Interfaces
{
    public interface IViagemService
    {
        Task<Result<IEnumerable<Viagem>>> ObterTodasViagens();
        Task<Result<Viagem>> ObterViagemPorId(string id);
        Task<Result<IEnumerable<Viagem>>> ObterViagemPorFiltro(string filtro);        
        Task<Result<IEnumerable<Despesa>>> ObterTodasDespesas(int id);
        Task<Result<Viagem>> AdicionarViagem(Viagem viagem);
        Task<Result<Viagem>> AlterarViagem(Viagem viagem);
        Task<Result<Viagem>> RemoverViagem(int id);
        Task<Result<decimal>> ObterPrestacaoDeContas(Viagem viagem);
        Task<Result<Viagem>> IniciarViagem(Viagem viagem);
        Task<Result<Viagem>> CancelarViagem(Viagem viagem);
    }
}
