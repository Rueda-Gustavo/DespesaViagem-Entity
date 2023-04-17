using DespesaViagem.Domain.Models.Core.Records;
using DespesaViagem.Domain.Models.Despesas;
using DespesaViagem.Domain.Models.Viagens;

using DespesaViagem.Infra.Database;
using DespesaViagem.Infra.Interfaces;
using DespesaViagem.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Win32;

namespace DespesaViagem
{
    internal class Program
    {
        //private static IServiceCollection Services;
        //public static IServiceProvider ServiceProvider;
        static void Main()
        {

            //IConfiguration configuration = SetConfigurations();
            //CreateServices(configuration);

            //Console.WriteLine("Hello, World!");
            //var optionsBuilder = new DbContextOptionsBuilder<DespesaViagemContext>();
            //optionsBuilder.UseSqlServer("");
            //var context = new DespesaViagemContext(optionsBuilder.Options);

            /*
            Viagem viagem = new Viagem(1, "Viagem 1", "Primeiro teste de Viagem", 2000, new Agendamento(), new Funcionario());
            DespesaDeslocamento despesa = new DespesaDeslocamento(1, "Viagem a trabalho", 400, 1.5m, new Veiculo { Modelo = "Corsa", Placa = "ABC1234" });
            viagem.AdicionarDespesa(despesa);
            */

            //Viagem viagem = new Viagem("Viagem 1", "Primeira viagem", 2000.0m, DateTime.UtcNow.AddDays(5), DateTime.UtcNow, "Gustavo", "100");

            /*
            viagem.AdicionarDespesa(new DespesaRefeicao(1, "Despesa com alimentos", 20.9m,
            new Estabelecimento { CNPJ = "1234", NomeEstabelecimento = "Cantina da Maria" }));
            viagem.AdicionarDespesa(new DespesaRefeicao(2, "Despesa com alimentos", 20.9m,
                new Estabelecimento { CNPJ = "1234", NomeEstabelecimento = "Cantina da Maria" }));
            */

            //DespesaHospedagem despesa = new DespesaHospedagem(0,"Café da manhã do primeiro dia", new Endereco { Id = 1, Logradouro = "Log", NumeroCasa = 1, CEP = "1234", Cidade = "Cidade", Estado = "Estado" }, 10, 250.50m);
            //despesa.Viagem = viagem;

            //--------------------------------------------------------------------------------------------
            //Testando inserção
            /*
            //context.Viagens.Add(viagem);
            //context.SaveChanges();
            
            ViagemRepository vr = new ViagemRepository(context);
            
            
            Task task = vr.InsertAsync(viagem);     
            task.Wait();
            */
            //DespesaHospedagemRepository dh = new DespesaHospedagemRepository(context);

            //Task<IEnumerable<DespesaHospedagem>> consultaDh = dh.ObterTodosAsync(1);
            /*Task<DespesaHospedagem> consultaDh = dh.ObterPorIdAsync(2);
            consultaDh.Wait();
            var registro = consultaDh.Result;
            Console.WriteLine($"{registro.NomeDespesa} | {registro.DescricaoDespesa} | {registro.TipoDespesa} | {registro.Endereco}");
            
            registro.Endereco.Estado = "SP";
            Task t = dh.UpdateAsync(registro);
            t.Wait();

            consultaDh = dh.ObterPorIdAsync(2);
            consultaDh.Wait();
            registro = consultaDh.Result;
            Console.WriteLine($"{registro.NomeDespesa} | {registro.DescricaoDespesa} | {registro.TipoDespesa} | {registro.Endereco}");
            */
            /*
            foreach (var registro in consultaDh.Result)
            {
                Console.WriteLine($"{registro.NomeDespesa} | {registro.DescricaoDespesa} | {registro.TipoDespesa} | {registro.Endereco}");
            }          
            */

            //---------------------------------------------------------------------------------------------
            //Testando consulta
            /*Task<IEnumerable<Viagem>> consulta = vr.ObterAsync("2");
            consulta.Wait();         
            
            foreach(var registro in consulta.Result)
            {
                var v = registro;
                Console.WriteLine(v.NomeViagem + '|' + v.DescricaoViagem);
            }
            */

            //viagem.RemoverDespesa(2);
            //Console.WriteLine(viagem);


            /*
            Viagem viagem = new Viagem("1", "Viagem 1", 2000.0m,
                                 new Agendamento { DataFinal = DateTime.UtcNow.AddDays(5), DataInicial = DateTime.UtcNow },
                                 new Funcionario { Matricula = "100", Nome = "Gustavo" });*/

            //Viagem viagem = new Viagem { Id = "1", Nome = "Viagem"};

            //db.CriarViagem(viagem);
            //var a = db.GetAllViagens();
        }


    }
}

//Mapear entidades para o entity framework
