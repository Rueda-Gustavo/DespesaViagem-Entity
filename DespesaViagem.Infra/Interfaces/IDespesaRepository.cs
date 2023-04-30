using DespesaViagem.Domain.Models.Despesas;

namespace DespesaViagem.Infra.Interfaces
{
    public interface IDespesaRepository
    {
        Task<IEnumerable<Despesa>> ObterTodosAsync(int idViagem);
        Task<Despesa> ObterPorIdAsync(int id);
        Task<IEnumerable<Despesa>> ObterAsync(string filtro, int idViagem);
    }
}
