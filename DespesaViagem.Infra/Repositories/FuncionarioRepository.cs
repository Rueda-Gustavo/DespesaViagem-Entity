using DespesaViagem.Domain.Models.Core.Records;
using DespesaViagem.Infra.Database;
using DespesaViagem.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DespesaViagem.Infra.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly DespesaViagemContext _context;

        public FuncionarioRepository(DespesaViagemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Funcionario>> ObterTodosAsync()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        public async Task<Funcionario> ObterPorIdAsync(int id)
        {
            return await _context.Funcionarios
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Funcionario> ObterPorCPFAsync(string CPF)
        {
            return await _context.Funcionarios
                .FirstOrDefaultAsync(f => f.CPF == CPF);
        }

        public async Task<IEnumerable<Funcionario>> ObterAsync(string filtro)
        {
            return await _context.Funcionarios
            .Where(funcionario => funcionario.CPF.Contains(filtro) || funcionario.Nome.Contains(filtro) || funcionario.Sobrenome.Contains(filtro) || funcionario.Matricula.Contains(filtro))
            .ToListAsync();
        }

        public async Task InsertAsync(Funcionario funcionario)
        {
            _context.Add(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Funcionario funcionario)
        {
            _context.Update(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Funcionario funcionario)
        {            
            _context.Remove(funcionario);
            await _context.SaveChangesAsync();
        }
    }
}
