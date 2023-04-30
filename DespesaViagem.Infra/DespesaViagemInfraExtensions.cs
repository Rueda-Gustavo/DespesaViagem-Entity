using DespesaViagem.Domain.Models.Despesas;
using DespesaViagem.Infra.Database;
using DespesaViagem.Infra.Interfaces;
using DespesaViagem.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DespesaViagem.Infra
{
    public static class DespesaViagemInfraExtensions
    {
        public static IServiceCollection AddDespesaViagemInfra(this IServiceCollection service, IConfiguration configuration)
        {
            //string connectionString = configuration.GetConnectionString("SqlServer");
            service.AddDbContext<DespesaViagemContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));            
            service.AddScoped<IViagemRepository, ViagemRepository>();
            service.AddScoped<IDespesaRepository, DespesaRepository>();
            service.AddScoped<IDespesasRepository<DespesaHospedagem, int>, DespesaHospedagemRepository>();            
            return service;
        }
    }
}
