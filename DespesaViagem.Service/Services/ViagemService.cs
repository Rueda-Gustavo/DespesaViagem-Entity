using CSharpFunctionalExtensions;
using DespesaViagem.Domain.Models.Core.Enums;
using DespesaViagem.Domain.Models.Despesas;
using DespesaViagem.Domain.Models.Viagens;
using DespesaViagem.Infra.Interfaces;
using DespesaViagem.Service.Interfaces;

namespace DespesaViagem.Service.Services
{
    public class ViagemService : IViagemService
    {
        private readonly IViagemRepository _viagemRepository;

        public ViagemService(IViagemRepository viagemRepository)
        {
            _viagemRepository = viagemRepository;
        }

        public async Task<Result<IEnumerable<Viagem>>> ObterTodasViagens()
        {
            return Result.Success(await _viagemRepository.ObterTodosAsync());
        }
        /*
        public Task<Result<Viagem>> ObterViagemPorId(string id)
        {
            
        }
        */

        public async Task<Result<IEnumerable<Viagem>>> ObterViagemPorFiltro(string filtro)
        {
            _ = int.TryParse(filtro, out int id);

            if(id != 0)
            {
                IEnumerable<Viagem> viagem = (IEnumerable<Viagem>)await _viagemRepository.ObterPorIdAsync(id);
                return Result.FailureIf(viagem is null, viagem, "Não existem viagens com o filtro especificado!");
            }

            IEnumerable<Viagem> viagens = await _viagemRepository.ObterAsync(filtro);
            return Result.FailureIf(viagens is null, viagens, "Não existem viagens com o filtro especificado!");            
        }

        public async Task<Result<IEnumerable<Despesa>>> ObterTodasDespesas(int id)
        {
            return Result.Success(await _viagemRepository.ObterTodasDepesasAsync(id));
        }

        /*
        public Task<Result<IEnumerable<DespesaHospedagem>>> ObterDespesasPorNome(string nomeDespesa)
        {
            throw new NotImplementedException();
        }
        */

        public async Task<Result<Viagem>> AdicionarViagem(Viagem viagem)
        {
            if (await ViagemEmAndamento(viagem.Id))
                return Result.Failure<Viagem>("Já existe uma viagem aberta ou em andamento.");
            await _viagemRepository.InsertAsync(viagem);
            return Result.Success(viagem);
        }

        public async Task<Result<Viagem>> AlterarViagem(Viagem viagem)
        {
            if (!await ViagemEmAndamento(viagem.Id))
                return Result.Failure<Viagem>("Nenhuma viagem em aberto.");

            if((await _viagemRepository.ObterPorIdAsync(viagem.Id)).StatusViagem == Status.EmAndamento)
                return Result.Failure<Viagem>("A viagem já está em andamento, não é possível alterar os dados.");

            await _viagemRepository.UpdateAsync(viagem);
            return Result.Success(viagem);

        }

        public async Task<Result<Viagem>> RemoverViagem(int id)
        {
            Viagem viagem = await _viagemRepository.ObterPorIdAsync(id);

            if (viagem is null)
                return Result.Failure<Viagem>("Viagem não existe!");
            await _viagemRepository.DeleteAsync(id);
            return Result.Success(viagem);

        }       

        public async Task<Result<decimal>> ObterPrestacaoDeContas(Viagem viagem)
        {
            return Result.Success(viagem.GerarPrestacaoDeContas());
        }

        public async Task<Result<Viagem>> IniciarViagem(Viagem viagem)
        {
            if (await ViagemEmAndamento(viagem.Id))
            {
                return Result.Failure<Viagem>("Já existe uma viagem aberta ou em andamento.");
            }
            viagem.IniciarViagem();
            await _viagemRepository.UpdateAsync(viagem);
            return Result.Success(viagem); 
        }

        public async Task<Result<Viagem>> CancelarViagem(Viagem viagem)
        {
            if (await ViagemCancelada(viagem.Id))
            {
                return Result.Failure<Viagem>("Viagem já foi cancelada.");
            }
            viagem.CancelarViagem();
            await _viagemRepository.UpdateAsync(viagem);
            return Result.Success(viagem);
        }

        //Verifica se já existe alguma viagem em andamento, caso não existe pode prosseguir com a criação.
        private async Task<bool> ViagemEmAndamento(int viagemId)
        {
            IEnumerable<Viagem> viagens = await _viagemRepository.ObterTodosAsync();
            foreach (var viagem in viagens)
            {
                if (viagem.StatusViagem == Status.EmAndamento || viagem.StatusViagem == Status.Aberta)
                {
                    return true;
                }
            }
            return false;
        }

        private async Task<bool> ViagemCancelada(int viagemId)
        {
            IEnumerable<Viagem> viagens = await _viagemRepository.ObterTodosAsync();
            foreach (var viagem in viagens)
            {
                if (viagem.StatusViagem == Status.Cancelada)
                {
                    return true;
                }
            }
            return false;
        }        
    }
}
