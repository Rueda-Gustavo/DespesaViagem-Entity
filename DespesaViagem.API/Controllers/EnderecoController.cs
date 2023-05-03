using CSharpFunctionalExtensions;
using DespesaViagem.Domain.Models.Core.Records;
using DespesaViagem.Infra.Migrations;
using DespesaViagem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DespesaViagem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult> ObterTodosEnderecos()
        {
            Result<IEnumerable<Endereco>> result = await _enderecoService.ObterTodosEnderecos();

            if (result.IsFailure)
                return BadRequest(result);

            IEnumerable<Endereco> enderecos = result.Value.ToList();

            return Ok(enderecos);
        }

        [HttpGet("Listar por filtro")]
        public async Task<ActionResult> ObterEnderecoPorFiltro(string filtro)
        {
            Result<IEnumerable<Endereco>> result = await _enderecoService.ObterEnderecoPorFiltro(filtro);

            if (result.IsFailure)
                return BadRequest(result);

            return Ok(result.Value.ToList());
        }

        [HttpGet("Listar por id")]        
        public async Task<ActionResult> ObterEnderecoPorId(string id)
        {
            Result<Endereco> result = await _enderecoService.ObterEnderecoPorId(id);

            if (result.IsFailure)
                return BadRequest(result);
            
            return Ok(result.Value);
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult> AlterarEndereco(Endereco endereco)
        {            
            Result<Endereco> result = await _enderecoService.AlterarEndereco(endereco);

            if (result.IsFailure)
                return BadRequest();

            return Ok(result.Value);
        }

        [HttpPost("Novo")]
        public async Task<ActionResult> AdicionarEndereco(Endereco endereco)
        {
            Result<Endereco> result = await _enderecoService.AdicionarEndereco(endereco);

            if (result.IsFailure)
                return BadRequest();

            return Ok(result.Value);
        }
    }
}
