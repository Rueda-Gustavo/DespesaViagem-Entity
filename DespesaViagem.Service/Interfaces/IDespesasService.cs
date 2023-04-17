using CSharpFunctionalExtensions;

namespace DespesaViagem.Service.Interfaces
{
    public interface IDespesasService<T, TKey> where T : class
    {
        Task<Result<IEnumerable<T>>> ObterTodasDespesas(int idViagem);
        Task<Result<T>> ObterDespesaPorId(TKey id);
        Task<Result<T>> AdicionarDespesa(T despesa, int idViagem);
        Task<Result<T>> AlterarDespesa(T despesa);
        Task<Result<T>> RemoverViagem(TKey id);
    }
}
