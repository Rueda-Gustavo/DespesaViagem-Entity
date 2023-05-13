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

        public async Task<Result<Viagem>> ObterViagemPorId(string id)
        {
            _ = int.TryParse(id, out int idViagem);

            if (idViagem > 0)
            {
                Viagem viagem = await _viagemRepository.ObterPorIdAsync(idViagem);

                return Result.FailureIf(viagem is null, viagem, "Não existem viagens com o filtro especificado!");
            }

            return Result.Failure<Viagem>("Especifique um id válido!!");
        }

        public async Task<Result<IEnumerable<Viagem>>> ObterViagemPorFiltro(string filtro)
        {
            IEnumerable<Viagem> viagens = await _viagemRepository.ObterAsync(filtro);
            return Result.FailureIf(viagens is null, viagens, "Não existem viagens com o filtro especificado!");
        }

        public async Task<Result<IEnumerable<Despesa>>> ObterTodasDespesas(int id)
        {
            return Result.Success(await _viagemRepository.ObterTodasDepesasAsync(id));
        }

        public async Task<Result<Viagem>> ObterViagemEmAndamento()
        {
            Viagem viagem = await _viagemRepository.ObterViagemAbertaOuEmAndamentoAsync();
            
            if (viagem is not null && viagem.StatusViagem == Status.EmAndamento)
                return viagem;

            return Result.Failure<Viagem>("Não existe uma viagem em andamento.");
        }
        public async Task<Result<Viagem>> ObterViagemAberta()
        {
            Viagem viagem = await _viagemRepository.ObterViagemAbertaOuEmAndamentoAsync();            

            if (viagem is not null && viagem.StatusViagem == Status.Aberta )
                return viagem;

            return Result.Failure<Viagem>("Não existe uma viagem aberta.");
        }

        public async Task<Result<Viagem>> AdicionarViagem(Viagem viagem)
        {
            if (await ViagemEmAndamento() || await ViagemAberta())
                return Result.Failure<Viagem>("Já existe uma viagem aberta ou em andamento.");

            if(viagem.DataFinal < viagem.DataInicial)
                return Result.Failure<Viagem>("Insira uma período válido, com pelo menos 1 dia de diferença entre as datas inicial e final. Por exemplo: Data inicial dia 01 e data final dia 02");

            await _viagemRepository.InsertAsync(viagem);
            return Result.Success(viagem);
        }

        public async Task<Result<Viagem>> AlterarViagem(Viagem viagem)
        {
            if (!await ViagemAberta())
                return Result.Failure<Viagem>("Nenhuma viagem em aberto.");

            if ((await _viagemRepository.ObterPorIdAsync(viagem.Id)).StatusViagem == Status.EmAndamento)
                return Result.Failure<Viagem>("A viagem já está em andamento, não é possível alterar os dados.");

            await _viagemRepository.UpdateAsync(viagem);
            return Result.Success(viagem);
        }

        public async Task<Result<Viagem>> RemoverViagem(int id)
        {
            Viagem viagem = await _viagemRepository.ObterPorIdAsync(id);

            if (viagem is null)
                return Result.Failure<Viagem>("Viagem não existe!");
            await _viagemRepository.DeleteAsync(viagem);
            return Result.Success(viagem);
        }

        public async Task<Result<decimal>> ObterPrestacaoDeContas(Viagem viagem)
        {
            return Result.Success(viagem.GerarPrestacaoDeContas());
        }

        public async Task<Result<Viagem>> IniciarViagem(Viagem viagem)
        {
            if (await ViagemEmAndamento())
            {
                return Result.Failure<Viagem>("Já existe uma viagem aberta ou em andamento.");
            }
            viagem.IniciarViagem();
            await _viagemRepository.UpdateAsync(viagem);
            return Result.Success(viagem);
        }

        public async Task<Result<Viagem>> EncerrarViagem(Viagem viagem)
        {
            if (!await ViagemEmAndamento())
            {
                return Result.Failure<Viagem>("A viagem deve estar em andamento para ser encerrada.");
            }
            viagem.EncerrarViagem();
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
        private async Task<bool> ViagemEmAndamento()
        {
            Viagem viagem = await _viagemRepository.ObterViagemAbertaOuEmAndamentoAsync();
            if (viagem is null)
                return false;

            if (viagem.StatusViagem == Status.EmAndamento)
            {
                return true;
            }

            return false;
        }

        private async Task<bool> ViagemAberta()
        {
            Viagem viagem = await _viagemRepository.ObterViagemAbertaOuEmAndamentoAsync();
            if (viagem is null)
                return false;

            if (viagem.StatusViagem == Status.Aberta)
            {
                return true;
            }

            return false;
        }

        private async Task<bool> ViagemCancelada(int idViagem)
        {
            Viagem viagem = await _viagemRepository.ObterPorIdAsync(idViagem);
            //foreach (var viagem in viagens)
            //{
            if (viagem.StatusViagem == Status.Cancelada)
            {
                return true;
            }
            //}
            return false;
        }
    }
}
