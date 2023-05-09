using DespesaViagem.Domain.DTOs.Records;
using DespesaViagem.Domain.DTOs.Viagens;
using DespesaViagem.Domain.Models.Core.Records;

namespace DespesaViagem.Web.ApiDataClient.Interfaces
{
    public interface IViagemDataClient
    {
        Task<IEnumerable<ViagemDTO>> GetViagensDTO();
        Task<IEnumerable<ViagemDTO>> GetViagensDTO(string filtro);
        Task<FuncionarioDTO>  GetFuncionarioDTO(string CPF);
    }
}
