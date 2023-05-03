using DespesaViagem.Domain.DTOs.Viagens;

namespace DespesaViagem.Web.ApiDataClient.Interfaces
{
    public interface IViagemDataClient
    {
        Task<ViagemDTO> GetViagemAberta();
        Task<ViagemDTO> GetViagemEmAndamento();
        Task<IEnumerable<ViagemDTO>> GetViagens();
    }
}
