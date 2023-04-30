using DespesaViagem.Domain.DTOs.Despesas;
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
                        NomeFuncionario = viagem.Funcionario.Nome,
                        SobrenomeFuncionario = viagem.Funcionario.Sobrenome,
                        CPF_Funcionario = viagem.Funcionario.CPF,
                        MatriculaFuncionario = viagem.Funcionario.Matricula
                    }).ToList();
        }

        public static IEnumerable<DespesaHospedagemDTO> ConverterDespesasHospedagemParaDTO(
            this IEnumerable<DespesaHospedagem> despesas)
        {
            return (from despesa in despesas
                    select new DespesaHospedagemDTO
                    {
                        Id = despesa.Id,
                        NomeDespesa = despesa.NomeDespesa,
                        DescricaoDespesa = despesa.DescricaoDespesa,
                        TotalDespesa = despesa.TotalDespesa,
                        DataDespesa = despesa.DataDespesa,
                        TipoDespesa = despesa.TipoDespesa,
                        Logradouro = despesa.Endereco.Logradouro,
                        CEP = despesa.Endereco.CEP,
                        Cidade = despesa.Endereco.Cidade,
                        Estado = despesa.Endereco.Estado,
                        NumeroCasa = despesa.Endereco.NumeroCasa,
                        QuantidadeDias = despesa.QuantidadeDias,
                        ValorDiaria = despesa.ValorDiaria
                    }).ToList();
        }
    }
}
