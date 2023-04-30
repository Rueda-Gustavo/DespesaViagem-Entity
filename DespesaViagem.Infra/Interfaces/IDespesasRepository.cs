using DespesaViagem.Domain.Models.Viagens;

namespace DespesaViagem.Infra.Interfaces
{
    public interface IDespesasRepository<T, TKey> where T : class
    {
        //Os métodos get irão retornar todas as despesas relacionadas apenas ao seu tipo T definido no corpo do método
        //Por exemplo: DespesaHospedagemRepository, irá retornar todas as depesas do tipo Hospedagem relacionadas a viagem especificada
        Task<IEnumerable<T>> ObterTodosAsync(int idViagem);
        Task<T> ObterPorIdAsync(TKey id);
        Task<IEnumerable<T>> ObterAsync(string filtro, int idViagem);
        Task InsertAsync(T despesa, Viagem viagem);
        Task UpdateAsync(T despesa);
        Task DeleteAsync(T despesa);
    }
}
