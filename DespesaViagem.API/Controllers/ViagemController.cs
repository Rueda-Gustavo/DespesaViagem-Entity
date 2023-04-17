using CSharpFunctionalExtensions;
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

        public ViagemController(IViagemService viagemService)
        {
            _viagemService = viagemService;
        }
        
        [HttpGet("Listar")]
        public async Task<ActionResult> ObterTodasViagens()
        {
            Result<IEnumerable<Viagem>> result = await _viagemService.ObterTodasViagens();
            if (result.IsFailure)
                return BadRequest(result);

            List<Viagem> viagens = result.Value.ToList();
            return Ok(viagens);
        }

    }
}
