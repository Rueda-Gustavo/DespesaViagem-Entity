using DespesaViagem.Domain.Models.Despesas;
using DespesaViagem.Infra.Database;
using DespesaViagem.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DespesaViagem.Infra.Repositories
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly DespesaViagemContext _context;

        public DespesaRepository(DespesaViagemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Despesa>> ObterTodosAsync(int idViagem)
        {
            return await _context.Despesas
                .Where(despesa => despesa.IdViagem == idViagem)
                .ToListAsync();
        }

        public async Task<Despesa> ObterPorIdAsync(int id)
        {
            return await _context.Despesas
                .FirstOrDefaultAsync(despesa => despesa.Id == id);
        }

        public async Task<IEnumerable<Despesa>> ObterAsync(string filtro, int idViagem)
        {
            return await _context.Despesas
                .Where(despesa =>
                (despesa.NomeDespesa.Contains(filtro) ||
                 despesa.DescricaoDespesa.Contains(filtro)) &&
                 despesa.Viagem.Id == idViagem)                
                .ToListAsync();
        }        
    }
}
