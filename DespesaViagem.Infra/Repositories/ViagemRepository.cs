using DespesaViagem.Domain.Models.Despesas;
using DespesaViagem.Domain.Models.Viagens;
using DespesaViagem.Infra.Database;
using DespesaViagem.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DespesaViagem.Infra.Repositories
{
    public class ViagemRepository : IViagemRepository
    {
        private readonly DespesaViagemContext _context;

        public ViagemRepository(DespesaViagemContext context)
        => _context = context;


        public async Task<IEnumerable<Viagem>> ObterTodosAsync()
            => await _context.Viagens.ToListAsync();

        public async Task<Viagem> ObterPorIdAsync(int id)
        {
            return await _context.Viagens
                .FirstOrDefaultAsync(viagem => viagem.Id == id);
            
            //    .Where(viagem => viagem.Id == id)
            //    .ToListAsync();
        }

        public async Task<IEnumerable<Viagem>> ObterAsync(string filtro)
        {
            _ = int.TryParse(filtro, out int id);
            return await _context.Viagens
                .Where(viagem => viagem.Id == id || viagem.NomeViagem.Contains(filtro) || viagem.DescricaoViagem.Contains(filtro))                
                .ToListAsync();                
        }

        public async Task<IEnumerable<Despesa>> ObterTodasDepesasAsync(int viagemId)
        {
            return await _context.Despesas
                .Where(despesa => despesa.Viagem.Id == viagemId)
                .ToListAsync();
        }

        public async Task InsertAsync(Viagem viagem)
        {
            _context.Add(viagem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Viagem viagem)
        {
            _context.Update(viagem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var viagem = ObterPorIdAsync(id);
            _context.Remove(viagem);
            await _context.SaveChangesAsync();
        }
    }
}
