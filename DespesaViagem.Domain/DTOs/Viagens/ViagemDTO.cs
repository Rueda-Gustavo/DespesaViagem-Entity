﻿namespace DespesaViagem.Domain.DTOs.Viagens
{
    public class ViagemDTO
    {
        public int Id { get; set; }
        public required string NomeViagem { get; set; }
        public required string DescricaoViagem { get; set; }
        public decimal Adiantamento { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public decimal TotalDespesas { get; set; }
        public string? StatusViagem { get; set; }
        public required string CPF_Funcionario { get; set; }        
    }
}
