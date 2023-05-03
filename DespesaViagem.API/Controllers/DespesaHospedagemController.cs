using CSharpFunctionalExtensions;
using DespesaViagem.API.Mapping;
using DespesaViagem.Domain.DTOs.Despesas;
using DespesaViagem.Domain.Models.Core.Records;
using DespesaViagem.Domain.Models.Despesas;
using DespesaViagem.Domain.Models.Viagens;
using DespesaViagem.Service.Interfaces;
using DespesaViagem.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace DespesaViagem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespesaHospedagemController : Controller
    {

        private readonly IDespesasService<DespesaHospedagem, int> _despesasService;
        private readonly IEnderecoService _enderecoService;
        private readonly IViagemService _viagemService;

        public DespesaHospedagemController(IDespesasService<DespesaHospedagem, int> despesasService, IEnderecoService enderecoService, IViagemService viagemService)
        {
            _despesasService = despesasService;
            _enderecoService = enderecoService;
            _viagemService = viagemService;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult> ObterTodasDespesas(int idViagem)
        {
            Result<IEnumerable<DespesaHospedagem>> result = await _despesasService.ObterTodasDespesas(idViagem);

            if (result.IsFailure)
                return BadRequest(result);

            IEnumerable<DespesaHospedagem> despesas = result.Value.ToList();

            IEnumerable<DespesaHospedagemDTO> despesasDTO = despesas.ConverterDespesasHospedagemParaDTO();
                                             
            return Ok(despesasDTO);
        }

        [HttpGet("Listar por Id")]
        public async Task<ActionResult> ObterDespesaPorId(string id)
        {            
            Result<DespesaHospedagem> result = await _despesasService.ObterDespesaPorId(id);
            
            if (result.IsFailure)
                return BadRequest(result);

            DespesaHospedagem despesa = result.Value;

            DespesaHospedagemDTO despesaDTO = despesa.ConverterDespesaHospedagemParaDTO();

            return Ok(despesaDTO);
        }

        [HttpGet("Listar por filtro")]
        public async Task<ActionResult> ObterDespesasPorFiltro(string filtro, string idViagem)
        {
            Result<IEnumerable<DespesaHospedagem>> result = await _despesasService.ObterDespesasPorFiltro(filtro, idViagem);

            if (result.IsFailure)
                return BadRequest(result);

            IEnumerable<DespesaHospedagem> despesa = result.Value.ToList();

            IEnumerable<DespesaHospedagemDTO> despesaDTO = despesa.ConverterDespesasHospedagemParaDTO();

            return Ok(despesaDTO);
        }

        [HttpPost("Novo")]        
        public async Task<ActionResult> InserirDespesa(DespesaHospedagemDTO despesaDTO)
        {            
            Endereco endereco = new Endereco { Logradouro = despesaDTO.Logradouro, CEP = despesaDTO.CEP, NumeroCasa = despesaDTO.NumeroCasa, Cidade = despesaDTO.Cidade, Estado = despesaDTO.Estado };
            Result<Endereco> resultEndereco = await _enderecoService.AdicionarEndereco(endereco);

            if (resultEndereco.IsFailure)
                endereco = (await _enderecoService.ObterEnderecoPorFiltro(endereco)).Value;
            
            Result<Viagem> viagem = await _viagemService.ObterViagemEmAndamento();

            if (viagem.IsFailure)
                return BadRequest(viagem);

            DespesaHospedagem despesa = new DespesaHospedagem(despesaDTO.DescricaoDespesa, endereco, despesaDTO.QuantidadeDias, despesaDTO.ValorDiaria, viagem.Value.Id);

            Result<DespesaHospedagem> result = await _despesasService.AdicionarDespesa(despesa, viagem.Value);

            if(result.IsFailure) 
                return BadRequest(result);

            return Ok(result);
        }
    }
}
