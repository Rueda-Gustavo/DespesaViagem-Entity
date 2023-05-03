using DespesaViagem.Domain.Models.Core.Records;

namespace DespesaViagem.Infra.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> ObterTodosAsync();
        Task<Endereco> ObterPorIdAsync(int id);
        Task<IEnumerable<Endereco>> ObterAsync(string filtro);        
        Task InsertAsync(Endereco endereco);
        Task UpdateAsync(Endereco endereco);
        Task DeleteAsync(Endereco endereco);
    }
}
