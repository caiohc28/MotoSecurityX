using Microsoft.EntityFrameworkCore;
using MotoSecurityX.Data;
using MotoSecurityX.Models;

namespace MotoSecurityX.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly AppDbContext _context;

        public MotoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Moto>> GetAllAsync() =>
            await _context.Motos.ToListAsync();

        public async Task<Moto?> GetByIdAsync(int id) =>
            await _context.Motos.FindAsync(id);

        public async Task<Moto?> GetByPlacaAsync(string placa) =>
            await _context.Motos.FirstOrDefaultAsync(m => m.Placa == placa);

        public async Task<IEnumerable<Moto>> GetBySituacaoAsync(string situacao) =>
            await _context.Motos
                .Where(m => m.Situacao.ToLower() == situacao.ToLower())
                .ToListAsync();

        public async Task<Moto> CreateAsync(Moto moto)
        {
            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();
            return moto;
        }

        public async Task<bool> UpdateAsync(Moto moto)
        {
            var existe = await _context.Motos.AnyAsync(m => m.Id == moto.Id);
            if (!existe) return false;

            _context.Motos.Update(moto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null) return false;

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
