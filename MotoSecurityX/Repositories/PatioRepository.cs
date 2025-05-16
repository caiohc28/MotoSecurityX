using MotoSecurityX.Domain;
using Microsoft.EntityFrameworkCore;
using MotoSecurityX.Data;

namespace MotoSecurityX.Repositories
{
    public class PatioRepository : IPatioRepository
    {
        private readonly AppDbContext _context;

        public PatioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patio>> GetAllAsync()
            => await _context.Patios.ToListAsync();

        public async Task<Patio?> GetByIdAsync(int id)
            => await _context.Patios.FindAsync(id);

        public async Task<Patio> CreateAsync(Patio patio)
        {
            _context.Patios.Add(patio);
            await _context.SaveChangesAsync();
            return patio;
        }

        public async Task<bool> UpdateAsync(Patio patio)
        {
            _context.Entry(patio).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var patio = await _context.Patios.FindAsync(id);
            if (patio == null) return false;
            _context.Patios.Remove(patio);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
