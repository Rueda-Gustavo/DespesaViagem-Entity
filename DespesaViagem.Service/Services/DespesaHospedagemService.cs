using CSharpFunctionalExtensions;
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
            var viagem = _viagemService.ObterViagemPorFiltro(idViagem.ToString());            
            return Result.Success(await _despesaRepository.ObterTodosAsync(viagem.Id));
        }        

        public Task<Result<DespesaHospedagem>> ObterDespesaPorId(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Result<DespesaHospedagem>> AdicionarDespesa(DespesaHospedagem despesa, int idViagem)
        {
            throw new NotImplementedException();
        }

        public Task<Result<DespesaHospedagem>> AlterarDespesa(DespesaHospedagem despesa)
        {
            throw new NotImplementedException();
        }

        public Task<Result<DespesaHospedagem>> RemoverViagem(int id)
        {
            throw new NotImplementedException();
        }
    }
}
