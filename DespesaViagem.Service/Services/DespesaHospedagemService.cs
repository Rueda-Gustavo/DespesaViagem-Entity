using CSharpFunctionalExtensions;
using DespesaViagem.Domain.Models.Core.Records;
using DespesaViagem.Domain.Models.Despesas;
using DespesaViagem.Domain.Models.Viagens;
using DespesaViagem.Infra.Interfaces;
using DespesaViagem.Service.Interfaces;

namespace DespesaViagem.Service.Services
{
    public class DespesaHospedagemService : IDespesasService<DespesaHospedagem, int>
    {
        private readonly IViagemService _viagemService;
        private readonly IDespesasRepository<DespesaHospedagem, int> _despesaRepository;
        public DespesaHospedagemService(IDespesasRepository<DespesaHospedagem, int> despesaRepository, IViagemService viagemService)
        {
            _viagemService = viagemService;
            _despesaRepository = despesaRepository;
        }
        
        public async Task<Result<IEnumerable<DespesaHospedagem>>> ObterTodasDespesas(int idViagem)
        {            
            Task<Result<Viagem>> viagem = _viagemService.ObterViagemPorId(idViagem.ToString());
            viagem.Wait();
            idViagem = viagem.Result.Value.Id;
            IEnumerable<DespesaHospedagem> despesa = await _despesaRepository.ObterTodosAsync(idViagem);
            return Result.FailureIf(despesa is null, despesa, "Não existem despesas para a viagem informada!!");
        }        

        public async Task<Result<DespesaHospedagem>> ObterDespesaPorId(string id)
        {
            _ = int.TryParse(id, out int idDespesa);

            if (idDespesa > 0)
            {
                DespesaHospedagem despesa = await _despesaRepository.ObterPorIdAsync(idDespesa);
                return Result.FailureIf(despesa is null, despesa, "Essa despesa não foi encontrada ou não existe!");
            }

            return Result.Failure<DespesaHospedagem>("Especifique um id válido!!");
        }

        public async Task<Result<IEnumerable<DespesaHospedagem>>> ObterDespesasPorFiltro(string filtro, string idViagem)
        {
            _ = int.TryParse(idViagem, out int id);

            if (id > 0)
            {
                IEnumerable<DespesaHospedagem> despesas = await _despesaRepository.ObterAsync(filtro, id);
                return Result.FailureIf(despesas is null, despesas, "Essas despesas não foram encontradas ou não existem!");
            }

            return Result.Failure<IEnumerable<DespesaHospedagem>>("Especifique um id válido para a viagem.");
        }

        public async Task<Result<DespesaHospedagem>> AdicionarDespesa(DespesaHospedagem despesa, Viagem viagem)
        {
            if (await DespesaJaExiste(despesa.Id))
                return Result.Failure<DespesaHospedagem>("Já existe uma despesa como essa!");
            
            await _despesaRepository.InsertAsync(despesa, viagem);
            return Result.Success(despesa);
        }

        public async Task<Result<DespesaHospedagem>> AlterarDespesa(DespesaHospedagem despesa)
        {
            if (!await DespesaJaExiste(despesa.Id))
                return Result.Failure<DespesaHospedagem>("Despesa não encontrada!");

            await _despesaRepository.UpdateAsync(despesa);
            return Result.Success(despesa);
        }

        public async Task<Result<DespesaHospedagem>> RemoverViagem(int id)
        {
            DespesaHospedagem despesa = await _despesaRepository.ObterPorIdAsync(id);
            if (despesa is null)
                return Result.Failure<DespesaHospedagem>("Despesa não encontrada!");

            await _despesaRepository.DeleteAsync(despesa);
            return Result.Success(despesa); 
        }

        private async Task<bool> DespesaJaExiste(int id)
        {
            if(await _despesaRepository.ObterPorIdAsync(id) is not null)
            {
                return true;
            }
            return false;
        }
    }
}
