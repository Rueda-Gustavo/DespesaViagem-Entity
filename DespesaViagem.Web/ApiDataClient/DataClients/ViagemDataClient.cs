using DespesaViagem.Domain.DTOs.Records;
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

        public async Task<IEnumerable<ViagemDTO>> GetViagensDTO(string filtro)
        {
            throw new NotImplementedException();
        }
        
        public async Task<IEnumerable<ViagemDTO>> GetViagensDTO()
        {
            try
            {
                var viagemDTO = await _httpClient.GetFromJsonAsync<IEnumerable<ViagemDTO>>("api/viagem/getviagens");                                                        

                return viagemDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Viagens não foram encontradas!, " + ex.InnerException);
                throw;
            }

        }

        public async Task<FuncionarioDTO?> GetFuncionarioDTO(string CPF)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/funcionario/{CPF}/obterfuncionarioporfiltro");
                if (response.IsSuccessStatusCode)
                {                    
                    return await response.Content.ReadFromJsonAsync<FuncionarioDTO>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro ao obter Funcionario pelo CPF = {CPF} - {message}");
                    throw new Exception($"Status Code : {response.StatusCode} - {message}");
                }                                
            }
            catch (Exception ex)
            {
                var a = ex.Message;
                _logger.LogError($"Erro ao obter Funcionario pelo CPF = {CPF}");
                throw;
            }

            throw new NotImplementedException();
        }
    }
}
