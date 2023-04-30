using CSharpFunctionalExtensions;
using DespesaViagem.Domain.Models.Viagens;

namespace DespesaViagem.Service.Interfaces
{
    public interface IDespesasService<T, TKey> where T : class
    {
        Task<Result<IEnumerable<T>>> ObterTodasDespesas(int idViagem);
        Task<Result<IEnumerable<T>>> ObterDespesasPorFiltro(string filtro, int idViagem);
        Task<Result<T>> ObterDespesaPorId(string id);
        Task<Result<T>> AdicionarDespesa(T despesa, Viagem viagem);
        Task<Result<T>> AlterarDespesa(T despesa);
        Task<Result<T>> RemoverViagem(TKey id);
    }
}
