using CSharpFunctionalExtensions;
using DespesaViagem.Domain.Models.Despesas;

namespace DespesaViagem.Service.Interfaces
{
    public interface IDespesaService
    {
        Task<Result<IEnumerable<Despesa>>> ObterTodasDespesas(int idViagem);
        Task<Result<IEnumerable<Despesa>>> ObterDespesasPorFiltro(string filtro, int idViagem);
        Task<Result<Despesa>> ObterDespesaPorId(string id);
    }
}
