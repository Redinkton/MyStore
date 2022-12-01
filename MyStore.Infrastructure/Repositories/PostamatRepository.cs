using MyStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using MyStore.Infrastructure.Data;
using MyStore.Infrastructure.Repositories.Interfaces;

namespace MyStore.Infrastructure.Repositories
{
    public class PostamatRepository : IPostamatRepository 
    {
        private readonly AppDbContext _appDbContext;
        public PostamatRepository(AppDbContext appDbContext)
        {
             _appDbContext = appDbContext;
        }

        public async Task<Postamat> GetById(int id)
        {
            return await _appDbContext.Postamats.FindAsync(id);
        }

        public async Task<IEnumerable<Postamat>> GetWorking() 
        {
            var sort = await _appDbContext.Postamats.Where(e => e.WorkingStatus == true).ToListAsync();
            sort.OrderBy(postamat => postamat.Number);
            return sort;
        }
    }
}
