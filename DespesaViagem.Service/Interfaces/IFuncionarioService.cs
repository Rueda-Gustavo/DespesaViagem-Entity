using CSharpFunctionalExtensions;
using DespesaViagem.Domain.Models.Core.Records;

namespace DespesaViagem.Service.Interfaces
{
    public interface IFuncionarioService
    {
        Task<Result<IEnumerable<Funcionario>>> ObterTodosFuncionarios();
        Task<Result<Funcionario>> ObterFuncionarioPorId(string id);
        Task<Result<Funcionario>> ObterFuncionarioPorCPF(string CPF);
        Task<Result<IEnumerable<Funcionario>>> ObterFuncionarioPorFiltro(string filtro);
        Task<Result<Funcionario>> AdicionarFuncionario(Funcionario funcionario);
        Task<Result<Funcionario>> AlterarFuncionario(Funcionario funcionario);
        Task<Result<Funcionario>> RemoverFuncionario(int id);
    }
}
