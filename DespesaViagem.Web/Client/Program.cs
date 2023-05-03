using DespesaViagem.Web;
using DespesaViagem.Web.ApiDataClient.DataClients;
using DespesaViagem.Web.ApiDataClient.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace DespesaViagem.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //var baseUrl = "http://localhost:5059";
            var baseUrl = "https://localhost:7234";
            builder.Services.AddScoped(client => new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            });

            builder.Services.AddScoped<IViagemDataClient, ViagemDataClient>();

            await builder.Build().RunAsync();
        }
    }
}