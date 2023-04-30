using CSharpFunctionalExtensions;
using DespesaViagem.API.Mapping;
using DespesaViagem.Domain.DTOs.Viagens;
using DespesaViagem.Domain.Models.Core.Records;
using DespesaViagem.Domain.Models.Despesas;
using DespesaViagem.Domain.Models.Viagens;
using DespesaViagem.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DespesaViagem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViagemController : Controller
    {
        private readonly IViagemService _viagemService;
        private readonly IDespesaService _despesaService;

        public ViagemController(IViagemService viagemService, IDespesaService despesaService)
        {
            _viagemService = viagemService;
            _despesaService = despesaService;
        }

        [HttpGet("Listar")]
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

            var viagensDTO = viagens.ConverterViagensParaDTO();

            return Ok(viagensDTO);
        }

        [HttpGet("Listar por Id")]
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

        [HttpGet("Listar por filtro")]
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

        [HttpGet("Listar despesas")]
        public async Task<ActionResult> ObterTodasDespesasDaViagem(int idViagem)
        {
            Result<IEnumerable<Despesa>> result = await _viagemService.ObterTodasDespesas(idViagem);

            if (result.IsFailure)
                return BadRequest(result);

            List<Despesa> despesas = result.Value.ToList();
            return Ok(despesas);
        }

        [HttpPost("Nova viagem")]
        public async Task<ActionResult> InserirViagem(ViagemDTO viagemDTO)
        {

            Viagem viagem = new Viagem(viagemDTO.NomeViagem, viagemDTO.DescricaoViagem, viagemDTO.Adiantamento, viagemDTO.DataInicial, viagemDTO.DataFinal,
                new Funcionario { Nome = viagemDTO.NomeViagem, Sobrenome = viagemDTO.SobrenomeFuncionario, CPF = viagemDTO.CPF_Funcionario, Matricula = viagemDTO.MatriculaFuncionario });            

            Result<Viagem> result = await _viagemService.AdicionarViagem(viagem);
            if (result.IsFailure)
                return BadRequest(result);

            return Ok(result.Value);
        }


    }
}
