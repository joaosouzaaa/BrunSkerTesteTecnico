using BrunSker.Business.Interfaces.Repositories;
using BrunSker.Domain.Entities;
using BrunSker.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BrunSker.Infra.Repositories
{
    public class LocacaoRepository : ILocacaoRepository
    {
        private readonly BrunSkerDbContext _context;
        public DbSet<Locacao> _dbContextSet => _context.Set<Locacao>();

        public LocacaoRepository(BrunSkerDbContext context)
        {
            _context = context;
        }

        private async Task<bool> SaveDbAsync() => await _context.SaveChangesAsync() > 0;

        public async Task<bool> AddAsync(Locacao locacao)
        {
            await _dbContextSet.AddAsync(locacao);

            return await SaveDbAsync();
        }

        public async Task<bool> UpdateAsync(Locacao locacao)
        {
            _context.Entry(locacao).State = EntityState.Modified;
            _context.Entry(locacao.Endereco).State = EntityState.Modified;

            return await SaveDbAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var locacao = await _dbContextSet.Include(l => l.Endereco).FirstOrDefaultAsync(l => l.Id == id);

            _dbContextSet.Remove(locacao);

            return await SaveDbAsync();
        }

        public async Task<Locacao> GetLocacaoByIdAsync(int id) =>
            await _dbContextSet.Include(l => l.Endereco).FirstOrDefaultAsync(l => l.Id == id);
        
        public async Task<List<Locacao>> GetAllLocacoesAsync() =>
            await _dbContextSet.Include(l => l.Endereco).ToListAsync();

        public async Task<bool> HaveObjectInDb(Expression<Func<Locacao, bool>> where) => await _dbContextSet.AsNoTracking().AnyAsync(where);

        public void Dispose() => _context.Dispose();
    }
}
