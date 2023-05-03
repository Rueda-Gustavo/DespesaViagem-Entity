using CSharpFunctionalExtensions;
using DespesaViagem.Domain.Models.Core.Records;
using DespesaViagem.Infra.Interfaces;
using DespesaViagem.Service.Interfaces;

namespace DespesaViagem.Service.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<Result<IEnumerable<Funcionario>>> ObterTodosFuncionarios()
        {
            IEnumerable<Funcionario> funcionarios = await _funcionarioRepository.ObterTodosAsync();
            return Result.FailureIf(funcionarios is null, funcionarios, "Não foram encontrados funcionários.");
        }

        public async Task<Result<Funcionario>> ObterFuncionarioPorId(string id)
        {
            _ = int.TryParse(id, out int idFuncionario);

            if(idFuncionario > 0)
            {
                Funcionario funcionario = await _funcionarioRepository.ObterPorIdAsync(idFuncionario);
                return Result.FailureIf(funcionario is null, funcionario, "Funcionário não encontrado.");
            }

            return Result.Failure<Funcionario>("Especifique um id válido!!");            
        }

        public async Task<Result<Funcionario>> ObterFuncionarioPorCPF(string CPF)
        {
            Funcionario funcionario = await _funcionarioRepository.ObterPorCPFAsync(CPF);
            return Result.FailureIf(funcionario is null, funcionario, "Funcionário não encontrado. Por favor faça o cadastro dos mesmos.");
        }

        public async Task<Result<IEnumerable<Funcionario>>> ObterFuncionarioPorFiltro(string filtro)
        {
            IEnumerable<Funcionario> funcionarios = await _funcionarioRepository.ObterAsync(filtro);
            return Result.FailureIf(funcionarios.Count() == 0, funcionarios, "Esses funcionarios não foram encontrados, por favor faça o cadastro dos mesmos!");
        }

        public async Task<Result<Funcionario>> AdicionarFuncionario(Funcionario funcionario)
        {
            if (await FuncionarioJaExiste(funcionario))
                return Result.Failure<Funcionario>("Funcionário já cadastrado.");
            
            await _funcionarioRepository.InsertAsync(funcionario);
            return Result.Success(funcionario);
        }

        public async Task<Result<Funcionario>> AlterarFuncionario(Funcionario funcionario)
        {
            if (!await FuncionarioJaExiste(funcionario))
                return Result.Failure<Funcionario>("Funcionario não encontrado!");

            await _funcionarioRepository.UpdateAsync(funcionario);
            return Result.Success(funcionario);
        }              

        public async Task<Result<Funcionario>> RemoverFuncionario(int id)
        {
            Funcionario funcionario = await _funcionarioRepository.ObterPorIdAsync(id);
            if (funcionario is null)
                return Result.Failure<Funcionario>("Funcionario não encontrado!");

            await _funcionarioRepository.DeleteAsync(funcionario);
            return Result.Success(funcionario);
        }

        private async Task<bool> FuncionarioJaExiste(Funcionario funcionario)
        {
            if(await _funcionarioRepository.ObterAsync(funcionario.CPF) is not null)
            {
                return true;
            }
            return false;
        }
    }
}
