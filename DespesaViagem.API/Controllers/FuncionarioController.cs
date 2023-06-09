﻿using CSharpFunctionalExtensions;
using DespesaViagem.Domain.Models.Core.Records;
using DespesaViagem.Service.Interfaces;
using DespesaViagem.API.Mapping;
using Microsoft.AspNetCore.Mvc;
using DespesaViagem.Domain.DTOs.Records;

namespace DespesaViagem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult> ObterTodosFuncionarios()
        {
            Result<IEnumerable<Funcionario>> result = await _funcionarioService.ObterTodosFuncionarios();

            if (result.IsFailure)
                return BadRequest(result);

            IEnumerable<Funcionario> funcionarios = result.Value.ToList();

            return Ok(funcionarios);
        }

        [HttpGet]
        [Route("{filtro}/ObterFuncionarioPorFiltro")]
        public async Task<ActionResult> ObterFuncionarioPorFiltro(string filtro)
        {
            Result<IEnumerable<Funcionario>> result = await _funcionarioService.ObterFuncionarioPorFiltro(filtro);

            if (result.IsFailure)
                return BadRequest(result);

            IEnumerable<Funcionario> funcionarios = result.Value.ToList();

            if(funcionarios.Count() == 1)
            {
                FuncionarioDTO funcionarioDTO = funcionarios.First().ConverterFuncionarioParaDTO();
                return Ok(funcionarioDTO);
            }

            IEnumerable<FuncionarioDTO> funcionariosDTO = funcionarios.ConverterFuncionariosParaDTO();
            return Ok(funcionariosDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> ObterFuncionarioPorId(int id)
        {
            Result<Funcionario> result = await _funcionarioService.ObterFuncionarioPorId(id);

            if (result.IsFailure)
                return BadRequest(result);

            return Ok(result.Value);
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult> AlterarFuncionario(Funcionario funcionario)
        {
            Result<Funcionario> result = await _funcionarioService.AlterarFuncionario(funcionario);

            if (result.IsFailure)
                return BadRequest();

            return Ok(result.Value);
        }

        [HttpPost("Novo")]
        public async Task<ActionResult> AdicionarEndereco(Funcionario funcionario)
        {
            Result<Funcionario> result = await _funcionarioService.AdicionarFuncionario(funcionario);

            if (result.IsFailure)
                return BadRequest();

            return Ok(result.Value);
        }
    }
}
