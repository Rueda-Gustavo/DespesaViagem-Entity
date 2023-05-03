using CSharpFunctionalExtensions;
using DespesaViagem.Domain.Models.Core.Records;
using DespesaViagem.Infra.Interfaces;
using DespesaViagem.Service.Interfaces;

namespace DespesaViagem.Service.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<Result<IEnumerable<Endereco>>> ObterTodosEnderecos()
        {
            IEnumerable<Endereco> enderecos = await _enderecoRepository.ObterTodosAsync();
            return Result.FailureIf(enderecos is null, enderecos, "Não foram encontrados endereços.");
        }
        public async Task<Result<Endereco>> ObterEnderecoPorId(string id)
        {
            _ = int.TryParse(id, out int idEndereco);

            if (idEndereco > 0)
            {
                Endereco endereco = await _enderecoRepository.ObterPorIdAsync(idEndereco);
                return Result.FailureIf(endereco is null, endereco, "Endereço não encontrado.");
            }

            return Result.Failure<Endereco>("Especifique um id válido!!");
        }        

        public async Task<Result<IEnumerable<Endereco>>> ObterEnderecoPorFiltro(string filtro)
        {
            IEnumerable<Endereco> enderecos = (await _enderecoRepository.ObterAsync(filtro));
            return Result.FailureIf(enderecos is null, enderecos, "Esses endereços não foram encontrados!");
        }

        public async Task<Result<Endereco>> ObterEnderecoPorFiltro(Endereco endereco)
        {
            IEnumerable<Endereco> enderecos = await _enderecoRepository.ObterAsync(endereco.Logradouro);

            var a = enderecos.Select(enderecoTemp =>
            (enderecoTemp.CEP == endereco.CEP) &&
            (enderecoTemp.NumeroCasa == endereco.NumeroCasa) &&
            (enderecoTemp.Cidade == endereco.Cidade) &&
            (enderecoTemp.Estado == endereco.Estado));


            return Result.FailureIf(enderecos is null, enderecos.First(), "Esses endereços não foram encontrados!");
        }

        public async Task<Result<Endereco>> AdicionarEndereco(Endereco endereco)
        {
            if (await EnderecoJaExiste(endereco))
                return Result.Failure<Endereco>("Endereço já cadastrado.");
            
            await _enderecoRepository.InsertAsync(endereco);
            return Result.Success(endereco);
        }
        public async Task<Result<Endereco>> AlterarEndereco(Endereco endereco)
        {
            if (!await EnderecoJaExiste(endereco))
                return Result.Failure<Endereco>("Endereço não encontrado!");

            await _enderecoRepository.UpdateAsync(endereco);
            return Result.Success(endereco);
        }

        public async Task<Result<Endereco>> RemoverEndereco(int id)
        {
            Endereco endereco = await _enderecoRepository.ObterPorIdAsync(id);
            if (endereco is null)
                return Result.Failure<Endereco>("Endereço não encontrado!");

            await _enderecoRepository.DeleteAsync(endereco);
            return Result.Success(endereco);
        }

        private async Task<bool> EnderecoJaExiste(Endereco endereco)
        {
            if (await _enderecoRepository.ObterPorIdAsync(endereco.Id) is not null)
            {
                return true;
            }

            IEnumerable<Endereco> enderecos = (await ObterEnderecoPorFiltro(endereco.Logradouro)).Value.ToList();

            return enderecos.Any(enderecoTemp =>
            (enderecoTemp.CEP == endereco.CEP) &&
            (enderecoTemp.NumeroCasa == endereco.NumeroCasa) &&
            (enderecoTemp.Cidade == endereco.Cidade) &&
            (enderecoTemp.Estado == endereco.Estado));            
        }        
    }
}
