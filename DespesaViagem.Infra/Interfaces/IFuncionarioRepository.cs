using DespesaViagem.Domain.Models.Core.Records;

namespace DespesaViagem.Infra.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> ObterTodosAsync();
        Task<Funcionario> ObterPorIdAsync(int id);
        Task<Funcionario> ObterPorCPFAsync(string CPF);
        Task<IEnumerable<Funcionario>> ObterAsync(string filtro);
        Task InsertAsync(Funcionario funcionario);
        Task UpdateAsync(Funcionario funcionario);
        Task DeleteAsync(Funcionario funcionario);
    }
}
