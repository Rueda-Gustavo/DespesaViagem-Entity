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
        public async Task<IEnumerable<DespesaHospedagem>> ObterTodosAsync(int viagemId)
        {
            return await _context.DespesasHospedagens
                .Where(despesa => despesa.Viagem.Id == viagemId)
                .Include(endereco => endereco.Endereco)
                .ToListAsync();
        }

        public async Task<DespesaHospedagem> ObterPorIdAsync(int id)
            => await _context.DespesasHospedagens
                .Include(endereco => endereco.Endereco)
                .FirstOrDefaultAsync(despesa => despesa.Id == id);

        public async Task<IEnumerable<DespesaHospedagem>> ObterAsync(string filtro, int viagemId)
        {
            //_ = int.TryParse(filtro, out int id);

            return await _context.DespesasHospedagens
                .Where(despesa =>
                (//despesa.Id == id ||
                 despesa.NomeDespesa.Contains(filtro) ||
                 despesa.DescricaoDespesa.Contains(filtro)) &&
                 despesa.Viagem.Id == viagemId)
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

        public async Task DeleteAsync(int id)
        {
            var despesa = ObterPorIdAsync(id);
            _context.Remove(despesa);
            await _context.SaveChangesAsync();
        }
    }
}
