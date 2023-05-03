using CSharpFunctionalExtensions;
using DespesaViagem.Domain.Models.Core.Records;

namespace DespesaViagem.Service.Interfaces
{
    public interface IEnderecoService
    {
        Task<Result<IEnumerable<Endereco>>> ObterTodosEnderecos();
        Task<Result<Endereco>> ObterEnderecoPorId(string id);
        Task<Result<IEnumerable<Endereco>>> ObterEnderecoPorFiltro(string filtro);
        Task<Result<Endereco>> ObterEnderecoPorFiltro(Endereco endereco);
        Task<Result<Endereco>> AdicionarEndereco(Endereco endereco);
        Task<Result<Endereco>> AlterarEndereco(Endereco endereco);
        Task<Result<Endereco>> RemoverEndereco(int id);
    }
}