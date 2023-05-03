using DespesaViagem.Domain.Models.Despesas;
using DespesaViagem.Service.Interfaces;
using DespesaViagem.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DespesaViagem.Service
{
    public static class DespesaViagemServiceExtensions
    {
        public static IServiceCollection AddDespesaViagemService(this IServiceCollection service)
        {
            service.AddScoped<IEnderecoService, EnderecoService>();
            service.AddScoped<IFuncionarioService, FuncionarioService>();
            service.AddScoped<IViagemService, ViagemService>();
            service.AddScoped<IDespesaService, DespesaService>();
            service.AddScoped<IDespesasService<DespesaHospedagem, int>, DespesaHospedagemService>();
            return service;
        }
    }
}