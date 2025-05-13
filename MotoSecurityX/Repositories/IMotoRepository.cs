using MotoSecurityX.Domain;

namespace MotoSecurityX.Repositories
{
    public interface IMotoRepository
    {
        Task<IEnumerable<Moto>> GetAllAsync();
        Task<Moto?> GetByIdAsync(int id);
        Task<Moto?> GetByPlacaAsync(string placa);
        Task<IEnumerable<Moto>> GetBySituacaoAsync(string situacao);
        Task<Moto> CreateAsync(Moto moto);
        Task<bool> UpdateAsync(Moto moto);
        Task<bool> DeleteAsync(int id);
    }
}
