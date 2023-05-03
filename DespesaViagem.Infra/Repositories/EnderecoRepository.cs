using DespesaViagem.Domain.Models.Core.Records;
using DespesaViagem.Domain.Models.Viagens;
using DespesaViagem.Infra.Database;
using DespesaViagem.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DespesaViagem.Infra.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly DespesaViagemContext _context;

        public EnderecoRepository(DespesaViagemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Endereco>> ObterTodosAsync()
        {
            return await _context.Enderecos.ToListAsync();
        }

        public async Task<Endereco> ObterPorIdAsync(int id)
        {
            return await _context.Enderecos
                .FirstOrDefaultAsync(e => e.Id == id);                                
        }

        public async Task<IEnumerable<Endereco>> ObterAsync(string filtro)
        {
            return await _context.Enderecos
            .Where(endereco => endereco.Logradouro.Contains(filtro) || endereco.CEP.Contains(filtro) || endereco.Cidade.Contains(filtro) || endereco.Estado.Contains(filtro))
            .ToListAsync();
        }       

        public async Task InsertAsync(Endereco endereco)
        {
            _context.Add(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Endereco endereco)
        {
            var enderecoNaMemoria = _context.Set<Endereco>().Find(endereco.Id);

            if (enderecoNaMemoria != null)
                _context.Entry(enderecoNaMemoria).State = EntityState.Detached;

            _context.Entry(endereco).State = EntityState.Modified;
            _context.Update(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Endereco endereco)
        {            
            _context.Remove(endereco);
            await _context.SaveChangesAsync();
        }
    }
}
