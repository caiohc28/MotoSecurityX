using MotoSecurityX.Domain;

namespace MotoSecurityX.Repositories
{
    public interface IPatioRepository
    {
        Task<IEnumerable<Patio>> GetAllAsync();
        Task<Patio?> GetByIdAsync(int id);
        Task<Patio> CreateAsync(Patio patio);
        Task<bool> UpdateAsync(Patio patio);
        Task<bool> DeleteAsync(int id);
    }
}
