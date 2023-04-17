using DespesaViagem.Domain.Models.Despesas;
using DespesaViagem.Domain.Models.Viagens;

namespace DespesaViagem.Infra.Interfaces
{
    public interface IViagemRepository
    {
        Task<IEnumerable<Viagem>> ObterTodosAsync();
        Task<Viagem> ObterPorIdAsync(int id);
        Task<IEnumerable<Viagem>> ObterAsync(string filtro);
        //Diferente do método para obter todas as despesas da interface de IDespesasRepository, esse método irá retornar
        //todas as despesas referentes a viagem em questão, independente de qual tipo ela seja, Hospedagem, Passagem etc.
        Task<IEnumerable<Despesa>> ObterTodasDepesasAsync(int viagemId);
        Task InsertAsync(Viagem viagem);
        Task UpdateAsync(Viagem viagem);
        Task DeleteAsync(int id);
    }
}
