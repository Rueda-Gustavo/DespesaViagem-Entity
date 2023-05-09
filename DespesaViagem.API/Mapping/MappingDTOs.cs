using DespesaViagem.Domain.DTOs.Despesas;
using DespesaViagem.Domain.DTOs.Records;
using DespesaViagem.Domain.DTOs.Viagens;
using DespesaViagem.Domain.Models.Core.Records;
using DespesaViagem.Domain.Models.Despesas;
using DespesaViagem.Domain.Models.Viagens;
using Microsoft.OpenApi.Extensions;

namespace DespesaViagem.API.Mapping
{
    public static class MappingDTOs
    {
        public static IEnumerable<ViagemDTO> ConverterViagensParaDTO(
                                    this IEnumerable<Viagem> viagens)
        {
            return (from viagem in viagens
                    select new ViagemDTO
                    {
                        Id = viagem.Id,
                        NomeViagem = viagem.NomeViagem,
                        DescricaoViagem = viagem.DescricaoViagem,
                        Adiantamento = viagem.Adiantamento,
                        DataInicial = viagem.DataInicial,
                        DataFinal = viagem.DataFinal,
                        TotalDespesas = viagem.TotalDespesas,
                        StatusViagem = viagem.StatusViagem.GetDisplayName(),
                        //NomeFuncionario = viagem.Funcionario.Nome,
                        //SobrenomeFuncionario = viagem.Funcionario.Sobrenome,
                        CPF_Funcionario = viagem.Funcionario.CPF,
                        //MatriculaFuncionario = viagem.Funcionario.Matricula
                    }).ToList();
        }

        public static ViagemDTO ConverterViagemParaDTO(
            this Viagem viagem)
        {
            return new ViagemDTO
            {
                Id = viagem.Id,
                NomeViagem = viagem.NomeViagem,
                DescricaoViagem = viagem.DescricaoViagem,
                Adiantamento = viagem.Adiantamento,
                DataInicial = viagem.DataInicial,
                DataFinal = viagem.DataFinal,
                TotalDespesas = viagem.TotalDespesas,
                StatusViagem = viagem.StatusViagem.GetDisplayName(),                
                CPF_Funcionario = viagem.Funcionario.CPF,                
            };
        }

        public static IEnumerable<DespesaHospedagemDTO> ConverterDespesasHospedagemParaDTO(
            this IEnumerable<DespesaHospedagem> despesas)
        {
            return (from despesa in despesas
                    select new DespesaHospedagemDTO
                    {
                        Id = despesa.Id,                        
                        DescricaoDespesa = despesa.DescricaoDespesa,
                        TotalDespesa = despesa.TotalDespesa,
                        DataDespesa = despesa.DataDespesa,                        
                        Logradouro = despesa.Endereco.Logradouro,
                        CEP = despesa.Endereco.CEP,
                        Cidade = despesa.Endereco.Cidade,
                        Estado = despesa.Endereco.Estado,
                        NumeroCasa = despesa.Endereco.NumeroCasa,
                        QuantidadeDias = despesa.QuantidadeDias,
                        ValorDiaria = despesa.ValorDiaria
                    }).ToList();
        }

        public static DespesaHospedagemDTO ConverterDespesaHospedagemParaDTO(
            this DespesaHospedagem despesa)
        {
            return new DespesaHospedagemDTO
            {
                Id = despesa.Id,
                DescricaoDespesa = despesa.DescricaoDespesa,
                TotalDespesa = despesa.TotalDespesa,
                DataDespesa = despesa.DataDespesa,
                Logradouro = despesa.Endereco.Logradouro,
                CEP = despesa.Endereco.CEP,
                Cidade = despesa.Endereco.Cidade,
                Estado = despesa.Endereco.Estado,
                NumeroCasa = despesa.Endereco.NumeroCasa,
                QuantidadeDias = despesa.QuantidadeDias,
                ValorDiaria = despesa.ValorDiaria
            };
        }

        public static FuncionarioDTO ConverterFuncionarioParaDTO(this Funcionario funcionario)
        {
            return new FuncionarioDTO
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Sobrenome = funcionario.Sobrenome,
                CPF = funcionario.CPF,
                Matricula = funcionario.Matricula
            };
        }

        public static IEnumerable<FuncionarioDTO> ConverterFuncionariosParaDTO(
            this IEnumerable<Funcionario> funcionarios)
        {
            return (from funcionario in funcionarios
                    select new FuncionarioDTO
                    {
                        Id = funcionario.Id,
                        Nome = funcionario.Nome,
                        Sobrenome = funcionario.Sobrenome,
                        CPF = funcionario.CPF,
                        Matricula = funcionario.Matricula
                    }).ToList();
        }
    }
}
