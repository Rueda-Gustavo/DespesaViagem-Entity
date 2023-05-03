using DespesaViagem.Domain.DTOs.Viagens;
using DespesaViagem.Web.ApiDataClient.Interfaces;
using System.Net.Http.Json;

namespace DespesaViagem.Web.ApiDataClient.DataClients
{
    public class ViagemDataClient : IViagemDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ViagemDataClient> _logger;

        public ViagemDataClient(HttpClient httpClient, ILogger<ViagemDataClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ViagemDTO> GetViagemAberta()
        {
            try
            {                
                var viagemDTO = await _httpClient.GetFromJsonAsync<ViagemDTO>("api/viagem/GetViagemAberta");
                return viagemDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Viagem aberta não foi encontrada!");
                throw;
            }
        }

        public async Task<ViagemDTO> GetViagemEmAndamento()
        {
            try
            {
                var viagemDTO = await _httpClient.GetFromJsonAsync<ViagemDTO>("api/viagem/GetViagemEmAndamento");
                return viagemDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Viagem em andamento não foi encontrada!");
                throw;
            }
        }

        public async Task<IEnumerable<ViagemDTO>> GetViagens()
        {
            try
            {
                var viagemDTO = await _httpClient.GetFromJsonAsync<IEnumerable<ViagemDTO>>("api/viagem");
                return viagemDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Viagens não foram encontradas!, " + ex.InnerException);
                throw;
            }

        }
    }
}
