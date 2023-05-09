using CSharpFunctionalExtensions;
using DespesaViagem.API.Mapping;
using DespesaViagem.Domain.DTOs.Viagens;
using DespesaViagem.Domain.Models.Core.Records;
using DespesaViagem.Domain.Models.Despesas;
using DespesaViagem.Domain.Models.Viagens;
using DespesaViagem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DespesaViagem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViagemController : Controller
    {
        private readonly IViagemService _viagemService;
        private readonly IDespesaService _despesaService;
        private readonly IFuncionarioService _funcionarioService;

        public ViagemController(IViagemService viagemService, IDespesaService despesaService, IFuncionarioService funcionarioService)
        {
            _viagemService = viagemService;
            _despesaService = despesaService;
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        [Route("GetViagens")]
        public async Task<ActionResult> ObterTodasViagens()
        {
            Result<IEnumerable<Viagem>> result = await _viagemService.ObterTodasViagens();

            if (result.IsFailure)
                return BadRequest(result);
            
            IEnumerable<Viagem> viagens = result.Value.ToList();

            foreach(var viagem in viagens)
            {
                Result<IEnumerable<Despesa>> despesas = await _despesaService.ObterTodasDespesas(viagem.Id);
                viagem.AdicionarDespesas(despesas.Value.ToList());
            }

            IEnumerable<ViagemDTO> viagensDTO = viagens.ConverterViagensParaDTO();

            return Ok(viagensDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> ObterViagensPorId(string id)
        {                        
            Result<Viagem> result = await _viagemService.ObterViagemPorId(id);            

            if (result.IsFailure)
                return BadRequest(result);    
            
            Viagem viagem = result.Value;
            Result<IEnumerable<Despesa>> despesas = await _despesaService.ObterTodasDespesas(viagem.Id);
            viagem.AdicionarDespesas(despesas.Value.ToList());

            return Ok(result.Value);
        }

        [HttpGet("{filtro}")]        
        public async Task<ActionResult> ObterViagensPorFiltro(string filtro)
        {
            Result<IEnumerable<Viagem>> result = await _viagemService.ObterViagemPorFiltro(filtro);

            if (result.IsFailure)
                return BadRequest(result);

            IEnumerable<Viagem> viagens = result.Value.ToList();

            foreach (var viagem in viagens)
            {
                Result<IEnumerable<Despesa>> despesas = await _despesaService.ObterTodasDespesas(viagem.Id);
                viagem.AdicionarDespesas(despesas.Value.ToList());
            }

            return Ok(viagens);
        }

        [HttpGet]
        [Route("{id}/ObterDespesasViagem")]
        public async Task<ActionResult> ObterTodasDespesasDaViagem(int idViagem)
        {
            Result<IEnumerable<Despesa>> result = await _viagemService.ObterTodasDespesas(idViagem);

            if (result.IsFailure)
                return BadRequest(result);

            List<Despesa> despesas = result.Value.ToList();
            return Ok(despesas);
        }
        /*
        [HttpGet("GetViagemAberta")]
        public async Task<ActionResult> ObterViagemAberta()
        {
            Result<Viagem> result = await _viagemService.ObterViagemAberta();

            if (result.IsFailure)
                return BadRequest(result);

            ViagemDTO viagemDTO = result.Value.ConverterViagemParaDTO();

            return Ok(viagemDTO);
        }

        [HttpGet]
        [Route("GetViagemEmAndamento")]
        public async Task<ActionResult> ObterViagemEmAndamento()
        {
            Result<Viagem> result = await _viagemService.ObterViagemEmAndamento();

            if (result.IsFailure)
                return BadRequest(result);

            Viagem viagem = result.Value;
            if(viagem.DataFinal < DateTime.Now)
            {
                viagem.EncerrarViagem();
                return NoContent();
            }

            ViagemDTO viagemDTO = result.Value.ConverterViagemParaDTO();

            return Ok(viagemDTO);
        }
        */

        [HttpPatch]
        [Route("IniciarViagem")]
        public async Task<ActionResult> IniciarViagem()
        {
            Result<Viagem> result = await _viagemService.ObterViagemAberta();

            if (result.IsFailure)
                return BadRequest(result);            

            Viagem viagem = result.Value;            

            Result<Viagem> resultViagemIniciada = await _viagemService.IniciarViagem(viagem);

            if (resultViagemIniciada.IsFailure)
                return BadRequest(resultViagemIniciada);

            ViagemDTO viagemDTO = resultViagemIniciada.Value.ConverterViagemParaDTO();

            return Ok(viagemDTO);            
        }

        [HttpPatch]
        [Route("EncerrarViagem")]
        public async Task<ActionResult> EncerrarViagem()
        {
            Result<Viagem> result = await _viagemService.ObterViagemEmAndamento();

            if (result.IsFailure)
                return BadRequest(result);

            Viagem viagem = result.Value;

            Result<Viagem> resultViagemIniciada = await _viagemService.EncerrarViagem(viagem);

            if (resultViagemIniciada.IsFailure)
                return BadRequest(resultViagemIniciada);

            ViagemDTO viagemDTO = resultViagemIniciada.Value.ConverterViagemParaDTO();

            return Ok(viagemDTO);
        }

        [HttpPost]        
        [Route("Novo")]
        public async Task<ActionResult> InserirViagem(ViagemDTO viagemDTO)
        {
            viagemDTO.StatusViagem = string.Empty;

            Result<Funcionario> funcionario = (await _funcionarioService.ObterFuncionarioPorCPF(viagemDTO.CPF_Funcionario));            

            if (funcionario.IsFailure)
                return BadRequest(funcionario.ConvertFailure());

            Viagem viagem = new Viagem(viagemDTO.NomeViagem, viagemDTO.DescricaoViagem, viagemDTO.Adiantamento, viagemDTO.DataInicial, viagemDTO.DataFinal, funcionario.Value);

            Result<Viagem> result = await _viagemService.AdicionarViagem(viagem);

            if (result.IsFailure)
                return BadRequest(result.Value);

            viagemDTO = result.Value.ConverterViagemParaDTO();

            return Ok(viagemDTO);
        }
    }
}
