using CSharpFunctionalExtensions;
using DespesaViagem.API.Mapping;
using DespesaViagem.Domain.Models.Despesas;
using DespesaViagem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DespesaViagem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespesaHospedagemController : Controller
    {

        private readonly IDespesasService<DespesaHospedagem, int> _despesasService;

        public DespesaHospedagemController(IDespesasService<DespesaHospedagem, int> despesasService)
        {
            _despesasService = despesasService;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult> ObterTodasDespesas(int idViagem)
        {
            Result<IEnumerable<DespesaHospedagem>> result = await _despesasService.ObterTodasDespesas(idViagem);

            if (result.IsFailure)
                return BadRequest(result);

            List<DespesaHospedagem> despesas = result.Value.ToList();

            var despesasDTO = despesas.ConverterDespesasHospedagemParaDTO();
                                             
            return Ok(despesasDTO);
        }
    }
}
