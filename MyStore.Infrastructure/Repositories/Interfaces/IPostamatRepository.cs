using MyStore.Core.Entities;

namespace MyStore.Infrastructure.Repositories.Interfaces
{
    public interface IPostamatRepository
    {
        Task<Postamat> GetById(int poastamatId);
        Task<IEnumerable<Postamat>> GetWorking();
    }
}
