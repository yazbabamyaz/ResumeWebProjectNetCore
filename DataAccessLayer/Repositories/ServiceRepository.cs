using Core.Entities;
using Core.Repositories;

namespace Repository.Repositories
{
    public class ServiceRepository : GenericRepository<MyService>, IServiceRepository
    {
        public ServiceRepository(AppDbContext context) : base(context)
        {
        }
    }



}
