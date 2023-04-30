using DespesaViagem.Domain.Models.Despesas;
using DespesaViagem.Domain.Models.Viagens;
using DespesaViagem.Infra.Database;
using DespesaViagem.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DespesaViagem.Infra.Repositories
{
    public class DespesaHospedagemRepository : IDespesasRepository<DespesaHospedagem, int>
    {
        private readonly DespesaViagemContext _context;
        public DespesaHospedagemRepository(DespesaViagemContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DespesaHospedagem>> ObterTodosAsync(int idViagem)
        {
            return await _context.DespesasHospedagens
                .Where(despesa => despesa.IdViagem == idViagem)
                .Include(endereco => endereco.Endereco)                
                .ToListAsync();
        }

        public async Task<DespesaHospedagem> ObterPorIdAsync(int id)
            => await _context.DespesasHospedagens
                .Include(endereco => endereco.Endereco)
                .FirstOrDefaultAsync(despesa => despesa.Id == id);

        public async Task<IEnumerable<DespesaHospedagem>> ObterAsync(string filtro, int idViagem)
        {            
            return await _context.DespesasHospedagens
                .Where(despesa =>
                 (despesa.NomeDespesa.Contains(filtro) ||
                 despesa.DescricaoDespesa.Contains(filtro)) &&
                 despesa.Viagem.Id == idViagem)
                 .Include(endereco => endereco.Endereco)
                .ToListAsync();
        }
        public async Task InsertAsync(DespesaHospedagem despesa, Viagem viagem)
        {
            despesa.Viagem = viagem;
            _context.Add(despesa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DespesaHospedagem despesa)
        {            
            _context.Update(despesa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(DespesaHospedagem despesa)
        {            
            _context.Remove(despesa);
            await _context.SaveChangesAsync();
        }
    }
}
